using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Sprites;
using Project.Utilities;

namespace Project 
{
    public class Torch
    {
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Block;
        private ISprite sprite;
        private Vector2 position;

        public Torch(Vector2 position, bool flipped, bool isHorizontal)
        {
            this.position = position;
            if(isHorizontal)
            {
                sprite = BlockSpriteFactory.Instance.CreateEastWestTorchSprite(flipped);
            }
            else
            {
                sprite = BlockSpriteFactory.Instance.CreateNorthSouthTorchSprite(flipped);
            }
           

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
