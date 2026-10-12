// Copyright (c) kan-rhythm contributors. Licensed under the MIT Licence.
// kan! rebrand (ADR-0011): new kan! code — no upstream code adapted in this file.

using System;
using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Localisation;
using osu.Game.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Overlays.Settings;

namespace Kan.Client
{
    /// <summary>
    /// kan! about screen (ADR-0011): product identity, attribution to the
    /// upstream osu!lazer project, and the generated THIRD_PARTY_NOTICES
    /// (see game/tools/gen-third-party-notices.py in the kan-rhythm monorepo).
    /// </summary>
    public partial class KanAboutSettings : SettingsSubsection
    {
        protected override LocalisableString Header => @"About kan!";

        private const string notices_resource_name = @"THIRD_PARTY_NOTICES.md";

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new OsuSpriteText
            {
                Text = @"kan!",
                Font = OsuFont.GetFont(size: 36, weight: FontWeight.Bold),
            });

            Add(new OsuSpriteText
            {
                Text = @"Grab your instrument. You kan!",
                Font = OsuFont.GetFont(size: 18, weight: FontWeight.Light),
            });

            Add(new OsuSpriteText
            {
                Text = @"Built on osu!lazer (MIT) — ppy/osu contributors",
                Font = OsuFont.GetFont(size: 14),
            });

            Add(new OsuSpriteText
            {
                Text = @"Third-party notices",
                Font = OsuFont.GetFont(size: 16, weight: FontWeight.Bold),
            });

            Add(new BasicScrollContainer
            {
                RelativeSizeAxes = Axes.X,
                Height = 320,
                Child = new OsuSpriteText
                {
                    Text = loadNotices(),
                    Font = OsuFont.GetFont(size: 10, weight: FontWeight.Regular),
                },
            });
        }

        private static string loadNotices()
        {
            try
            {
                using var stream = typeof(KanAboutSettings).Assembly.GetManifestResourceStream(notices_resource_name);

                if (stream == null)
                    return $@"{notices_resource_name} is missing from this build.";

                using var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                return $@"Could not load {notices_resource_name}: {e.Message}";
            }
        }
    }
}
