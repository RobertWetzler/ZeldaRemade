using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class BoomerangSprite : IProjectileSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;

        private float timer;
        private bool isFin, flipped;
        private Facing facing;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public BoomerangSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;
            this.facing = facing;
            spriteRow = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            int scale = 4;

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, spriteRow * height, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);

            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);
        }

        public bool IsFinished()
        {
            return isFin = timer > 2500 ? true : false;
        }

        public void Update(GameTime gameTime)
        {
            isFin = timer > 1250 ? true : false;
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 6) % 6;
            flipped = timer > 1250;


        }
    }
}