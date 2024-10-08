namespace Cloudheim.Blacksmiths.Documents;

/// <summary>
/// Represents a base class for blacksmith documents.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BlacksmithDocumentBase"/> class with the specified category.
/// </remarks>
/// <param name="category">The category of the blacksmith document.</param>
public abstract class BlacksmithDocumentBase(string category) : DocumentBase(_house, category)
{
	private const string _house = "Blacksmiths";
}