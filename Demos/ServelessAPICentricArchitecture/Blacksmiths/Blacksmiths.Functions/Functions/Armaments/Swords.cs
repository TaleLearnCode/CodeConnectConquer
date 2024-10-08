namespace Cloudheim.Blacksmiths.Functions.Armaments;

/// <summary>
/// Azure Functions for working with swords.
/// </summary>
/// <param name="logger">The logger to use for logging.</param>
/// <param name="armamentService">The <see cref="ArmamentService"/> to use when working with swords.</param>
public class Swords(ILogger<Swords> logger, ArmamentService armamentService, JsonSerializerOptions jsonSerializerOptions1)
{

	private readonly ILogger<Swords> _logger = logger;
	private readonly ArmamentService _armamentService = armamentService;
	private readonly JsonSerializerOptions _jsonSerializerOptions = jsonSerializerOptions1;

	/// <summary>
	/// Creates a new sword.
	/// </summary>
	/// <param name="request">The HTTP request containing the sword details.</param>
	/// <returns>An IActionResult representing the result of the operation.</returns>
	[Function("Swords_Create")]
	public async Task<IActionResult> CreateSwordAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "armaments/swords")] HttpRequest request)
	{
		_logger.LogInformation("Received request to create a new sword.");

		SwordRequest? swordRequest = JsonSerializer.Deserialize<SwordRequest>(await new StreamReader(request.Body).ReadToEndAsync(), _jsonSerializerOptions);
		if (swordRequest is null)
		{
			_logger.LogError("Failed to deserialize the request body.");
			return new BadRequestResult();
		}

		_logger.LogInformation("Processing request to create the '{swordName}' sword.", swordRequest.Name);
		SwordResponse swordResponse = await _armamentService.CreateSwordAsync(swordRequest);
		return new AcceptedResult($"armaments/swords/{swordResponse.Id}", swordResponse);
	}

	/// <summary>
	/// Gets a sword by its ID.
	/// </summary>
	/// <param name="request">The HTTP request containing the sword details.</param>
	/// <param name="id">The identifier of the sword to retrieve.</param>
	/// <returns>An IActionResult representing the result of the operation.</returns>
	[Function("Swords_Get")]
	public async Task<IActionResult> GetSwordAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "armaments/swords/{id}")] HttpRequest request, string id)
	{
		_logger.LogInformation("Received request to get the '{id}' sword.", id);
		SwordResponse swordResponse = await _armamentService.GetSwordAsync(id);
		if (swordResponse is null)
		{
			_logger.LogError("Failed to find the '{id}' sword.", id);
			return new NotFoundResult();
		}
		return new OkObjectResult(swordResponse);
	}

	/// <summary>
	/// Gets a list of all swords.
	/// </summary>
	/// <param name="request">The HTTP request containing the sword details.</param>
	/// <returns>An IActionResult representing the result of the operation.</returns>
	[Function("Swords_GetList")]
	public async Task<IActionResult> GetSwordsAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "armaments/swords")] HttpRequest request)
	{
		_logger.LogInformation("Received request to get all swords.");
		IEnumerable<SwordResponse> swordResponses = await _armamentService.GetSwordsAsync();
		return new OkObjectResult(swordResponses);
	}

	/// <summary>
	///	Updates a sword by its identifier.
	/// </summary>
	/// <param name="request">The HTTP request containing the sword details.</param>
	/// <param name="id">The identifier of the sword to update.</param>
	/// <returns>An IActionResult representing the result of the operation.</returns>
	[Function("Swords_Update")]
	public async Task<IActionResult> UpdateSwordAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = "armaments/swords/{id}")] HttpRequest request, string id)
	{
		_logger.LogInformation("Received request to update the '{id}' sword.", id);

		SwordRequest? swordRequest = JsonSerializer.Deserialize<SwordRequest>(await new StreamReader(request.Body).ReadToEndAsync());
		if (swordRequest is null)
		{
			_logger.LogError("Failed to deserialize the request body.");
			return new BadRequestResult();
		}

		SwordResponse swordResponse = await _armamentService.UpdateSwordAsync(id, swordRequest);
		if (swordResponse is null)
		{
			_logger.LogError("Failed to find the '{id}' sword.", id);
			return new NotFoundResult();
		}
		return new OkObjectResult(swordResponse);
	}

	/// <summary>
	/// Deletes a sword by its identifier.
	/// </summary>
	/// <param name="request">The HTTP request containing the sword details.</param>
	/// <param name="id">The identifier of the sword to delete.</param>
	/// <returns>An IActionResult representing the result of the operation.</returns>
	[Function("Swords_Delete")]
	public async Task<IActionResult> DeleteSwordAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "armaments/swords/{id}")] HttpRequest request, string id)
	{
		try
		{
			_logger.LogInformation("Received request to delete the '{id}' sword.", id);
			await _armamentService.DeleteSwordAsync(id);
			return new NoContentResult();
		}
		catch (NotFoundException)
		{
			_logger.LogError("Failed to find the '{id}' sword.", id);
			return new NotFoundResult();
		}
	}

}