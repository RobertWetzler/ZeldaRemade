using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class ArrowSprite : IWeaponSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;
     

        private float timer;


        private Vector2 position;
        private Facing facing;

        private Texture2D spriteSheet;
        //Texture, Rows, Columns
        public ArrowSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            this.facing = facing;
            this.position = position;

            

            spriteRow = 0;


            switch (facing)
            {
                case Facing.Up:
                    spriteFrame = 3;
                    this.position.Y = (int)position.Y - 50;
                    break;
                case Facing.Down:
                    spriteFrame = 2;
                    this.position.Y = (int)position.Y + 50;
                    break;
                case Facing.Left:
                    spriteFrame = 1;
                    this.position.X = (int)position.X - 50;
                    break;
                case Facing.Right:
                    spriteFrame = 0;
                    this.position.X = (int)position.X + 50;
                    break;
                default:
                    break;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            int scale = 3;

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, spriteRow * height, width, height);
            Rectangle destRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > 3500 && timer < 4000)
                spriteFrame = 4;

                switch (spriteFrame)
            {
                case 3:
                    this.position.Y--;
                    break;
                case 2:
                    this.position.Y++;
                    break;
                case 1:
                    this.position.X--;
                    break;
                case 0:
                    this.position.X++;
                    break;
                default:
                    break;
            }

        }

        public bool isFinished()
        {
            bool isFinished = false;

            if (timer > 4000)
                isFinished = true;

            return isFinished;
        }
    }
}

