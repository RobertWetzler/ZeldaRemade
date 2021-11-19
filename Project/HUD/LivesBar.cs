using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.HUD
{
    class LivesBar  : IHUD
    {
        private ISprite fullHeartSprite, halfHeartSprite, emptyHeartSprite;
        private IPlayer player;
        private IHUD smallHUD;
        private string[] hearts;
        private Vector2 drawPos;
        private int numHearts;

        public LivesBar(IPlayer player, IHUD smallHUD)
        {
            fullHeartSprite = HUDSpriteFactory.Instance.CreateFullHeart();
            halfHeartSprite = HUDSpriteFactory.Instance.CreateHalfHeart();
            emptyHeartSprite = HUDSpriteFactory.Instance.CreateEmptyHeart();
            this.player = player;
            this.smallHUD = smallHUD;
            drawPos = new Vector2(((SmallHUD)smallHUD).TopLeftPosition.X + 700, ((SmallHUD)smallHUD).TopLeftPosition.Y + 150);
            numHearts = player.Health / 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            int offset = 0;
        }

        public void Update()
        {

        }

        
    }
}
