using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class BlueBoomerangSprite : IWeaponSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;
        private int xPos, yPos;
        private int velocity;

        private int directionHolder;
        private float timer;
        private bool isFin;

        private Vector2 position;
        private Facing facing;

        private Texture2D spriteSheet;
        //Texture, Rows, Columns
        public BlueBoomerangSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            this.facing = facing;
            this.position = position;



            spriteRow = 0;
            velocity = 200;

            switch (facing)
            {
                case Facing.Up:
                    directionHolder = 0;
                    this.position.Y -= 50;
                    break;
                case Facing.Down:
                    directionHolder = 1;
                    this.position.Y += 50;
                    break;
                case Facing.Left:
                    directionHolder = 2;
                    this.position.X -= 50;
                    break;
                case Facing.Right:
                    directionHolder = 3;
                    this.position.X += 50;
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
            return isFin = timer > 6000 ? true : false;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 6) % 6;

            //TOWARDS PLAYER
            if (timer > 3000)
            {

                switch (directionHolder)
                {
                    case 0:
                        yPos = 1;
                        break;
                    case 1:
                        yPos = -1;
                        break;
                    case 2:
                        xPos = 1;
                        break;
                    case 3:
                        xPos = -1;
                        break;
                    default:
                        break;
                }

            }

            //AWAY FROM PLAYER
            if (timer < 3000)
            {

                switch (directionHolder)
                {
                    case 0:
                        yPos = -1;
                        break;
                    case 1:
                        yPos = 1;
                        break;
                    case 2:
                        xPos = -1;
                        break;
                    case 3:
                        xPos = 1;
                        break;
                    default:
                        break;
                }

            }

            this.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * xPos * velocity);
            this.position.Y += (float)(gameTime.ElapsedGameTime.TotalSeconds * yPos * velocity);

        }
    }
}
