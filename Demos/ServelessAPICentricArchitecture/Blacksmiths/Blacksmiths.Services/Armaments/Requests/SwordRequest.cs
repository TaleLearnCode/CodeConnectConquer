namespace Cloudheim.Blacksmiths.Armaments.Requests;

/// <summary>
/// Represents a request for a sword.
/// </summary>
public class SwordRequest
{

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

}