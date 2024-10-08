using Newtonsoft.Json;

namespace Cloudheim.Blacksmiths.Armaments.Documents;

/// <summary>
/// Represents a document for a sword in the armaments system.
/// </summary>
public class SwordDocument : BlacksmithDocumentBase
{

	private const string _category = "Swords";

	/// <summary>
	/// Initializes a new instance of the <see cref="SwordDocument"/> class.
	/// </summary>
	public SwordDocument() : base(_category) { }

	public SwordDocument(string Id) : base(_category)
	{
		this.Id = Id;
	}

	/// <summary>
	/// Gets or sets the name of the sword.
	/// </summary>
	[JsonProperty(PropertyName = "name")]
	public string Name { get; set; } = null!;

	/// <summary>
	/// Gets or sets the type of the sword.
	/// </summary>
	[JsonProperty(PropertyName = "type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Gets or sets the material of the sword.
	/// </summary>
	[JsonProperty(PropertyName = "material")]
	public string Material { get; set; } = null!;

	/// <summary>
	/// Gets or sets the attributes of the sword.
	/// </summary>
	[JsonProperty(PropertyName = "attributes")]
	public SwordAttributes Attributes { get; set; } = null!;

	/// <summary>
	/// Gets or sets the date and time when the sword was requested.
	/// </summary>
	[JsonProperty(PropertyName = "requestedAt")]
	public DateTime RequestedAt { get; set; }

}