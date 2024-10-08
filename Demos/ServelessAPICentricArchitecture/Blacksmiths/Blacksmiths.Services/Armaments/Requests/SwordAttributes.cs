namespace Cloudheim.Blacksmiths.Armaments.Requests;

/// <summary>
/// Represents the attributes of a sword.
/// </summary>
public class SwordAttributes
{

	/// <summary>
	/// Gets or sets the sharpness of the sword.
	/// </summary>
	public string Sharpness { get; set; } = null!;

	/// <summary>
	/// Gets or sets the engraving on the sword.
	/// </summary>
	public string Engraving { get; set; } = null!;

	/// <summary>
	/// Gets or sets the weight of the sword.
	/// </summary>
	public decimal Weight { get; set; }

	/// <summary>
	/// Gets or sets the length of the sword.
	/// </summary>
	public int Length { get; set; }

}