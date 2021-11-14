using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;

namespace Project.Sprites.BackgroundSprites
{
    class BackgroundSprite : IBackgroundSprite
    {
        private Texture2D texture;
        private int spriteRow;
        private int spriteCol;
        private int totalRows;
        private int totalCols;

        public BackgroundSprite(Texture2D texture, int row, int col, int totalRows, int totalCols)
        {
            this.texture = texture;
            spriteCol = col;
            spriteRow = row;
            this.totalCols = totalCols;
            this.totalRows = totalRows;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destRect)
        {
            Draw(spriteBatch, graphics, Vector2.Zero);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, Vector2 offset)
        {
            int width = texture.Width / totalCols;
            int height = texture.Height / totalRows;
            int indexRow = width * spriteCol;
            int indexCol = height * spriteRow;

            if (spriteCol > 0)
            {
                indexRow += spriteCol;
            }
            if (spriteRow > 0)
            {
                indexCol += spriteRow;
            }
            Rectangle source = new Rectangle(indexRow, indexCol, width, height);
            spriteBatch.Draw(texture, destRect, source, Color.White);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
