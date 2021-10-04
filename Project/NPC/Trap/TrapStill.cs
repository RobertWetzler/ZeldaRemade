using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.Trap
{
    class TrapStill : INPCState
    {
        private Trap trap;
        private IEnemySprite sprite;


        public TrapStill(Trap trap)
        {
            this.trap = trap;
            sprite = NPCSpriteFactory.Instance.CreateOldManSprite();
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }
        public void Update()
        {

        }
    }
}
