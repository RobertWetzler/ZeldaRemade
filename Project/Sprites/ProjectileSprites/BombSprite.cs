using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class BombSprite : IProjectileSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;
        private float timer;
        private bool isFin;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public BombSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;
       

            spriteRow = 0;
            isFin = false;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            int scale = 3;

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, spriteRow * height, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > 3000 && timer < 4000)
                spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 3) % 3 + 1;

        }

        public bool IsFinished()
        {
            return isFin = timer > 3500 ? true : false;
        }
    }
}
