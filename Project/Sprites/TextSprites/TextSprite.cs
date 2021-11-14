using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.TextSprites
{
    class TextSprite : ISprite 
    {
        private int srcSquareSize = 7;  // Side length of the sqaure of source sprite
        private int destSquareSzie = 28;    // Side length of the sqaure of destination position
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
            Rectangle source = new Rectangle(spriteX, spriteY, srcSquareSize, srcSquareSize);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, destSquareSzie, destSquareSzie);
            spriteBatch.Draw(fontSpriteSheet, destRectangle, source, Color.White);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
