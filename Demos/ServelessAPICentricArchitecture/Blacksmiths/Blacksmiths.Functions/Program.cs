using Azure.Data.AppConfiguration;
using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

DefaultAzureCredential defaultAzureCredential = new();

Uri appConfigEndpoint = new(Environment.GetEnvironmentVariable("AppConfigEndpoint")!);
ConfigurationClient configClient = new(appConfigEndpoint, defaultAzureCredential);

CosmosClient cosmosClient = new(configClient.GetConfigurationSetting("Cosmos:AccountEndpoint").Value.Value, defaultAzureCredential);
Database database = cosmosClient.GetDatabase(configClient.GetConfigurationSetting("Cosmos:CloudheimDatabase").Value.Value);
Container blacksmithsContainer = database.GetContainer(configClient.GetConfigurationSetting("Cosmos:BlacksmithsContainer").Value.Value);

string armamentsPartitionKey = "category";
string swordCategory = "Swords";

JsonSerializerOptions jsonSerializerOptions = new()
{
	PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
	WriteIndented = true,
	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
};

IHost host = new HostBuilder()
	.ConfigureAppConfiguration(builder =>
	{
		builder.AddAzureAppConfiguration(options =>
		{
			options.Connect(appConfigEndpoint, defaultAzureCredential);
		});
	})

	.ConfigureFunctionsWebApplication()
	.ConfigureServices(services =>
	{
		services.AddApplicationInsightsTelemetryWorkerService();
		services.ConfigureFunctionsApplicationInsights();
		services.AddSingleton(jsonSerializerOptions);
		services.AddSingleton(new ArmamentService(blacksmithsContainer, armamentsPartitionKey, swordCategory));
	})
	.Build();

host.Run();
