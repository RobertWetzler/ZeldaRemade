using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Project.Sprites.TextSprites;
using Project.Factory;

namespace Project.Text
{
    class OldManText:IText
    {
        //private int timeToText, startTime; //Test
        private int startPosX, startPosY;
        private Game1 game;
        private ISprite spriteA, spriteC,spriteE, spriteH, spriteI, spriteM, spriteN, spriteO, spriteP, spriteR, spriteS, spriteT, spriteU;
        //private List<ISprite> textList = new List<ISprite>();
        public OldManText(Game1 game)
        {
            this.game = game;
            //startPos =  new Vector2(200, 200);
            startPosX = 200;
            startPosY = 200;

            //startTime = 0;
            //timeToText = 50;

            spriteA = TextSpriteFactory.Instance.CreateASprite();
            spriteC = TextSpriteFactory.Instance.CreateCSprite();
            spriteE = TextSpriteFactory.Instance.CreateESprite();
            spriteH = TextSpriteFactory.Instance.CreateHSprite();
            spriteI = TextSpriteFactory.Instance.CreateISprite();
            spriteM = TextSpriteFactory.Instance.CreateMSprite();
            spriteN = TextSpriteFactory.Instance.CreateNSprite();
            spriteO = TextSpriteFactory.Instance.CreateOSprite();
            spriteP = TextSpriteFactory.Instance.CreatePSprite();
            spriteR = TextSpriteFactory.Instance.CreateRSprite();
            spriteS = TextSpriteFactory.Instance.CreateSSprite();
            spriteT = TextSpriteFactory.Instance.CreateTSprite();
            spriteU = TextSpriteFactory.Instance.CreateUSprite();

            //textList.Add(spriteE);
            //textList.Add(spriteA);
            //textList.Add(spriteS);
            //textList.Add(spriteT);
            //textList.Add(spriteP);
            //textList.Add(spriteE);

        }
        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            /*
            startTime += gameTime.ElapsedGameTime.Milliseconds;
            if (startTime > timeToText)
            {
                startTime -= timeToText;
                spriteE.Draw(spriteBatch, this.);
            }*/
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteE.Draw(spriteBatch, new Vector2(startPosX, startPosY));
            spriteA.Draw(spriteBatch, new Vector2(startPosX+30, startPosY));
            spriteS.Draw(spriteBatch, new Vector2(startPosX+60, startPosY));
            spriteT.Draw(spriteBatch, new Vector2(startPosX+90, startPosY));
            spriteM.Draw(spriteBatch, new Vector2(startPosX+120, startPosY));
            spriteO.Draw(spriteBatch, new Vector2(startPosX + 150, startPosY));
            spriteS.Draw(spriteBatch, new Vector2(startPosX + 180, startPosY));
            spriteT.Draw(spriteBatch, new Vector2(startPosX + 210, startPosY));
            spriteP.Draw(spriteBatch, new Vector2(startPosX+270, startPosY));
            spriteE.Draw(spriteBatch, new Vector2(startPosX+300, startPosY));
        }
    }
}
