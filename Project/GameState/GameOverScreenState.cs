using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
using Project.Sound;
using Project.Text;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GameState
{
    public class GameOverScreenState : IGameState
    {
        private IText youLoseText;
        private int flashTimer = 0, waitTimer = 0, flashCounter = 0;
        private int flashMaxTime = 2000, waitTimeMax = 2000, timeToRestart = 5000;
        private bool doneFlashing = false, doneWaiting = false, doneRestart = false;
        private bool changeBackground = false;
        private IHUD smallHUD;

        public GameOverScreenState()
        {
            youLoseText = new StringText("GAME OVER", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 120, 400));
            smallHUD = new SmallHUD(false);
                SoundManager.Instance.CreateLinkDeathSound();
            
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!doneFlashing)
            {
                spriteBatch.Begin(blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
                /*if (changeBackground)
                {
                    Game1.Instance.GraphicsDevice.Clear(Color.DarkRed);
                }
                else
                {
                    RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
                }*/
                RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
                smallHUD.Draw(spriteBatch);
                Game1.Instance.Player.Draw(spriteBatch, gameTime);
                spriteBatch.End();
            }
            else if (doneFlashing && !doneWaiting)
            {
                spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
                Game1.Instance.Player.Draw(spriteBatch, gameTime);
                spriteBatch.End();
            }
            else if (doneWaiting && doneFlashing&&!doneRestart)
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
            //waitSpinTimer+= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            /*
            if (waitSpinTimer > timeToSpin)
            {
                isSpinning = true;
            }*/
            smallHUD.Update(gameTime);
            Game1.Instance.Player.Update(playerBounds, gameTime);
            SetDoneFlashing();
            if (!doneFlashing)
            {
                flashTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                flashCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (flashTimer >= 50)
                {
                    flashTimer -= 50;
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
            else if (!doneWaiting)
            {
                waitTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (waitTimer > waitTimeMax)
                {
                    doneWaiting = true;
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
                doneFlashing = flashCounter >= flashMaxTime ? true : false;
            }
        }
    }
}
