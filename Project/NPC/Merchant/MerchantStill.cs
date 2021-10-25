using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.Merchant
{
    class MerchantStill : INPCState
    {
        private Merchant merchant;
        private ISprite sprite;


        public MerchantStill(Merchant merchant)
        {
            this.merchant = merchant;
            sprite = NPCSpriteFactory.Instance.CreateMerchantSprite();
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
