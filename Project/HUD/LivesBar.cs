using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.HUD
{
    class LivesBar : IHUD
    {
        private ISprite fullHeartSprite, halfHeartSprite, emptyHeartSprite;
        private IPlayer player;
        private List<string> hearts;
        private Vector2 drawPos;

        public LivesBar(IPlayer player, IHUD smallHUD)
        {
            fullHeartSprite = HUDSpriteFactory.Instance.CreateFullHeart();
            halfHeartSprite = HUDSpriteFactory.Instance.CreateHalfHeart();
            emptyHeartSprite = HUDSpriteFactory.Instance.CreateEmptyHeart();
            this.player = player;
            drawPos = new Vector2(((SmallHUD)smallHUD).TopLeftPosition.X + 700, ((SmallHUD)smallHUD).TopLeftPosition.Y + 150);
            hearts = new List<string>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int offset = 0;
            foreach (string heart in this.hearts)
            {
                if (heart == "full")
                {
                    fullHeartSprite.Draw(spriteBatch, new Vector2(drawPos.X + offset, drawPos.Y));
                }
                else if (heart == "empty")
                {
                    emptyHeartSprite.Draw(spriteBatch, new Vector2(drawPos.X + offset, drawPos.Y));
                }
                else
                {
                    halfHeartSprite.Draw(spriteBatch, new Vector2(drawPos.X + offset, drawPos.Y));
                }
                offset += 30;
            }
        }

        public void Update(GameTime gameTime)
        {
            GetHearts();
        }

        private void GetHearts()
        {
            hearts.Clear();
            int numLives = player.Inventory.GetItemCount(ItemType.HeartContainer);
            int temp = 0;
            for (int i = 0; i < numLives; i++)
            {
                if (temp + 2 <= player.Inventory.GetItemCount(ItemType.Heart))
                {
                    hearts.Insert(i, "full");
                    temp += 2;
                }
                else if (temp + 1 <= player.Inventory.GetItemCount(ItemType.Heart))
                {
                    hearts.Insert(i, "half");
                    temp += 1;
                }
                else
                {
                    hearts.Insert(i, "empty");
                }
            }
        }
    }
}
