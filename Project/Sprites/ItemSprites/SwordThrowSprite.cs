using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class SwordThrowSprite : IWeaponSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteFrame;
        private float xPos, yPos;
        private int velocity;


        private bool isFin;

        private float timer;
        private Vector2 position;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;

        public Rectangle DestRectangle => destRectangle;

        //Texture, Rows, Columns
        public SwordThrowSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;
            this.position = position;

            isFin = false;
            velocity = 400;



            switch (facing)
            {
                case Facing.Up:
                    spriteFrame = 3;
                    this.position.Y -= 75;
                    this.position.X -= 32;
                    break;
                case Facing.Down:
                    spriteFrame = 2;
                    this.position.Y += 60;
                    this.position.X -= 25;
                    break;
                case Facing.Left:
                    spriteFrame = 0;
                    this.position.X -= 75;
                    this.position.Y -= 13;
                    break;
                case Facing.Right:
                    spriteFrame = 1;
                    this.position.X += 75;
                    this.position.Y -= 13;
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

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, 0, width, height);
            destRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, width * scale, height * scale);

            if (!isFin)
                spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);

        }

        public void Update(GameTime gameTime)
        {

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > 1000)
                spriteFrame = 4;

            switch (spriteFrame)
            {
                case 3:
                    yPos = -1;
                    break;
                case 2:
                    yPos = 1;
                    break;
                case 0:
                    xPos = -1;
                    break;
                case 1:
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
            return isFin = timer > 1250 ? true : false;
        }
    }
}

