using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project
{
    class TrapSprite : ISprite
    {
        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public TrapSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height);
            destRectangle = new Rectangle(
           (int)position.X, (int)position.Y,
                spriteSheet.Width * 4, spriteSheet.Height * 4);
            spriteBatch.Draw(spriteSheet, destRectangle, source, Color.White);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
