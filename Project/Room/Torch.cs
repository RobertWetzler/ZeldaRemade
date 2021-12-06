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
  
        public Torch(Vector2 position)
        {
            this.position = position;
            sprite = BackgroundSpriteFactory.Instance.CreateTorchSprite();
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch,position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

      
        
    }
}

