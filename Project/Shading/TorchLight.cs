using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Shading
{
    public abstract class TorchLight: Lightable
    {
        protected new Color lightColor = Color.DarkOrange;
        protected Color innerLightColor = Color.Red;
        protected new float lightScale = 3f;
        protected float innerLightScale = 2f;
        protected new float lightIntensity = 0.8f;
        protected float innerLightIntensity = 0.5f;

        private void SetFlickerIntensity(GameTime gameTime)
        {
            lightIntensity = Math.Clamp(lightIntensity + (float)((new Random()).NextDouble() - .3), 0, 1);
        }

        public override void DrawLight(SpriteBatch spriteBatch, GameTime gameTime, Rectangle destRectangle)
        {
            SetFlickerIntensity(gameTime);

            Rectangle outerFlame = new Rectangle(destRectangle.X, destRectangle.Y, destRectangle.Width, destRectangle.Height);
            Rectangle innerFlame = new Rectangle(destRectangle.X, destRectangle.Y, destRectangle.Width, destRectangle.Height);
            
            float outerHorizAdjust = (outerFlame.Width * lightScale - outerFlame.Width) / 2;
            float outerVertAdjust = (outerFlame.Height * lightScale - outerFlame.Height) / 2;
            outerFlame.Inflate(outerHorizAdjust, outerVertAdjust);

            float innerHorizAdjust = (innerFlame.Width * innerLightScale - innerFlame.Width) / 2;
            float innerVertAdjust = (innerFlame.Height * innerLightScale - innerFlame.Height) / 2;
            innerFlame.Inflate(innerHorizAdjust, innerVertAdjust);
            innerFlame.Offset(lightOffset.X, lightOffset.Y);
            outerFlame.Offset(lightOffset.X, lightOffset.Y);
            spriteBatch.Draw(LightShaderFactory.Instance.LightTexture, outerFlame, lightColor * lightIntensity);
            spriteBatch.Draw(LightShaderFactory.Instance.LightTexture, innerFlame, innerLightColor * innerLightIntensity);
        }
    }
}
