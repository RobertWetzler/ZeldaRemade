using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
using Project.Sound;
using Project.Text;
using Project.Utilities;
using Project.Entities;

namespace Project.GameState
{
    public class GameOverScreenState : IGameState
    {
        private IText youLoseText;
        private int spinTimer = 0, flashTimer = 0, flashCounter = 0, waitTimer = 0;
        private int spinTimeMax = 2000, flashTimeMax = 800, timeToRestart = 3000;
        private bool doneSpinning = false, doneFlashing = false, doneRestart = false;
        private bool changeBackground = false;
        private IHUD smallHUD;

        public GameOverScreenState()
        {
            youLoseText = new StringText("GAME OVER", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 120, 400));
            smallHUD = new SmallHUD(false);
            Game1.Instance.Player = new DeadLink(Game1.Instance.Player, Game1.Instance);
            SoundManager.Instance.CreateLinkDeathSound();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!doneSpinning)
            {
                spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
                Game1.Instance.Player.Draw(spriteBatch, gameTime);
                spriteBatch.End();
            }
            else if (doneSpinning && !doneFlashing)
            {
                spriteBatch.Begin(blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
                if (changeBackground)
                {
                    Game1.Instance.GraphicsDevice.Clear(Color.DarkRed);
                }
                else
                {
                    RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
                }
                smallHUD.Draw(spriteBatch);
                Game1.Instance.Player.Draw(spriteBatch, gameTime);
                spriteBatch.End();
            }
            else if (doneSpinning && doneFlashing &&!doneRestart)
            {
                spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                Game1.Instance.GraphicsDevice.Clear(Color.Black);
                youLoseText.Draw(spriteBatch);
                spriteBatch.End();
            }
            else if (doneRestart)
            {
                Game1.Instance.GameStateMachine.TitleScreen();
            }
        }

        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            smallHUD.Update(gameTime);
            Game1.Instance.Player.Update(playerBounds, gameTime);
            SetDoneFlashing();
            if (!doneSpinning)
            {
                spinTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (spinTimer > spinTimeMax)
                {
                    doneSpinning = true;
                }
            } else if (doneSpinning && !doneFlashing)
            {
                flashTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                flashCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (flashTimer >= 100)
                {
                    flashTimer -= 100;
                    if (changeBackground)
                    {
                        changeBackground = false;
                    }
                    else
                    {
                        changeBackground = true;
                    }
                }
            }
            else if (!doneRestart)
            {
                waitTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (waitTimer > timeToRestart)
                {
                    doneRestart = true;
                }
            }
        }

        private void SetDoneFlashing()
        {
            if (!doneFlashing)
            {
                doneFlashing = flashCounter >= flashTimeMax ? true : false;
            }
        }
    }
}
