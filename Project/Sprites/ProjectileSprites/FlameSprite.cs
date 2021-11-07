using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class FlameSprite : IProjectileSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteFrame;
        private bool flipped;
        private bool isFin;
        private float timer;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public FlameSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            isFin = false;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            int scale = 4;

            Rectangle spriteRectangle = new Rectangle(0, 0, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);

            SpriteEffects effect = flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White, 0f, Vector2.Zero, effect, 0f);


        }

        public void Update(GameTime gameTime)
        {
            flipped = spriteFrame == 0;
            spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 6) % 2;
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        }

        public bool IsFinished()
        {
            return isFin = timer > 1000 ? true : false;
        }
    }
}
