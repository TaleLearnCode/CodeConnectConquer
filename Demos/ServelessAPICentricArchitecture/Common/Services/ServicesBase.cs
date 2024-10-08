using Cloudheim.Common.Exceptions;
using Microsoft.Azure.Cosmos;

namespace Cloudheim.Common.Services;

public abstract class ServicesBase(Container container, string partitionKey, string category)
{

	private readonly Container _container = container;
	private readonly string _partitionKey = partitionKey;
	private readonly string _category = category;

	protected async Task<TDocument> CreateAsync<TDocument>(TDocument document, string partitionKey) where TDocument : class
	{
		try
		{
			//ItemResponse<TDocument> response = await _container.CreateItemAsync(document, new PartitionKey(_partitionKey));
			ItemResponse<TDocument> response = await _container.CreateItemAsync(document, new PartitionKey(partitionKey));
			if (response.StatusCode != System.Net.HttpStatusCode.Created)
				throw new SaveFailedException($"Failed to process the {_category}. Error code: {response.StatusCode}.");
			return response.Resource;
		}
		catch (SaveFailedException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new SaveFailedException($"Failed to process the {_category}.", ex);
		}
	}

	protected async Task<TDocument> GetAsync<TDocument>(string id) where TDocument : class
	{
		ItemResponse<TDocument> response = await _container.ReadItemAsync<TDocument>(id, new PartitionKey(_partitionKey));
		if (response.StatusCode != System.Net.HttpStatusCode.OK)
			throw new NotFoundException($"The {_category} with the identifier '{id}' was not found.");
		return response.Resource;
	}

	protected async Task<IEnumerable<TDocument>> GetAsync<TDocument>() where TDocument : class
	{
		QueryDefinition query = new($"SELECT * FROM items WHERE items.category = '{_category}'");
		using FeedIterator<TDocument> feed = _container.GetItemQueryIterator<TDocument>(query);
		List<TDocument> results = [];
		while (feed.HasMoreResults)
		{
			FeedResponse<TDocument> response = await feed.ReadNextAsync();
			results.AddRange(response);
		}
		return results;
	}

	protected async Task<TDocument> UpdateAsync<TDocument>(string id, TDocument document) where TDocument : class
	{
		try
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentException($"The {_category} identifier must be provided.", nameof(id));
			ItemResponse<TDocument> response = await _container.ReadItemAsync<TDocument>(id, new PartitionKey(_partitionKey));
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
				throw new NotFoundException($"The {_category} with the identifier '{id}' was not found.");
			response = await _container.ReplaceItemAsync(document, id, new PartitionKey(_partitionKey));
			return response.Resource;
		}
		catch (NotFoundException)
		{
			throw;
		}
		catch (ArgumentException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new SaveFailedException($"Failed to process the {_category}.", ex);
		}
	}

	protected async Task DeleteAsync(string id)
	{
		try
		{
			ItemResponse<object> response = await _container.DeleteItemAsync<object>(id, new PartitionKey(_partitionKey));
			if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
				throw new SaveFailedException($"Failed to delete the {_category}. Error code: {response.StatusCode}.");
		}
		catch (SaveFailedException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new SaveFailedException($"Failed to delete the {_category}.", ex);
		}
	}

}