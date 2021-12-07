using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Shading;

namespace Project 
{
    public class Torch: TorchLight, ICollidable
    {
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Block;
        private ISprite sprite;
        private Vector2 position;

        public Torch(Vector2 position, bool flipped, bool isHorizontal)
        {
            int mult = flipped ? -1 : 1;
            int lightOfssetMag = 10;
            this.position = position;
            if(isHorizontal)
            {
                sprite = BlockSpriteFactory.Instance.CreateEastWestTorchSprite(flipped);
                lightOffset = new Vector2(lightOfssetMag * mult, 0);
            }
            else
            {
                sprite = BlockSpriteFactory.Instance.CreateNorthSouthTorchSprite(flipped);
                lightOffset = new Vector2(0, -lightOfssetMag * mult);
            }
            lightScale = 1.3f;
            lightIntensity = 0.7f;
            innerLightIntensity = 10f;
            innerLightScale = .9f;
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
