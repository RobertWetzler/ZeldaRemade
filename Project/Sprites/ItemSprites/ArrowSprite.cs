using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;


namespace Project.Sprites.ItemSprites
{
    public class ArrowSprite : IItemSprite
    {
      
        IItemSprite itemSprite;

        //Texture, Rows, Columns
        public ArrowSprite()
        {
           

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            itemSprite.Draw(spriteBatch, position);

        }

        public void Update(GameTime gameTime)
        {
           
        }
    }
}
