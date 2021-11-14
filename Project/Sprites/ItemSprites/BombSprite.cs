using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Projectiles;

namespace Project.Sprites.ItemSprites
{
    class BombSprite : IWeaponSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteFrame;
        private float timer;
        private bool isFin;
       

        private Vector2 position;
        private Facing facing;

        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;

        //Texture, Rows, Columns
        public BombSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing, Vector2 position)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;

            this.facing = facing;
            this.position = position;

            spriteRow = 0;
            isFin = false;



            switch (facing)
            {
                case Facing.Up:
                    this.position.Y -= 50;
                    break;
                case Facing.Down:
                    this.position.Y += 50;
                    break;
                case Facing.Left:
                    this.position.X -= 50;
                    break;
                case Facing.Right:
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

            if (timer > 3000 && timer < 4000) { 
                spriteFrame = (int)(gameTime.TotalGameTime.TotalSeconds * 3) % 3 + 1;

        }

        public bool isFinished()
        {
            return isFin = timer > 3500 ? true : false;
        }

        

    }
}
