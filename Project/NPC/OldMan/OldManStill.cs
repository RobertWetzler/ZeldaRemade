using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.OldMan
{
    class OldManStill : INPCState
    {
        private OldMan oldMan;
        private IEnemySprite sprite;


        public OldManStill(OldMan oldMan)
        {
            this.oldMan = oldMan;
            sprite = NPCEnemySpriteFactory.Instance.CreateOldManSprite();
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
