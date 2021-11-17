using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class BlueArrowSprite : IProjectileSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;
        private float xPos, yPos;
        private int velocity;

        private bool isFin;
        private float timer;

        private Facing facing;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public BlueArrowSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            spriteRow = 0;
            isFin = false;
            velocity = 400;

            switch (facing)
            {
                case Facing.Up:
                    spriteFrame = 2;
                    break;
                case Facing.Down:
                    spriteFrame = 3;
                    break;
                case Facing.Left:
                    spriteFrame = 1;
                    break;
                case Facing.Right:
                    spriteFrame = 0;
                    break;
                default:
                    break;
            }


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

            if (timer > 1500 && timer < 2000)
                spriteFrame = 4;

        }

        public bool IsFinished()
        {
            return isFin = timer > 2000 ? true : false;
        }


    }
}
