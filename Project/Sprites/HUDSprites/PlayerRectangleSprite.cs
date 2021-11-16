using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.HUDSprites
{
    class PlayerRectangleSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle destRectangle;

        public PlayerRectangleSprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public Rectangle DestRectangle => destRectangle;

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            const int dimension = 10;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, dimension, dimension);
            spriteBatch.Draw(texture, destRectangle, color);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
