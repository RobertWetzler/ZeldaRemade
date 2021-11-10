using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.TextSprites
{
    class TextSprite : ISprite 
    {
        private Texture2D fontSpriteSheet;
        private Rectangle destRectangle;
        int spriteX, spriteY;
        public Rectangle DestRectangle => destRectangle;


        public TextSprite(Texture2D fontSpriteSheet, int spriteX, int spriteY)
        {
            this.fontSpriteSheet = fontSpriteSheet;
            this.spriteX = spriteX;
            this.spriteY = spriteY;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            //int width = blockSpriteSheet.Width / sheetColumns;
            //int height = blockSpriteSheet.Height / sheetRows;
            //int scale = 4;

            Rectangle source = new Rectangle(spriteX, spriteY, 7, 7);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, 28, 28);
            spriteBatch.Draw(fontSpriteSheet, destRectangle, source, Color.White);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}