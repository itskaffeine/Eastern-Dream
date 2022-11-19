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
    public class Curtains : StoryboardObjectGenerator
    {
        public int horizontalBoxRotation = 25;
        public int verticalBoxRotation = 90;
        //Vector2 topBoxPos = new Vector2(320, -75);
        //Vector2 bottomBoxPos = new Vector2(320, 555);

        public override void Generate()
        {
		    Scarlet(461957, 462223, 464356, 464623);
            Sakuya(465157, 465423, 466490, 466756);
            Patchouli(468356, 468623, 469690, 469957);
        }

        public void Scarlet(int startTime, int opentTime, int closeTime, int endTime)
        {
            int scarletOffset = 200;
            var topBoxPos = new Vector2(320 + scarletOffset, -75);
            var bottomBoxPos = new Vector2(320 + scarletOffset, 555);

            var leftBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre);
            var rightBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre);
            var topBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre, topBoxPos);
            var bottomBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre, bottomBoxPos);
            var scarlet = GetLayer("image").CreateSprite("sb/flandre & remilia.jpg", OsbOrigin.Centre);

            var scarletScale = GetMapsetBitmap("sb/flandre & remilia.jpg");
            var boxScale = GetMapsetBitmap("sb/box.jpg");

            var leftBoxClose = new Vector2(150 + scarletOffset, 240);
            var rightBoxClose = new Vector2(490 + scarletOffset, 240);
            var leftBoxOpen = new Vector2(38 + scarletOffset, 240);
            var rightBoxOpen = new Vector2(602 + scarletOffset, 240);

            var scarletPos = new Vector2(310 + scarletOffset, 240);
            var scarletEndPos = new Vector2(330 + scarletOffset, 240);

            scarlet.Fade(startTime, endTime, 1, 1);
            leftBox.Fade(startTime, endTime, 1, 1);
            rightBox.Fade(startTime, endTime, 1, 1);
            topBox.Fade(startTime, endTime, 1, 1);
            bottomBox.Fade(startTime, endTime, 1, 1);

            scarlet.Scale(startTime, 480.0f / scarletScale.Height);
            leftBox.Scale(startTime, 480.0f / boxScale.Height);
            rightBox.Scale(startTime, 480.0f / boxScale.Height);
            topBox.Scale(startTime, 480.0f / boxScale.Height);
            bottomBox.Scale(startTime, 480.0f / boxScale.Height);
            
            leftBox.Rotate(startTime, MathHelper.DegreesToRadians(horizontalBoxRotation));
            rightBox.Rotate(startTime, MathHelper.DegreesToRadians(horizontalBoxRotation));
            topBox.Rotate(startTime, MathHelper.DegreesToRadians(verticalBoxRotation));
            bottomBox.Rotate(startTime, MathHelper.DegreesToRadians(verticalBoxRotation));

            leftBox.Move(OsbEasing.OutCubic, startTime, opentTime, leftBoxClose, leftBoxOpen);
            rightBox.Move(OsbEasing.OutCubic, startTime, opentTime, rightBoxClose, rightBoxOpen);

            leftBox.Move(OsbEasing.OutCubic, closeTime, endTime, leftBoxOpen, leftBoxClose);
            rightBox.Move(OsbEasing.OutCubic, closeTime, endTime, rightBoxOpen, rightBoxClose);

            scarlet.Move(startTime, endTime, scarletPos, scarletEndPos);
        }

        public void Sakuya(int startTime, int opentTime, int closeTime, int endTime)
        {
            int sakuyaOffset = 0;
            var topBoxPos = new Vector2(320 + sakuyaOffset, -75);
            var bottomBoxPos = new Vector2(320 + sakuyaOffset, 555);

            var leftBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre);
            var rightBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre);
            var topBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre, topBoxPos);
            var bottomBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre, bottomBoxPos);
            var sakuya = GetLayer("image").CreateSprite("sb/sakuya.jpg", OsbOrigin.Centre);

            var sakuyaScale = GetMapsetBitmap("sb/sakuya.jpg");
            var boxScale = GetMapsetBitmap("sb/box.jpg");

            var leftBoxClose = new Vector2(150 + sakuyaOffset, 240);
            var rightBoxClose = new Vector2(490 + sakuyaOffset, 240);
            var leftBoxOpen = new Vector2(38 + sakuyaOffset, 240);
            var rightBoxOpen = new Vector2(602 + sakuyaOffset, 240);

            var sakuyaPos = new Vector2(310 + sakuyaOffset, 330);
            var sakuyaEndPos = new Vector2(330 + sakuyaOffset, 330);

            sakuya.Fade(startTime, endTime, 1, 1);
            leftBox.Fade(startTime, endTime, 1, 1);
            rightBox.Fade(startTime, endTime, 1, 1);
            topBox.Fade(startTime, endTime, 1, 1);
            bottomBox.Fade(startTime, endTime, 1, 1);

            sakuya.Scale(startTime, 480.0f / sakuyaScale.Height);
            leftBox.Scale(startTime, 480.0f / boxScale.Height);
            rightBox.Scale(startTime, 480.0f / boxScale.Height);
            topBox.Scale(startTime, 480.0f / boxScale.Height);
            bottomBox.Scale(startTime, 480.0f / boxScale.Height);

            leftBox.Rotate(startTime, MathHelper.DegreesToRadians(-horizontalBoxRotation));
            rightBox.Rotate(startTime, MathHelper.DegreesToRadians(-horizontalBoxRotation));
            topBox.Rotate(startTime, MathHelper.DegreesToRadians(verticalBoxRotation));
            bottomBox.Rotate(startTime, MathHelper.DegreesToRadians(verticalBoxRotation));

            leftBox.Move(OsbEasing.OutCubic, startTime, opentTime, leftBoxClose, leftBoxOpen);
            rightBox.Move(OsbEasing.OutCubic, startTime, opentTime, rightBoxClose, rightBoxOpen);

            leftBox.Move(OsbEasing.OutCubic, closeTime, endTime, leftBoxOpen, leftBoxClose);
            rightBox.Move(OsbEasing.OutCubic, closeTime, endTime, rightBoxOpen, rightBoxClose);

            sakuya.Move(startTime, endTime, sakuyaPos, sakuyaEndPos);
        }

        public void Patchouli(int startTime, int opentTime, int closeTime, int endTime)
        {
            int patchouliOffset = -200;
            var topBoxPos = new Vector2(320 + patchouliOffset, -75);
            var bottomBoxPos = new Vector2(320 + patchouliOffset, 555);

            var leftBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre);
            var rightBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre);
            var topBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre, topBoxPos);
            var bottomBox = GetLayer("curtain").CreateSprite("sb/box.jpg", OsbOrigin.Centre, bottomBoxPos);
            var patchouli = GetLayer("image").CreateSprite("sb/patchouli.jpg", OsbOrigin.Centre);

            var patchouliScale = GetMapsetBitmap("sb/patchouli.jpg");
            var boxScale = GetMapsetBitmap("sb/box.jpg");

            var leftBoxClose = new Vector2(150 + patchouliOffset, 240);
            var rightBoxClose = new Vector2(490 + patchouliOffset, 240);
            var leftBoxOpen = new Vector2(38 + patchouliOffset, 240);
            var rightBoxOpen = new Vector2(602 + patchouliOffset, 240);

            var patchouliPos = new Vector2(310 + patchouliOffset, 260);
            var patchouliEndPos = new Vector2(330 + patchouliOffset, 260);

            patchouli.Fade(startTime, endTime, 1, 1);
            leftBox.Fade(startTime, endTime, 1, 1);
            rightBox.Fade(startTime, endTime, 1, 1);
            topBox.Fade(startTime, endTime, 1, 1);
            bottomBox.Fade(startTime, endTime, 1, 1);

            patchouli.Scale(startTime, 480.0f / patchouliScale.Height);
            leftBox.Scale(startTime, 480.0f / boxScale.Height);
            rightBox.Scale(startTime, 480.0f / boxScale.Height);
            topBox.Scale(startTime, 480.0f / boxScale.Height);
            bottomBox.Scale(startTime, 480.0f / boxScale.Height);

            leftBox.Rotate(startTime, MathHelper.DegreesToRadians(horizontalBoxRotation));
            rightBox.Rotate(startTime, MathHelper.DegreesToRadians(horizontalBoxRotation));
            topBox.Rotate(startTime, MathHelper.DegreesToRadians(verticalBoxRotation));
            bottomBox.Rotate(startTime, MathHelper.DegreesToRadians(verticalBoxRotation));

            leftBox.Move(OsbEasing.OutCubic, startTime, opentTime, leftBoxClose, leftBoxOpen);
            rightBox.Move(OsbEasing.OutCubic, startTime, opentTime, rightBoxClose, rightBoxOpen);

            leftBox.Move(OsbEasing.OutCubic, closeTime, endTime, leftBoxOpen, leftBoxClose);
            rightBox.Move(OsbEasing.OutCubic, closeTime, endTime, rightBoxOpen, rightBoxClose);

            patchouli.Move(startTime, endTime, patchouliPos, patchouliEndPos);
        }
    }
}
