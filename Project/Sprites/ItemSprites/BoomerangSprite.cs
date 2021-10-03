using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class BoomerangSprite : IWeaponSprites
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;

        private int MAX_DISTANCE;
        private int START_DISTANCE;

        private int directionHolder;

        private bool hasLooped;


        private Vector2 position;
        private Facing facing;

        private Texture2D spriteSheet;
        //Texture, Rows, Columns
        public BoomerangSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
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
                    directionHolder = 0;
                    MAX_DISTANCE = (int)position.Y - 250;
                    START_DISTANCE = (int)position.Y - 5;
                    break;
                case Facing.Down:
                    directionHolder = 1;
                    MAX_DISTANCE = (int)position.Y + 250;
                    START_DISTANCE = (int)position.Y + 5;
                    break;
                case Facing.Left:
                    directionHolder = 2;
                    MAX_DISTANCE = (int)position.X - 250;
                    START_DISTANCE = (int)position.X - 5;
                    break;
                case Facing.Right:
                    directionHolder = 3;
                    MAX_DISTANCE = (int)position.X + 250;
                    START_DISTANCE = (int)position.X + 5;
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

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, spriteRow * height, width, height);
            Rectangle destRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public bool isFinished()
        {
            bool isFinished = false;

            if (hasLooped == true && (this.position.X == START_DISTANCE || this.position.Y == START_DISTANCE))
                isFinished = true;

            return isFinished;
        }

        public void Update(GameTime gameTime)
        {

            spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 3) % 3;

            //TOWARDS PLAYER
            if (this.position.X == MAX_DISTANCE || this.position.Y == MAX_DISTANCE || hasLooped)
            {
                hasLooped = true;
                switch (directionHolder)
                {
                    case 0:
                        this.position.Y++;
                        break;
                    case 1:
                        this.position.Y--;
                        break;
                    case 2:
                        this.position.X++;
                        break;
                    case 3:
                        this.position.X--;
                        break;
                    default:
                        break;
                }

            }

            //AWAY FROM PLAYER
            if (hasLooped == false) {

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

        }
    }
}
