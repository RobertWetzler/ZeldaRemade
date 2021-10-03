using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class ArrowSprite : IWeaponSprites
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;
        private int MAX_DISTANCE;


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
                    MAX_DISTANCE = (int)position.Y - 200;
                    break;
                case Facing.Down:
                    spriteFrame = 2;
                    MAX_DISTANCE = (int)position.Y + 200;
                    break;
                case Facing.Left:
                    spriteFrame = 1;
                    MAX_DISTANCE = (int)position.X - 200;
                    break;
                case Facing.Right:
                    spriteFrame = 0;
                    MAX_DISTANCE = (int)position.X + 200;
                    break;
                default:
                    break;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            int scale = 2;

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, spriteRow * height, width, height);
            Rectangle destRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
            if (this.position.X == MAX_DISTANCE || this.position.Y == MAX_DISTANCE)
            {
                spriteFrame = 4;

            }

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

            if (this.position.X == MAX_DISTANCE || this.position.Y == MAX_DISTANCE)
                isFinished = true;

            return isFinished;
        }
    }
}

