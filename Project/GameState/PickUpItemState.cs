using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
using Project.Sound;
using Project.Utilities;

namespace Project.GameState
{
    class PickUpItemState : IGameState
    {
        private IHUD smallHUD;
        private int timer = 0;
        private int maxTime = 1800;
        private IItems item;
        public PickUpItemState(IItems item)
        {
            this.item = item;
            smallHUD = new SmallHUD(false);
            Game1.Instance.Player.PickUpItem(item);

            SoundManager.Instance.CreateItemSound();
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawingUtilities.DrawGameScreen(spriteBatch, gameTime, smallHUD);
        }

        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            timer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer >= maxTime)
            {
                if (item.type == ItemType.Triforce)
                {
                    Game1.Instance.GameStateMachine.WinScreen();
                }
                else
                {
                    Game1.Instance.GameStateMachine.Play();
                }

            }
            else
            {
                smallHUD.Update(gameTime);
                Game1.Instance.Player.Update(playerBounds, gameTime);
            }

        }
    }
}
