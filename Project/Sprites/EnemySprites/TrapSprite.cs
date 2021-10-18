using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project
{
    class TrapSprite : ISprite
    {
        private Texture2D spriteSheet;

        public TrapSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height);
            Rectangle destination = new Rectangle(
                (int)position.X, (int)position.Y,
                spriteSheet.Width * 3, spriteSheet.Height * 3);
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
