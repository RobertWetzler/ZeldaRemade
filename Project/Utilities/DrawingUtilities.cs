using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
using Project.Shading;

namespace Project.Utilities
{
    public static class DrawingUtilities
    {
        public static void DrawLights(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //draw lights
            Game1.Instance.GraphicsDevice.SetRenderTarget(Game1.Instance.LightTarget);
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(blendState: BlendState.Additive);
            
            Lightable lightablePlayer = Game1.Instance.Player as Lightable;
            if (lightablePlayer != null) //in case player is not lightable
            {
                lightablePlayer.DrawLight(spriteBatch, gameTime, Game1.Instance.Player.BoundingBox);
            }
            RoomManager.Instance.CurrentRoom.DrawLights(spriteBatch, gameTime);
            
            spriteBatch.End();
        }

        public static void DrawRoom(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game1.Instance.GraphicsDevice.SetRenderTarget(Game1.Instance.MainTarget);
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            
            RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
            Game1.Instance.Player.Draw(spriteBatch, gameTime);
            RoomManager.Instance.CurrentRoom.DrawForeground(spriteBatch, gameTime);
            
            spriteBatch.End();
        }

        public static void ApplyLights(SpriteBatch spriteBatch)
        {
            //use shader to combine lights onto game
            Game1.Instance.GraphicsDevice.SetRenderTarget(null);
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            LightShaderFactory.Instance.LightShader.Parameters["MaskTexture"].SetValue(Game1.Instance.LightTarget);
            spriteBatch.Begin(blendState: BlendState.AlphaBlend, effect: LightShaderFactory.Instance.LightShader);
            
            spriteBatch.Draw(Game1.Instance.MainTarget, Vector2.Zero, Color.White);
            
            spriteBatch.End();
        }

        public static void DrawMainTarget(SpriteBatch spriteBatch)
        {
            Game1.Instance.GraphicsDevice.SetRenderTarget(null);
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(Game1.Instance.MainTarget, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        // Draws player, room, and hud
        public static void DrawGameScreen(SpriteBatch spriteBatch, GameTime gameTime, IHUD smallHud)
        {
            if (GameOptions.IsShaderOn)
            {
                DrawingUtilities.DrawLights(spriteBatch, gameTime);
            }

            DrawingUtilities.DrawRoom(spriteBatch, gameTime);

            //draw to screen
            if (GameOptions.IsShaderOn)
            {
                DrawingUtilities.ApplyLights(spriteBatch);
            }
            else
            {
                DrawingUtilities.DrawMainTarget(spriteBatch);
            }
            //draw HUD without shader
            Game1.Instance.GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            smallHud.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
