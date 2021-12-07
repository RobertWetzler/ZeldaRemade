using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;

namespace Project.Sprites.BackgroundSprites
{
    class TitleScreenSprite : IBackgroundSprite
    {
        private const int TOTAL_MS = 500;
        private Texture2D texture;
        private int spriteRow;
        private int spriteCol;
        private int totalRows;
        private int totalCols;
        private int time;

        public TitleScreenSprite(Texture2D texture, int row, int col, int totalRows, int totalCols)
        {
            this.texture = texture;
            spriteCol = col;
            spriteRow = row;
            this.totalCols = totalCols;
            this.totalRows = totalRows;
            time = 0;
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

        public void Update(GameTime gameTime)
        {
            time += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time > TOTAL_MS)
            {
                time -= TOTAL_MS;
                spriteCol = (spriteCol + 1) % (totalCols - 1);
            }
        }
    }
}
