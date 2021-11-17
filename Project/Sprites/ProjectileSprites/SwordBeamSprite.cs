using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class SwordBeamSprite : IProjectileSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteColumn;
        private int spriteFrame;
        private bool isFin;
        private float timer;
        private Texture2D spriteSheet;
        private Rectangle destRectangle;
        private bool flipped;
        private SpriteEffects effects;
        private Facing facing;

        public Rectangle DestRectangle => destRectangle;

        //Texture, Rows, Columns
        public SwordBeamSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns, Facing facing)
        {
            this.spriteSheet = spriteSheet;
            this.sheetColumns = sheetColumns;
            this.sheetRows = sheetRows;
            this.facing = facing;
            isFin = false;

            switch (this.facing)
            {
                case Facing.Up:
                    spriteFrame = 0;
                    flipped = false;
                    break;
                case Facing.Down:
                    spriteFrame = 0;
                    flipped = true;
                    break;
                case Facing.Right:
                    spriteFrame = 1;
                    flipped = false;
                    break;
                case Facing.Left:
                    spriteFrame = 1;
                    flipped = true;
                    break;
            }


        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = spriteSheet.Width / sheetColumns;
            int height = spriteSheet.Height / sheetRows;
            int scale = 4;

            Rectangle spriteRectangle = new Rectangle(spriteFrame * width, spriteColumn * height, width, height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);

            spriteBatch.Draw(spriteSheet, destRectangle, spriteRectangle, Color.White, 0f, Vector2.Zero, effects, 0f);

        }

        public void Update(GameTime gameTime)
        {
            spriteColumn = (int)(gameTime.TotalGameTime.TotalSeconds * 20) % 4;
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            effects = Flip();
        }

        public bool IsFinished()
        {
            return isFin = timer > 1250 ? true : false;
        }

        public SpriteEffects Flip()
        {
            if (spriteFrame == 1)
                effects = flipped && spriteFrame == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            if (spriteFrame == 0)
                effects = flipped && spriteFrame == 0 ? SpriteEffects.FlipVertically : SpriteEffects.None;

            return effects;
        }


    }
}

