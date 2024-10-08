namespace Cloudheim.Blacksmiths.Armaments.Responses;

/// <summary>
/// Represents a response for a sword.
/// </summary>
public class SwordResponse
{

	/// <summary>
	/// Gets or sets the ID of the sword.
	/// </summary>
	public string Id { get; set; } = null!;

	/// <summary>
	/// Gets or sets the name of the sword.
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Gets or sets the type of the sword.
	/// </summary>
	public string Type { get; set; } = null!;

	/// <summary>
	/// Gets or sets the material of the sword.
	/// </summary>
	public string Material { get; set; } = null!;

	/// <summary>
	/// Gets or sets the attributes of the sword.
	/// </summary>
	public SwordAttributes Attributes { get; set; } = null!;

	/// <summary>
	/// Gets or sets the date and time when the sword was requested.
	/// </summary>
	public DateTime RequestedAt { get; set; }

}