using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;

namespace Project.NPC.Flame
{
    class FlameStatic : INPCState
    {
        private Flame flame;
        private IEnemySprite sprite;

        public FlameStatic(Flame flame)
        {
            this.flame = flame;
            sprite = NPCSpriteFactory.Instance.CreateEnemyFlameSprite();

        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            
        }
    }
}
