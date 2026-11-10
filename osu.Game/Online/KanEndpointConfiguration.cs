// Copyright (c) kan-rhythm contributors. Licensed under the MIT Licence.
// kan! rebrand (ADR-0011): new kan! code; no upstream code adapted in this file.

using System;

namespace osu.Game.Online
{
    /// <summary>
    /// kan!'s online services (fork F-20, F-24). A modified client must never use osu!'s
    /// servers. kan!'s own server (`server/app` in the kan-rhythm repository) speaks the
    /// same client protocol, so turning it on is only an address: <see cref="ServerUrl"/>.
    /// With no address the game stays offline, as it was.
    /// </summary>
    public class KanEndpointConfiguration : EndpointConfiguration
    {
        /// <summary>kan!'s public server (`server/app`, deployed 2026-11-10).</summary>
        private const string default_server_url = @"https://kan-api.kairophos.link";

        /// <summary>
        /// The OAuth client of the game. Like osu!lazer's, it is public by nature (it ships
        /// inside every copy of the game); the server's `OAUTH_CLIENT_SECRET` must match it.
        /// </summary>
        public const string CLIENT_ID = @"kan-client";

        public const string CLIENT_SECRET = @"kan-public-client";

        /// <summary>
        /// The server address: `KAN_SERVER_URL` from the environment (development, tests, a
        /// community server) or <see cref="default_server_url"/>. No trailing slash.
        /// </summary>
        public static string ServerUrl { get; } = (Environment.GetEnvironmentVariable(@"KAN_SERVER_URL") ?? default_server_url).Trim().TrimEnd('/');

        /// <summary>Whether kan! has a server to talk to (accounts, levels, scores).</summary>
        public static bool HasServer => !string.IsNullOrEmpty(ServerUrl);

        /// <summary>
        /// osu!'s own extras (menu news banner, supporter note, osu!'s ranked-beatmap metadata
        /// cache) come from osu!'s servers whatever the API address is: always off in kan!.
        /// </summary>
        public static bool UsesOsuAssets => false;

        /// <summary>Whether an online image or audio file may be fetched from this address (only kan!'s server).</summary>
        public static bool IsTrustedHost(Uri uri)
        {
            if (!HasServer || !Uri.TryCreate(ServerUrl, UriKind.Absolute, out Uri? server))
                return false;

            return string.Equals(uri.Host, server.Host, StringComparison.OrdinalIgnoreCase)
                   || uri.Host.EndsWith(@"." + server.Host, StringComparison.OrdinalIgnoreCase);
        }

        public KanEndpointConfiguration()
        {
            WebsiteUrl = APIUrl = ServerUrl;
            APIClientID = HasServer ? CLIENT_ID : string.Empty;
            APIClientSecret = HasServer ? CLIENT_SECRET : string.Empty;
            // No realtime services yet (spectator, multiplayer, metadata): the client only logs
            // and retries quietly when these fail (server/docs/lazer-protocol.md §6.2).
            SpectatorUrl = string.Empty;
            MultiplayerUrl = string.Empty;
            MetadataUrl = string.Empty;
            BeatmapSubmissionServiceUrl = null;
        }
    }
}
