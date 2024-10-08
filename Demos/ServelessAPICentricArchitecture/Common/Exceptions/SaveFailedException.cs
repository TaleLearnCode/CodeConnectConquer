namespace Cloudheim.Common.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a save operation fails.
/// </summary>
public class SaveFailedException : Exception
{

	/// <summary>
	/// Initializes a new instance of the <see cref="SaveFailedException"/> class.
	/// </summary>
	public SaveFailedException() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="SaveFailedException"/> class with a specified error message.
	/// </summary>
	/// <param name="message">The message that describes the error.</param>
	public SaveFailedException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="SaveFailedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	/// <param name="message">The message that describes the error.</param>
	/// <param name="innerException">The exception that is the cause of the current exception.</param>
	public SaveFailedException(string message, Exception innerException) : base(message, innerException) { }

}