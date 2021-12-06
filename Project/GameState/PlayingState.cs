using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
using Project.Sound;
using Project.Utilities;
using System.Collections.Generic;
using System.Linq;
using Project.Entities;
using Project.Shading;

namespace Project.GameState
{
    class PlayingState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;
        private IHUD smallHud;

        public PlayingState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>();
            controllers.Add(ControllerUtilities.GetKeyboardController(this.game));
            SoundManager.Instance.CreateBackgroundMusic();
            smallHud = new SmallHUD(false);
        }
        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            PauseController.controller.Update();
            game.CollisionIterator.UpdateCollisions(RoomManager.Instance.CurrentRoom.Dynamics.Append(game.Player).ToList(), RoomManager.Instance.CurrentRoom.Statics);
            RoomManager.Instance.CurrentRoom.Update(playerBounds, gameTime);
            smallHud.Update(gameTime);
            game.Player.Update(playerBounds, gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //draw lights
            Game1.Instance.GraphicsDevice.SetRenderTarget(Game1.Instance.LightTarget);
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(blendState: BlendState.Additive);
            Lightable lightablePlayer = Game1.Instance.Player as Lightable;
            if(lightablePlayer != null) //in case player is not lightable
            {
                lightablePlayer.DrawLight(spriteBatch, gameTime, Game1.Instance.Player.BoundingBox);
            }
            RoomManager.Instance.CurrentRoom.DrawLights(spriteBatch, gameTime);
            spriteBatch.End();

            //draw game
            Game1.Instance.GraphicsDevice.SetRenderTarget(Game1.Instance.MainTarget);
            //Game1.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
            game.Player.Draw(spriteBatch, gameTime);
            RoomManager.Instance.CurrentRoom.DrawForeground(spriteBatch, gameTime);
            spriteBatch.End();
            
            //use shader to combine lights onto game
            Game1.Instance.GraphicsDevice.SetRenderTarget(null);
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            LightShaderFactory.Instance.LightShader.Parameters["MaskTexture"].SetValue(Game1.Instance.LightTarget);
            spriteBatch.Begin(blendState: BlendState.AlphaBlend, effect: LightShaderFactory.Instance.LightShader);
            spriteBatch.Draw(Game1.Instance.MainTarget, Vector2.Zero, Color.White);
            spriteBatch.End();
            //draw HUD without shader
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            smallHud.Draw(spriteBatch);
            spriteBatch.End();
        }


    }
}
