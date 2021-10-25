using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.OldMan
{
    class OldManStill : INPCState
    {
        private OldMan oldMan;
        private ISprite sprite;


        public OldManStill(OldMan oldMan)
        {
            this.oldMan = oldMan;
            sprite = NPCSpriteFactory.Instance.CreateOldManSprite();
        }
        public ISprite Sprite => sprite;
        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            sprite.Draw(spriteBatch, pos);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
