using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites
{
    class TorchSprite : ISprite
    {
        private int sheetColumns;
        private int frame;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public TorchSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height;
            int scale = 4;


            Rectangle spriteRectangle = new Rectangle(frame* width, 0, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height*scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
            frame = (int)(gameTime.TotalGameTime.TotalSeconds * 24) % 6;
        }
    }
}
