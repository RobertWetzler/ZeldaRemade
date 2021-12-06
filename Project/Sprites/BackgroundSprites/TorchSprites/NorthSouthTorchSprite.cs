using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites
{
    class NorthSouthTorchSprite : ISprite
    {
        private int sheetColumns;
        private int frame;
        private bool flipped;
        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public NorthSouthTorchSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, bool flipped)
        {
            this.flipped = flipped;
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height;
            int scale = 2;


            Rectangle spriteRectangle = new Rectangle(frame * width, 0, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            SpriteEffects effect = flipped ? SpriteEffects.FlipVertically : SpriteEffects.None;
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White, 0f, Vector2.Zero, effect, 0f);

        }

        public void Update(GameTime gameTime)
        {
            frame = (int)(gameTime.TotalGameTime.TotalSeconds * 24) % 6;
        }
    }
}
