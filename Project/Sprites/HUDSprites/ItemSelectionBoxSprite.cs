using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites
{
    class ItemSelectionBoxSprite : ISprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int frame;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public ItemSelectionBoxSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            spriteRow = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            const int scale = 80;

            Rectangle spriteRectangle = new Rectangle(frame * width, spriteRow * height, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, scale, scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            frame = (int)(gameTime.TotalGameTime.TotalSeconds * 10) % 2;

        }
    }
}
