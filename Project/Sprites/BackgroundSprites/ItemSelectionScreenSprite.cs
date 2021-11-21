using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.BackgroundSprites;

namespace Project.Sprites
{
    class ItemSelectionScreenSprite : IBackgroundSprite
    {
        private Texture2D texture;

        private int spriteRow;
        private int spriteCol;
        private int totalRows;
        private int totalCols;

        public ItemSelectionScreenSprite(Texture2D texture, int row, int col, int totalRows, int totalCols)
        {
            this.texture = texture;
            spriteCol = col;
            spriteRow = row;
            this.totalCols = totalCols;
            this.totalRows = totalRows;
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle destRect)
        {
            int width = texture.Width / totalCols;
            int height = texture.Height / totalRows;
            int indexRow = width * spriteCol;
            int indexCol = height * spriteRow;

            Rectangle source = new Rectangle(indexRow, indexCol, width, height);
            spriteBatch.Draw(texture, destRect, source, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle destRect, Vector2 offset)
        {
            Rectangle offsetRect = new Rectangle(destRect.X + (int)offset.X, destRect.Y + (int)offset.Y, destRect.Width, destRect.Height);
            Draw(spriteBatch, offsetRect);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
