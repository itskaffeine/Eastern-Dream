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
    public class Break : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            BowSwitch(257093, 260002);
            BowSwitch(260002, 262911);
            BowSwitch(262911, 265820);
            BowSwitch(265820, 268730);
            BowSwitch(268730, 271639);
            BowSwitch(271639, 274548);
            BowSwitch(274548, 277457);
            BowSwitch(277457, 280366);
            BowSwitch(280366, 283275);
            BowSwitch(283275, 286366);
        }

        public void BowSwitch(int startTime, int endTime)
        {
            var beatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;
            double Opacity = 0.5;

            var bowbg = GetLayer("bg").CreateSprite("sb/bg bow.jpg", OsbOrigin.Centre);
            var bowbgScale = GetMapsetBitmap("sb/bg bow.jpg");

            var flash = GetLayer("bg").CreateSprite("sb/bg.jpg", OsbOrigin.Centre);
            var flashScale = GetMapsetBitmap("sb/bg.jpg");

            bowbg.Scale(startTime, 910.0f / bowbgScale.Width);
            bowbg.Fade(startTime, startTime + 500, 0, Opacity);
            bowbg.Fade(endTime - beatDuration * 2, endTime, Opacity, .4);

            flash.Scale(startTime, 910.0f / flashScale.Width);
            flash.Fade(startTime, startTime + beatDuration * 6, .8, 0);
        }


    }
}
