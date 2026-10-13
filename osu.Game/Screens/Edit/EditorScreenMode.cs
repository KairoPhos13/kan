// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Localisation;
using osu.Game.Localisation;

namespace osu.Game.Screens.Edit
{
    public enum EditorScreenMode
    {
        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.SetupScreen))]
        SongSetup,

        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.ComposeScreen))]
        Compose,

        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.DesignScreen))]
        Design,

        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.TimingScreen))]
        Timing,

        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.VerifyScreen))]
        Verify,

        // kan! rebrand (ADR-0011) / fork F-11: the ruleset-provided "tracks"
        // editor screen (kan!forge level creation — media track list, roles,
        // track editing). The screen instance comes from
        // Ruleset.CreateTracksEditorScreen().
        Tracks,
    }
}
