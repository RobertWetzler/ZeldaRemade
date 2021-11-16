using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.Text
{
    class OldManText : IText
    {
        int shift = 30;     // The space shift between text characters
        int firstLineWordCount = 17;     // Word count of the first line text
        private int startTime = 0;       // Time to start show text
        private int timeToText = 150;    // Time interval between each character showing up
        // The start position of each line
        private int firstLinePosX = 220;
        private int firstLinePosY = 404;
        private int secondLinePosX = 280;
        private int secondLinePosY = 436;
        // Word count
        int textNum = 0;

        private ISprite spriteBlank, spriteA, spriteC, spriteE, spriteH, spriteI, spriteL, spriteM, spriteN, spriteO, spriteP, spriteR, spriteS, spriteT, spriteU;
        private List<ISprite> textList1 = new List<ISprite>();  // first line
        private List<ISprite> textList2 = new List<ISprite>();  // second line

        public OldManText()
        {
            spriteA = TextSpriteFactory.Instance.CreateASprite();
            spriteC = TextSpriteFactory.Instance.CreateCSprite();
            spriteE = TextSpriteFactory.Instance.CreateESprite();
            spriteH = TextSpriteFactory.Instance.CreateHSprite();
            spriteI = TextSpriteFactory.Instance.CreateISprite();
            spriteL = TextSpriteFactory.Instance.CreateLSprite();
            spriteM = TextSpriteFactory.Instance.CreateMSprite();
            spriteN = TextSpriteFactory.Instance.CreateNSprite();
            spriteO = TextSpriteFactory.Instance.CreateOSprite();
            spriteP = TextSpriteFactory.Instance.CreatePSprite();
            spriteR = TextSpriteFactory.Instance.CreateRSprite();
            spriteS = TextSpriteFactory.Instance.CreateSSprite();
            spriteT = TextSpriteFactory.Instance.CreateTSprite();
            spriteU = TextSpriteFactory.Instance.CreateUSprite();
            spriteBlank = TextSpriteFactory.Instance.CreateBlankSprite();

            textList1.Add(spriteE);
        }
        public void Update(GameTime gameTime)
        {
            startTime += gameTime.ElapsedGameTime.Milliseconds;
            if (startTime > timeToText)
            {
                textNum++;
                startTime -= timeToText;
                switch (textNum)
                {
                    case 1:
                        textList1.Add(spriteA);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 2:
                        textList1.Add(spriteS);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 3:
                        textList1.Add(spriteT);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 4:
                        textList1.Add(spriteM);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 5:
                        textList1.Add(spriteO);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 6:
                        textList1.Add(spriteS);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 7:
                        textList1.Add(spriteT);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 8:
                        textList1.Add(spriteBlank);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 9:
                        textList1.Add(spriteP);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 10:
                        textList1.Add(spriteE);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 11:
                        textList1.Add(spriteN);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 12:
                        textList1.Add(spriteI);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 13:
                        textList1.Add(spriteN);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 14:
                        textList1.Add(spriteS);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 15:
                        textList1.Add(spriteU);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 16:
                        textList1.Add(spriteL);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 17:
                        textList1.Add(spriteA);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 18:
                        textList2.Add(spriteI);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 19:
                        textList2.Add(spriteS);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 20:
                        textList2.Add(spriteBlank);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 21:
                        textList2.Add(spriteT);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 22:
                        textList2.Add(spriteH);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 23:
                        textList2.Add(spriteE);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 24:
                        textList2.Add(spriteBlank);
                        break;
                    case 25:
                        textList2.Add(spriteS);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 26:
                        textList2.Add(spriteE);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 27:
                        textList2.Add(spriteC);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 28:
                        textList2.Add(spriteR);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 29:
                        textList2.Add(spriteE);
                        SoundManager.Instance.CreateTextSound();
                        break;
                    case 30:
                        textList2.Add(spriteT);
                        SoundManager.Instance.CreateTextSound();
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int i = 0;
            foreach (var text in textList1)
            {
                text.Draw(spriteBatch, new Vector2(firstLinePosX + i, firstLinePosY));
                i += shift;
            }
            if (textNum > firstLineWordCount)
            {
                i = 0;
                foreach (var text in textList2)
                {

                    text.Draw(spriteBatch, new Vector2(secondLinePosX + i, secondLinePosY));
                    i += shift;
                }
            }
        }
    }
}

