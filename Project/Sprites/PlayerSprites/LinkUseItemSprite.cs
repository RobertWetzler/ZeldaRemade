using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System.Collections.Generic;

namespace Project.Sprites.PlayerSprites
{
    public class LinkUseItemSprite : IPlayerSprite
    {
        private Texture2D useItemSpriteSheet, idleSpriteSheet;
        private int sheetRows, spriteRow, spriteOneColumn, spriteTwoColumn;
        private List<(int spriteW, int totalW)> frameWidth;
        private bool facingLeft;
        private int timeSinceLastFrame = 0;
        private int millisecondPerFrame = 150;     //frequency of animation
        private int currentSheet = 1;
        private bool cycleOnce;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;

        public LinkUseItemSprite(Texture2D useItemSpriteSheet, Texture2D idleSpriteSheet, Facing facing)
        {
            this.useItemSpriteSheet = useItemSpriteSheet;
            this.idleSpriteSheet = idleSpriteSheet;
            sheetRows = 1;
            spriteRow = 0;
            facingLeft = false;
            cycleOnce = false;

            switch (facing)
            {
                case Facing.Up:
                    spriteOneColumn = 2;
                    spriteTwoColumn = 5;
                    break;
                case Facing.Down:
                    spriteOneColumn = 0;
                    spriteTwoColumn = 0;
                    break;
                case Facing.Left:
                    spriteOneColumn = 1;
                    spriteTwoColumn = 2;
                    facingLeft = true;
                    break;
                default:    //facing right
                    spriteOneColumn = 1;
                    spriteTwoColumn = 2;
                    break;
            }

            frameWidth = new List<(int w, int s)>();
            frameWidth.Add((16, 0));
            frameWidth.Add((16, 17));
            frameWidth.Add((16, 34));
            frameWidth.Add((16, 51));
            frameWidth.Add((16, 68));
            frameWidth.Add((16, 85));
        }

        public bool IsFinished
        {
            get
            {
                return cycleOnce;
            }
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondPerFrame)
            {
                currentSheet = 2;
                cycleOnce = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int scale = 4;
            if (currentSheet == 1)
            {
                int width = frameWidth[spriteOneColumn].spriteW;
                int height = useItemSpriteSheet.Height / sheetRows;
                Rectangle source = new Rectangle(frameWidth[spriteOneColumn].totalW, spriteRow * height, width, height);
                destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
                if (facingLeft)
                    spriteBatch.Draw(useItemSpriteSheet, destRectangle, source, color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                else
                    spriteBatch.Draw(useItemSpriteSheet, destRectangle, source, color);
            }
            else
            {
                int width = frameWidth[spriteTwoColumn].spriteW;
                int height = idleSpriteSheet.Height / sheetRows;
                Rectangle source = new Rectangle(frameWidth[spriteTwoColumn].totalW, spriteRow * height, width, height);
                destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
                if (facingLeft)
                    spriteBatch.Draw(idleSpriteSheet, destRectangle, source, color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                else
                    spriteBatch.Draw(idleSpriteSheet, destRectangle, source, color);
            }
        }
    }
}
