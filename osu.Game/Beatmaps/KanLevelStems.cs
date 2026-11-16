// Copyright (c) kan-rhythm contributors. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.IO;

namespace Kan.Client
{
    /// <summary>
    /// kan!'s level stems (issue 42, fork divergence F-34): a level keeps the
    /// separated tracks of its song under "stems/", as source material for
    /// other levels made from the same song. Play never opens them, they are
    /// not hitsounds or other assets, and the submission upload may leave
    /// them out (a request body over 100 MB is refused by the server's
    /// tunnel). The kan! side supplies the two decisions at ruleset init
    /// (game/ruleset/Beatmaps/KanLevelFiles.Init).
    /// </summary>
    public static class KanLevelStems
    {
        /// <summary>Whether a level's file is one of its stems: anything under "stems/".</summary>
        public static bool IsStem(string? fileName)
            => fileName != null
               && fileName.Replace('\\', '/').StartsWith("stems/", StringComparison.OrdinalIgnoreCase);
    }
}
