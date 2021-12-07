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
    public class WinScreenState : IGameState
    {
        private IText youWinText, developerText;
        private IText RobertName, MaggieName, JenaName, YutingName, JacobName, EdwinName;
        private int flashTimer = 0, waitTimer = 0, flashCounter = 0;
        private int flashMaxTime = 2000, waitTimeMax = 2000;
        private bool doneFlashing = false, doneWaiting = false;
        private bool changeBackground = false;
        private IHUD smallHUD;

        public WinScreenState()
        {
            youWinText = new StringText("You win!", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 120, 200));
            developerText = new StringText("Made By", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 110, 300));
            JacobName = new StringText("Jacob Batt", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 150, 400));
            MaggieName = new StringText("Maggie Feng", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 150, 450));
            JenaName = new StringText("Jena Fogarty", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 170, 500));
            EdwinName = new StringText("Edwin Pallithanam", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 240, 550));
            RobertName = new StringText("Robert Wetzler", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 190, 600));
            YutingName = new StringText("Yuting Yang", new Vector2(Game1.Instance.Graphics.PreferredBackBufferWidth / 2 - 170, 650));
            smallHUD = new SmallHUD(false);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!doneFlashing)
            {
                DrawingUtilities.DrawGameScreen(spriteBatch, gameTime, smallHUD);
                if (changeBackground)
                {
                    Game1.Instance.GraphicsDevice.SetRenderTarget(Game1.Instance.MainTarget);
                    Game1.Instance.GraphicsDevice.Clear(Color.White);
                    Game1.Instance.GraphicsDevice.SetRenderTarget(null);
                    spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                    spriteBatch.Draw(Game1.Instance.MainTarget, Vector2.Zero, Color.White);
                    smallHUD.Draw(spriteBatch);
                    spriteBatch.End();
                }
            }
            else if (doneFlashing && !doneWaiting)
            {
                DrawingUtilities.DrawGameScreen(spriteBatch, gameTime, smallHUD);
            }
            else if (doneWaiting && doneFlashing)
            {
                spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                Game1.Instance.GraphicsDevice.Clear(Color.Black);
                youWinText.Draw(spriteBatch);
                developerText.Draw(spriteBatch);
                JacobName.Draw(spriteBatch);
                MaggieName.Draw(spriteBatch);
                JenaName.Draw(spriteBatch);
                EdwinName.Draw(spriteBatch);
                RobertName.Draw(spriteBatch);
                YutingName.Draw(spriteBatch);
                spriteBatch.End();
            }

        }

        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
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
