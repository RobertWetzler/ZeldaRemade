using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.Text
{
    class NumberItemsText : IText
    {
        private ISprite spriteX, sprite0, sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9;
        private int num;
        private Vector2 startPosition, firstDigitPosition, secondDigitPosition;
        private const int SHIFT = 30;

        public int Number { get => num; set => num = value; }
        public Vector2 StartPosition { get => startPosition; set => startPosition = value; }
        public NumberItemsText(int number, Vector2 startPosition)
        {
            this.num = number;
            this.startPosition = startPosition;
            firstDigitPosition = new Vector2(startPosition.X + SHIFT, startPosition.Y);
            secondDigitPosition = new Vector2(startPosition.X + 2 * SHIFT, startPosition.Y);
            spriteX = TextSpriteFactory.Instance.CreateXSprite();
            sprite0 = TextSpriteFactory.Instance.Create0Sprite();
            sprite1 = TextSpriteFactory.Instance.Create1Sprite();
            sprite2 = TextSpriteFactory.Instance.Create2Sprite();
            sprite3 = TextSpriteFactory.Instance.Create3Sprite();
            sprite4 = TextSpriteFactory.Instance.Create4Sprite();
            sprite5 = TextSpriteFactory.Instance.Create5Sprite();
            sprite6 = TextSpriteFactory.Instance.Create6Sprite();
            sprite7 = TextSpriteFactory.Instance.Create7Sprite();
            sprite8 = TextSpriteFactory.Instance.Create8Sprite();
            sprite9 = TextSpriteFactory.Instance.Create9Sprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteX.Draw(spriteBatch, startPosition);
            if (num < 10)
            {
                sprite0.Draw(spriteBatch, firstDigitPosition);
                DrawSpriteNumber(spriteBatch, num, secondDigitPosition);
            }
            else
            {
                int temp = num;
                int lastDigit = temp % 10;
                temp /= 10;
                int firstDigit = temp % 10;
                DrawSpriteNumber(spriteBatch, firstDigit, firstDigitPosition);
                DrawSpriteNumber(spriteBatch, lastDigit, secondDigitPosition);
            }
        }

        public void Update(GameTime gameTime)
        {
        }

        private void DrawSpriteNumber(SpriteBatch spriteBatch, int number, Vector2 pos)
        {
            switch (number)
            {
                case 0:
                    sprite0.Draw(spriteBatch, pos);
                    break;
                case 1:
                    sprite1.Draw(spriteBatch, pos);
                    break;
                case 2:
                    sprite2.Draw(spriteBatch, pos);
                    break;
                case 3:
                    sprite3.Draw(spriteBatch, pos);
                    break;
                case 4:
                    sprite4.Draw(spriteBatch, pos);
                    break;
                case 5:
                    sprite5.Draw(spriteBatch, pos);
                    break;
                case 6:
                    sprite6.Draw(spriteBatch, pos);
                    break;
                case 7:
                    sprite7.Draw(spriteBatch, pos);
                    break;
                case 8:
                    sprite8.Draw(spriteBatch, pos);
                    break;
                case 9:
                    sprite9.Draw(spriteBatch, pos);
                    break;
            }
        }
    }
}
