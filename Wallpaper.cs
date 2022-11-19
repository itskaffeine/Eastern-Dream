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
    public class Wallpaper : StoryboardObjectGenerator
    {
        [Configurable]
        public Vector2 endPos = new Vector2(320, 240);
    
        public Vector2 EndCirclePos(double angle, int radius)
        {
            double posX = endPos.X + (radius * Math.Cos(angle));
            double posY = endPos.Y + ((radius*5) * Math.Sin(angle));

            return new Vector2((float)posX, (float)posY);
        }

        public double Opacity = 0.5;


        
        public override void Generate()
        {
            BgSwitch(14, 188911);
		    KiaiSwitch(188911, 235457);
            BgSwitch(235457, 257093);
            MidpointSwitch(286366, 321274);
            BgSwitch(321274, 409455);
            MidpointSwitch(409455, 460427);
            BgSwitch(471557, 538757);
            KiaiSwitch(538757, 589956);
            BgSwitch(589956, 602757);
            EndSwitch(602757, 665623, 200);
        }

        public void BgSwitch(int startTime, int endTime)
        {
            var bg = GetLayer("bg").CreateSprite("sb/bg.jpg", OsbOrigin.Centre);
            
            var bgScale = GetMapsetBitmap("sb/bg.jpg");

            var beatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;

            bg.Scale(startTime, 910.0f / bgScale.Width);
            bg.Fade(startTime - 500, startTime, 0, Opacity);
            bg.Fade(endTime - beatDuration * 2, endTime, Opacity, 0);
        }

        public void KiaiSwitch(int startTime, int endTime)
        {
            var kiaiPos = new Vector2(320, 300);
            var kiai = GetLayer("kiai").CreateSprite("sb/kiai.jpg", OsbOrigin.Centre, kiaiPos);
            var kiaiScale = GetMapsetBitmap("sb/kiai.jpg");

            var flash = GetLayer("flash").CreateSprite("sb/white.png", OsbOrigin.Centre);
            var flashScale = GetMapsetBitmap("sb/white.png");

            var beatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;

            kiai.Scale(startTime, 910.0f / kiaiScale.Width);
            kiai.Fade(startTime, startTime + 500, 0, Opacity);
            kiai.Fade(endTime, endTime + 500, Opacity, 0);

            flash.Scale(startTime, 910.0f / flashScale.Width);
            flash.Fade(startTime, startTime + beatDuration * 4, .8, 0);
        }

        public void MidpointSwitch(int startTime, int endTime)
        {
            var midpointPos = new Vector2(320, 300);
            var midpoint = GetLayer("midpoint").CreateSprite("sb/midpoint.jpg", OsbOrigin.Centre, midpointPos);
            var midpointScale = GetMapsetBitmap("sb/midpoint.jpg");

            var flash = GetLayer("flash").CreateSprite("sb/white.png", OsbOrigin.Centre);
            var flashScale = GetMapsetBitmap("sb/white.png");

            var beatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;

            flash.Scale(startTime, 910.0f / flashScale.Width);

            if (startTime == 286366)
            {
                flash.Fade(startTime, startTime + beatDuration * 4, .8, 0);
            }

            midpoint.Scale(startTime, 910.0f / midpointScale.Width);
            midpoint.Fade(startTime, startTime + 500, 0, Opacity);
            midpoint.Fade(endTime - 500, endTime, Opacity, 0);
        }

        public void EndSwitch(int startTime, int endTime, int Radius)
        {
            var end = GetLayer("end").CreateSprite("sb/end.jpg", OsbOrigin.Centre);
            var endScale = GetMapsetBitmap("sb/end.jpg");

            var flash = GetLayer("flash").CreateSprite("sb/white.png", OsbOrigin.Centre);
            var flashScale = GetMapsetBitmap("sb/white.png");

            var rotation = 15;
            var beatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;

            flash.Scale(startTime, 910.0f / flashScale.Width);
            flash.Fade(startTime, startTime + beatDuration * 4, .8, 0);

            end.Scale(startTime, endTime, 910.0f / endScale.Width, 455.0f / endScale.Width);
            end.Rotate(startTime, endTime, 0, MathHelper.DegreesToRadians(rotation));
            end.Fade(startTime, startTime + 500, 0, Opacity);
            end.Fade(endTime, endTime + 500, Opacity, 0);

            /*
            int rotateTime = endTime - startTime;
            var angleCurrent = 0d;
            var radiusCurrent = 0;   

            for (int i = startTime; i < endTime - rotateTime; i += rotateTime)
            {
                var angle = Random(angleCurrent - Math.PI / 4, angleCurrent + Math.PI /4);
                var radius = Math.Abs(Random(radiusCurrent - Radius / 4, radiusCurrent + Radius /4));

                var start = end.PositionAt(i);
                var finish = EndCirclePos(angle, radius);

                while(radius > Radius)
                {
                    radius = Math.Abs(Random(radiusCurrent - Radius / 4, radiusCurrent + Radius /4));
                }

                if (i + rotateTime >= endTime)
                {
                    end.Move(i, endTime, start, finish);
                }
                else
                {
                    end.Move(i, i + rotateTime, start, finish);
                }

                angleCurrent = angle;
                radiusCurrent = radius;
            }
            */
        }
    }
}
