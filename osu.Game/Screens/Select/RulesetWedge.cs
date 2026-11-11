// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets;

namespace osu.Game.Screens.Select
{
    /// <summary>
    /// kan! fork (F-29): a wedge under the beatmap's title wedge holding what
    /// the current ruleset adds to song select
    /// (<see cref="Ruleset.CreateSongSelectWedgeContent"/>). Takes no space
    /// for a ruleset that adds nothing.
    /// </summary>
    public partial class RulesetWedge : VisibilityContainer
    {
        private const float corner_radius = 10;

        [Resolved]
        private IBindable<RulesetInfo> ruleset { get; set; } = null!;

        private readonly Action refilter;

        private Container background = null!;
        private Container content = null!;

        protected override bool StartHidden => true;

        public RulesetWedge(Action refilter)
        {
            this.refilter = refilter;

            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            // Not masked as a whole: the content may open dropdowns past its edge.
            InternalChildren = new Drawable[]
            {
                background = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Masking = true,
                    CornerRadius = corner_radius,
                    Child = new WedgeBackground(),
                },
                content = new Container
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Padding = new MarginPadding
                    {
                        Vertical = 10,
                        Left = SongSelect.WEDGE_CONTENT_MARGIN,
                        Right = SongSelect.WEDGE_CONTENT_MARGIN + 20,
                    },
                },
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            ruleset.BindValueChanged(r =>
            {
                var drawable = r.NewValue?.CreateInstance().CreateSongSelectWedgeContent(refilter);

                if (drawable == null)
                {
                    content.Clear();
                    content.Alpha = background.Alpha = 0;
                    content.AutoSizeAxes = Axes.None;
                    content.Height = 0;
                    Margin = new MarginPadding();
                    return;
                }

                content.Alpha = background.Alpha = 1;
                content.AutoSizeAxes = Axes.Y;
                Margin = new MarginPadding { Top = 4 };
                content.Child = new Container
                {
                    Shear = -OsuGame.SHEAR,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Child = drawable,
                };
            }, true);
        }

        protected override void PopIn()
        {
            this.MoveToX(0, SongSelect.ENTER_DURATION, Easing.OutQuint)
                .FadeIn(SongSelect.ENTER_DURATION / 3, Easing.In);
        }

        protected override void PopOut()
        {
            this.MoveToX(-150, SongSelect.ENTER_DURATION, Easing.OutQuint)
                .FadeOut(SongSelect.ENTER_DURATION / 3, Easing.In);
        }
    }
}
