using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.Merchant
{
    class MerchantStill : INPCState
    {
        private Merchant merchant;
        private IEnemySprite sprite;


        public MerchantStill(Merchant merchant)
        {
            this.merchant = merchant;
            sprite = NPCSpriteFactory.Instance.CreateMerchantSprite();
        }

        public IEnemySprite Sprite => sprite;

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
