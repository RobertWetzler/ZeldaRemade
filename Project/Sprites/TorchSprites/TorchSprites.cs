using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Utilities;

namespace Project.Sprites
{
    public class TorchSprite : ISprite
    {
        private Texture2D texture;
        private Texture2D maskTexture;
        private Rectangle sourceRect;
        private Rectangle destRectangle;
        private int width;
        private int height;
        private const int scale = 4;
        private Vector2 position;

        public Rectangle DestRectangle => destRectangle;
        public TorchSprite()
        {
            this.texture = texture;
            this.maskTexture = maskTexture;
            this.position = position;
            width = texture.Width / numColumns;
            height = texture.Height / numRows;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            int offset = 0;
            

            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, destRectangle, sourceRect, color);
        }

        public void DrawForeground(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(maskTexture, destRectangle, sourceRect, color);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
