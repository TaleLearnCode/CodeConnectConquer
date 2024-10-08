namespace Cloudheim.Blacksmiths.Armaments.Extensions;

/// <summary>
/// Provides extension methods for converting SwordRequest objects to SwordDocument objects.
/// </summary>
internal static class SwordRequestExtensions
{

	/// <summary>
	/// Converts a SwordRequest object to a SwordDocument object.
	/// </summary>
	/// <param name="request">The SwordRequest object to convert.</param>
	/// <returns>A new SwordDocument object.</returns>
	internal static SwordDocument ToDocument(this SwordRequest request)
	{
		return new SwordDocument(Guid.NewGuid().ToString())
		{
			Name = request.Name,
			Type = request.Type,
			Material = request.Material,
			Attributes = request.Attributes,
			RequestedAt = DateTime.UtcNow
		};
	}

}