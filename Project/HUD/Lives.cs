using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.HUD
{
    class Lives
    {
        private ISprite fullHeartSprite, halfHeartSprite, emptyHeartSprite;
        private int playerHealth, numHearts;
        private string[] hearts;
        private Vector2 topLeftPos;
        public Lives(int playerHealth, int numHearts, Vector2 topLeftPos)
        {
            fullHeartSprite = HUDSpriteFactory.Instance.CreateFullHeart();
            halfHeartSprite = HUDSpriteFactory.Instance.CreateHalfHeart();
            emptyHeartSprite = HUDSpriteFactory.Instance.CreateEmptyHeart();
            this.playerHealth = playerHealth;
            this.numHearts = numHearts;
            this.topLeftPos = topLeftPos;
            hearts = GetHeartsToDraw();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 position = new Vector2(topLeftPos.X + 700, topLeftPos.Y + 150);
            int offset = 0;
            foreach (string str in hearts)
            {
                switch (str)
                {
                    case "full":
                        fullHeartSprite.Draw(spriteBatch, new Vector2(position.X + offset, position.Y));
                        break;
                    case "half":
                        halfHeartSprite.Draw(spriteBatch, new Vector2(position.X + offset, position.Y));
                        break;
                    case "empty":
                        emptyHeartSprite.Draw(spriteBatch, new Vector2(position.X + offset, position.Y));
                        break;
                }
                offset += 30;
            }
        }

        private string[] GetHeartsToDraw()
        {
            string[] hearts = new string[numHearts];
            int start = 0;
            for (int i = 0; i < numHearts; i++)
            {
                if (start + 2 <= playerHealth)
                {
                    hearts[i] = "full";
                    start += 2;
                }
                else if (start + 1 <= playerHealth)
                {
                    hearts[i] = "half";
                    start++;
                }
                else
                {
                    hearts[i] = "empty";
                }

            }
            return hearts;
        }
    }
}
