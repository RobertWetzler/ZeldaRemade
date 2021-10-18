using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;

namespace Project.NPC.Flame
{
    class FlameStatic : INPCState
    {
       
        private ISprite sprite;

        public FlameStatic(Flame flame)
        {

            sprite = NPCSpriteFactory.Instance.CreateEnemyFlameSprite();

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            sprite.Draw(spriteBatch, pos);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            
        }
    }
}
