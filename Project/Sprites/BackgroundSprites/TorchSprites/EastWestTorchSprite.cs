using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites
{
    class EastWestTorchSprite : ISprite
    {
        private int sheetRows;
        private int frame;
        private bool flipped;
        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public EastWestTorchSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, bool flipped)
        {
            this.flipped = flipped;
            this.spriteSheet = spriteSheet;
            this.sheetRows = sheetRows;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int width = spriteSheet.Width;
            int height = spriteSheet.Height / sheetRows;
            int scale = 2;


            Rectangle spriteRectangle = new Rectangle(0, height * frame, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            SpriteEffects effect = flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White, 0f, Vector2.Zero, effect, 0f);

        }

        public void Update(GameTime gameTime)
        {
            frame = (int)(gameTime.TotalGameTime.TotalSeconds * 24) % 6;
        }
    }
}
