using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Endcard : StoryboardObjectGenerator
    {
        public double Opacity = 0.2;

        public override void Generate()
        {
		    EndCard(615557, 665149);
        }

        public void EndCard(int startTime, int endTime)
        {
            var endcardPos = new Vector2(300, 400);
            var endcard = GetLayer("endcard").CreateSprite("sb/endcard.png", OsbOrigin.CentreLeft, endcardPos);

            var endcardScale = GetMapsetBitmap("sb/endcard.png");
            endcard.Scale(startTime, 50.0f / endcardScale.Height);

            endcard.Fade(startTime, startTime + 1000, 0, Opacity);
            endcard.Fade(endTime, endTime + 500, Opacity, 0);
        }
    }
}
