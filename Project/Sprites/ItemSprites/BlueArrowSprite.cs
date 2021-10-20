using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class BlueArrowSprite : IWeaponSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;
        private float xPos, yPos;
        private int velocity;

        private bool isFin;
        private float timer;

        private Vector2 position;
        private Facing facing;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        //Texture, Rows, Columns
        public BlueArrowSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            this.facing = facing;
            this.position = position;
            

            spriteRow = 0;
            isFin = false;
            velocity = 200;


            switch (facing)
            {
                case Facing.Up:
                    spriteFrame = 2;
                    this.position.Y -= 50;
                    break;
                case Facing.Down:
                    spriteFrame = 3;
                    this.position.Y += 50;
                    break;
                case Facing.Left:
                    spriteFrame = 1;
                    this.position.X -= 50;
                    break;
                case Facing.Right:
                    spriteFrame = 0;
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
            int scale = 3;

            

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, spriteRow * height, width, height);
            destRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, width * scale, height * scale);
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > 2500 && timer < 3000)
                spriteFrame = 4;

            switch (spriteFrame)
            {
                case 2:
                    yPos = -1;
                    break;
                case 3:
                    yPos = 1;
                    break;
                case 1:
                    xPos = -1;
                    break;
                case 0:
                    xPos = 1;
                    break;
                case 4:
                    xPos = 0;
                    yPos = 0;
                    break;
                default:
                    break;
            }

            this.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * xPos * velocity);
            this.position.Y += (float)(gameTime.ElapsedGameTime.TotalSeconds * yPos * velocity);

        }

        public bool isFinished()
        { 
            return isFin = timer > 3000 ? true : false;
        }
    }
}
