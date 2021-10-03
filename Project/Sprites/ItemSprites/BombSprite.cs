using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class BombSprite : IWeaponSprites
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
        public BombSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
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
                    this.position.Y = (int)position.Y - 20;
                    break;
                case Facing.Down:
                    this.position.Y = (int)position.Y + 20;
                    break;
                case Facing.Left:
                    this.position.X = (int)position.X - 20;
                    break;
                case Facing.Right:
                    this.position.X = (int)position.X + 20;
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
            
            if(timer > 3000 && timer < 4000)
                spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 4) % 4;

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
