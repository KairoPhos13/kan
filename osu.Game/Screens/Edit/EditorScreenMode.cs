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

        // kan! rebrand (ADR-0011) / fork F-11: the ruleset-provided "track"
        // editor screen (kan!forge level creation), the second tab and the
        // first tool used when creating a level (owner 2026-10-13). The screen
        // instance comes from Ruleset.CreateTracksEditorScreen().
        Tracks,

        // kan! fork F-11 follow-up: timing before compose (owner 2026-10-14:
        // aligning the beat grid to each section first saves problems later).
        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.TimingScreen))]
        Timing,

        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.ComposeScreen))]
        Compose,

        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.DesignScreen))]
        Design,

        [LocalisableDescription(typeof(EditorStrings), nameof(EditorStrings.VerifyScreen))]
        Verify,
    }
}
