using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.OldMan
{
    class OldManStill : INPCState
    {
        private OldMan oldMan;
        private IEnemySprite sprite;


        public OldManStill(OldMan oldMan)
        {
            this.oldMan = oldMan;
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
