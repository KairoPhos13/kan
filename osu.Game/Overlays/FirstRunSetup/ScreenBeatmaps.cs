// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// kan! rebrand (ADR-0011, fork F-24): this step no longer downloads osu!'s tutorial and
// bundled osu! beatmaps (from osu!'s servers). It opens kan!'s own level catalogue when kan!
// has a server, and otherwise explains how to add levels by hand.

using System;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Localisation;
using osu.Game.Beatmaps;
using osu.Game.Database;
using osu.Game.Graphics;
using osu.Game.Graphics.Containers;
using osu.Game.Graphics.UserInterfaceV2;
using osu.Game.Localisation;
using osu.Game.Online;
using osuTK;
using Realms;

namespace osu.Game.Overlays.FirstRunSetup
{
    [LocalisableDescription(typeof(FirstRunSetupBeatmapScreenStrings), nameof(FirstRunSetupBeatmapScreenStrings.Header))]
    public partial class ScreenBeatmaps : WizardScreen
    {
        private OsuTextFlowContainer currentlyLoadedBeatmaps = null!;

        [Resolved]
        private OsuColour colours { get; set; } = null!;

        [Resolved]
        private RealmAccess realmAccess { get; set; } = null!;

        [Resolved(canBeNull: true)]
        private BeatmapListingOverlay? beatmapListing { get; set; }

        private IDisposable? beatmapSubscription;

        [BackgroundDependencyLoader]
        private void load()
        {
            Vector2 buttonSize = new Vector2(400, 50);

            Content.Children = new Drawable[]
            {
                new OsuTextFlowContainer(cp => cp.Font = OsuFont.Default.With(size: CONTENT_FONT_SIZE))
                {
                    Colour = OverlayColourProvider.Content1,
                    Text = "Levels are the songs you play. kan! starts with none, so let's get you a few.",
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y
                },
                new Container
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 30,
                    Children = new Drawable[]
                    {
                        currentlyLoadedBeatmaps = new OsuTextFlowContainer(cp => cp.Font = OsuFont.Default.With(size: HEADER_FONT_SIZE, weight: FontWeight.SemiBold))
                        {
                            Colour = OverlayColourProvider.Content2,
                            TextAnchor = Anchor.Centre,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            AutoSizeAxes = Axes.Both,
                        },
                    }
                },
                KanEndpointConfiguration.HasServer
                    ? new FillFlowContainer
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Direction = FillDirection.Vertical,
                        Spacing = new Vector2(0, 10),
                        Children = new Drawable[]
                        {
                            new OsuTextFlowContainer(cp => cp.Font = OsuFont.Default.With(size: CONTENT_FONT_SIZE))
                            {
                                Colour = OverlayColourProvider.Content1,
                                Text = "Browse kan!'s level catalogue: pick songs you like and download them in one click. "
                                       + "Free songs and easy levels are a calm place to start.",
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y
                            },
                            new RoundedButton
                            {
                                Size = buttonSize,
                                Anchor = Anchor.TopCentre,
                                Origin = Anchor.TopCentre,
                                BackgroundColour = colours.Yellow,
                                Text = "Browse kan!'s levels",
                                Action = () => beatmapListing?.Show(),
                            },
                            new OsuTextFlowContainer(cp => cp.Font = OsuFont.Default.With(size: CONTENT_FONT_SIZE))
                            {
                                Colour = OverlayColourProvider.Content1,
                                Text = FirstRunSetupBeatmapScreenStrings.ObtainMoreBeatmaps,
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y
                            },
                        }
                    }
                    : new OsuTextFlowContainer(cp => cp.Font = OsuFont.Default.With(size: CONTENT_FONT_SIZE))
                    {
                        Colour = OverlayColourProvider.Content1,
                        Text = "To add a level someone shared with you, drop its file (.osz) onto this window. "
                               + "You can also make your own from any song in kan!forge, the level editor.",
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y
                    },
                new OsuTextFlowContainer(cp => cp.Font = OsuFont.Default.With(size: CONTENT_FONT_SIZE))
                {
                    Colour = OverlayColourProvider.Light2,
                    Text = "Levels you add show up in the song list when you press play.",
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y
                },
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            beatmapSubscription = realmAccess.RegisterForNotifications(r => r.All<BeatmapSetInfo>().Where(s => !s.DeletePending && !s.Protected), beatmapsChanged);
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            beatmapSubscription?.Dispose();
        }

        private void beatmapsChanged(IRealmCollection<BeatmapSetInfo> sender, ChangeSet? changes) => Schedule(() =>
        {
            currentlyLoadedBeatmaps.Text = FirstRunSetupBeatmapScreenStrings.CurrentlyLoadedBeatmaps(sender.Count);

            if (sender.Count == 0)
            {
                currentlyLoadedBeatmaps.FadeColour(colours.Red1, 500, Easing.OutQuint);
            }
            else if (changes != null && (changes.DeletedIndices.Any() || changes.InsertedIndices.Any()))
            {
                currentlyLoadedBeatmaps.FadeColour(colours.Yellow)
                                       .FadeColour(OverlayColourProvider.Content2, 1500, Easing.OutQuint);

                currentlyLoadedBeatmaps.ScaleTo(1.1f)
                                       .ScaleTo(1, 1500, Easing.OutQuint);
            }
        });
    }
}
