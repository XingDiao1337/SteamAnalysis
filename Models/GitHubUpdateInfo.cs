using System.IO;
using System.Net.Http;


using System.IO;
using System.Net.Http;


namespace SteamEyaWinUI.Models;

internal sealed record GitHubUpdateInfo(
    string CurrentVersion,
    string LatestVersion,
    string LatestTag,
    bool IsUpdateAvailable,
    string ReleaseUrl,
    string? ArtifactName,
    string? ArtifactUrl,
    long? ArtifactSize,
    string? ArtifactSha256,
    IReadOnlyList<string> Changelog,
    DateTimeOffset CheckedAt);

