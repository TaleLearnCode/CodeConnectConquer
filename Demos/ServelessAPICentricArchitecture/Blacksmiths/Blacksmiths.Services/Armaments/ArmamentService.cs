using Cloudheim.Common.Services;

namespace Cloudheim.Blacksmiths.Armaments;

public class ArmamentService(Container container, string partitionKey, string category) : ServicesBase(container, partitionKey, category)
{

	public async Task<SwordResponse> CreateSwordAsync(SwordRequest request)
	{
		SwordDocument swordDocument = request.ToDocument();
		return (await CreateAsync(swordDocument, swordDocument.Category)).ToResponse();
	}

	public async Task<SwordResponse> GetSwordAsync(string id)
		=> (await GetAsync<SwordDocument>(id)).ToResponse();

	public async Task<IEnumerable<SwordResponse>> GetSwordsAsync()
		=> (await GetAsync<SwordDocument>()).Select(document => document.ToResponse());

	public async Task<SwordResponse> UpdateSwordAsync(string id, SwordRequest request)
		=> (await UpdateAsync(id, request.ToDocument())).ToResponse();

	public async Task DeleteSwordAsync(string id)
		=> await DeleteAsync(id);

}