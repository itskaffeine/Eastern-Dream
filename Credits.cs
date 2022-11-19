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
    public class Credits : StoryboardObjectGenerator
    {
        public double Opacity = 1;

        public override void Generate()
        {
            Music(462223, 464356); 
            Mapping(465423, 466490);
            Storyboard(468623, 469690);
        }

        public void Music(int startTime, int endTime)
        {
            var titleStartPos = new Vector2(168, 740);
            var titlePos = new Vector2(340, 370);
            var titlePosTwo = new Vector2(347, 355);
            var titlePosEnd = new Vector2(573, -130);

            var title = GetLayer("credits").CreateSprite("sb/easterndream.png", OsbOrigin.CentreLeft, titleStartPos);

            var titleScale = GetMapsetBitmap("sb/easterndream.png");
            title.Fade(startTime - 100, startTime, 0, Opacity);
            title.Fade(endTime, endTime + 500, Opacity, 0);
            title.Rotate(startTime, MathHelper.DegreesToRadians(-65));
            title.Scale(startTime, 30.0f / titleScale.Height);

            title.Move(startTime - 100, startTime, titleStartPos, titlePos);

            title.Move(startTime, endTime, titlePos, titlePosTwo);
            
            title.Move(endTime, endTime + 100, titlePosTwo, titlePosEnd);
        }

        public void Mapping(int startTime, int endTime)
        {
            var mapperStartPos = new Vector2(0, -704);
            var mapperPos = new Vector2(375, 100);
            var mapperPosTwo = new Vector2(382, 115);
            var mapperPosEnd = new Vector2(750, 905);

            var mapper = GetLayer("credits").CreateSprite("sb/mapper.png", OsbOrigin.CentreLeft, mapperStartPos);

            var mapperScale = GetMapsetBitmap("sb/mapper.png");
            mapper.Fade(startTime - 100, startTime, 0, Opacity);
            mapper.Fade(endTime, endTime + 500, Opacity, 0);
            mapper.Rotate(startTime, MathHelper.DegreesToRadians(65));
            mapper.Scale(startTime, 30.0f / mapperScale.Height);

            mapper.Move(startTime - 100, startTime, mapperStartPos, mapperPos);

            mapper.Move(startTime, endTime, mapperPos, mapperPosTwo);
            
            mapper.Move(endTime, endTime + 100, mapperPosTwo, mapperPosEnd);
        }

        public void Storyboard(int startTime, int endTime)
        {
            var storyboarderStartPos = new Vector2(0, 766);
            var storyboarderPos = new Vector2(180, 380);
            var storyboarderPosTwo = new Vector2(187, 365);
            var storyboarderPosEnd = new Vector2(360, -6);

            var storyboarder = GetLayer("credits").CreateSprite("sb/storyboarder.png", OsbOrigin.CentreLeft, storyboarderPos);

            var storyboarderScale = GetMapsetBitmap("sb/storyboarder.png");
            storyboarder.Fade(startTime - 100, startTime, 0, Opacity);
            storyboarder.Fade(endTime, endTime + 500, Opacity, 0);
            storyboarder.Rotate(startTime, MathHelper.DegreesToRadians(-65));
            storyboarder.Scale(startTime, 35.0f / storyboarderScale.Height);

            storyboarder.Move(startTime - 100, startTime, storyboarderStartPos, storyboarderPos);

            storyboarder.Move(startTime, endTime, storyboarderPos, storyboarderPosTwo);

            storyboarder.Move(endTime, endTime + 100, storyboarderPosTwo, storyboarderPosEnd);
        }
    }
}
