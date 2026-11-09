// Copyright (c) kan-rhythm contributors. Licensed under the MIT Licence.
// kan! rebrand (ADR-0011): new kan! code — no upstream code adapted in this file.

namespace osu.Game.Online
{
    /// <summary>
    /// kan!'s online services (fork F-20). There are none yet: a modified client
    /// must not use osu!'s servers, so every address is empty and the game stays
    /// offline. The online code is all kept; turning it on is filling these in
    /// with kan!'s own servers (osu-web, osu-server-spectator) and its client id.
    /// </summary>
    public class KanEndpointConfiguration : EndpointConfiguration
    {
        private const string api_url = @"";

        /// <summary>Whether kan! has a server to talk to (accounts, menu news, beatmap metadata).</summary>
        public static bool HasServer => !string.IsNullOrEmpty(api_url);

        public KanEndpointConfiguration()
        {
            WebsiteUrl = APIUrl = api_url;
            APIClientSecret = string.Empty;
            APIClientID = string.Empty;
            SpectatorUrl = string.Empty;
            MultiplayerUrl = string.Empty;
            MetadataUrl = string.Empty;
            BeatmapSubmissionServiceUrl = null;
        }
    }
}
