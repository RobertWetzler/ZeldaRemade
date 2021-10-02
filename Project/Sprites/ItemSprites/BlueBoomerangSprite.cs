using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project.Sprites.ItemSprites
{
    class BlueBoomerangSprite : IItemSprite
    {
        private int sheetRows;
        private int sheetColumns;
        private int spriteRow;
        private int spriteColumn;

        private Texture2D spriteSheet;
        //Texture, Rows, Columns
        public BlueBoomerangSprite(Texture2D spriteSheet, int sheetRows, int sheetColumns)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
         
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
