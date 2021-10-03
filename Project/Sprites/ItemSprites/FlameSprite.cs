using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class FlameSprite : IWeaponSprites
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteColumn;
        private int spriteFrame;
        private int MAX_DISTANCE;
        private int directionHolder;


        private Vector2 position;
        private Facing facing;

        private Texture2D spriteSheet;
        //Texture, Rows, Columns
        public FlameSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            this.facing = facing;
            this.position = position;

            spriteColumn = 0;


            switch (facing)
            {
                case Facing.Up:
                    directionHolder = 0;
                    this.position.Y = (int)position.Y - 20;
                    MAX_DISTANCE = (int)position.Y - 600;
                    break;
                case Facing.Down:
                    directionHolder = 1;
                    this.position.Y = (int)position.Y + 20;
                    MAX_DISTANCE = (int)position.Y + 600;
                    break;
                case Facing.Left:
                    directionHolder = 2;
                    this.position.X = (int)position.X - 20;
                    MAX_DISTANCE = (int)position.X - 600;
                    break;
                case Facing.Right:
                    directionHolder = 3;
                    this.position.X = (int)position.X + 20;
                    MAX_DISTANCE = (int)position.X + 600;
                    break;
                default:
                    break;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            int scale = 4;

            Rectangle spriteRectangle = new Rectangle(spriteColumn * width, spriteFrame * height, width, height);
            Rectangle destRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
            spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 2) % 2;
            
            switch (directionHolder)
            {
                case 0:
                    this.position.Y--;
                    break;
                case 1:
                    this.position.Y++;
                    break;
                case 2:
                    this.position.X--;
                    break;
                case 3:
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
