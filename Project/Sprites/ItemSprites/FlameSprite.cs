using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class FlameSprite : IWeaponSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteFrame;
        private int directionHolder;
        private float xPos, yPos;
        private int velocity;

        private bool flipped;
        private bool isFin;

        private float timer;
        private Vector2 position;

        private Texture2D spriteSheet;
        //Texture, Rows, Columns
        public FlameSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;
            this.position = position;

            isFin = false;
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

            Rectangle spriteRectangle = new Rectangle(0, 0, width, height);
            Rectangle destRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, width * scale, height * scale);

            SpriteEffects effect = flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White, 0f, Vector2.Zero, effect, 0f);


        }

        public void Update(GameTime gameTime)
        {
            flipped = spriteFrame == 0;
            spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 6) % 2;
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


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

            this.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * xPos * velocity);
            this.position.Y += (float)(gameTime.ElapsedGameTime.TotalSeconds * yPos * velocity);

        }

        public bool isFinished()
        {
            return isFin = timer > 7000 ? true : false;
        }
    }
}
