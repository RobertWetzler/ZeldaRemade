using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Utilities;

namespace Project.Sprites
{
    class EasyButtonSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        private int frame;
        public Rectangle DestRectangle => destRectangle;
        public EasyButtonSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            const int columns = 2;
            int width = spriteSheet.Width/ columns;
            int height = spriteSheet.Height;
            const int scale = 1;

            if(GameOptions.IsHarderVersion)
            {
                frame = 0;
            }
    
            Rectangle spriteRectangle = new Rectangle(width * frame, 0, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            
            frame = (int)(gameTime.TotalGameTime.TotalSeconds * 10) % 2;
        }
    }
}
