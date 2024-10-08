using Newtonsoft.Json;

namespace Cloudheim.Common.Documents;

/// <summary>
/// Base class for documents.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DocumentBase"/> class.
/// </remarks>
/// <param name="house">The house of the document.</param>
/// <param name="category">The category of the document.</param>
public abstract class DocumentBase(string house, string category)
{

	/// <summary>
	/// Gets or sets the ID of the document.
	/// </summary>
	//[JsonPropertyName("id")]
	[JsonProperty(PropertyName = "id")]
	public string Id { get; protected set; } = Guid.NewGuid().ToString();

	/// <summary>
	/// Gets or sets the house of the document.
	/// </summary>
	[JsonProperty(PropertyName = "house")]
	public string House { get; protected set; } = house;

	/// <summary>
	/// Gets or sets the category of the document.
	/// </summary>
	[JsonProperty(PropertyName = "category")]
	public string Category { get; protected set; } = category;

}