using System.IO;
using System.Net.Http;


using System.IO;
using System.Net.Http;


namespace SteamEyaWinUI.Models;

public sealed record JwtValidationResult(string SteamId, DateTimeOffset ExpiresAt)
{
    public TimeSpan Remaining => ExpiresAt - DateTimeOffset.Now;
}

