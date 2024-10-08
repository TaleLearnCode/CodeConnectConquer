using Cloudheim.Blacksmiths.Armaments.Responses;

namespace Cloudheim.Blacksmiths.Armaments.Extensions;

internal static class SwordDocumentExtensions
{

	internal static SwordResponse ToResponse(this SwordDocument document)
	{
		return new SwordResponse
		{
			Id = document.Id,
			Name = document.Name,
			Type = document.Type,
			Material = document.Material,
			Attributes = document.Attributes,
			RequestedAt = document.RequestedAt
		};
	}

}