namespace Jwtil.Core.Models;

/// <summary>
///     Class <c>DecodedToken</c> represents a decoded JSON Web Token.
/// </summary>
public class DecodedToken
{
    /// <summary>
    ///     The serialized header of the JSON Web Token.
    /// </summary>
    public string Header { get; set; } = default!;

    /// <summary>
    ///     The serialized payload of the JSON Web Token.
    /// </summary>
    public string Payload { get; set; } = default!;

    /// <summary>
    ///     Whether the JSON Web Token has a verified signature.
    /// </summary>
    public bool Verified { get; set; }
}
