using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Shading
{
    public abstract class Lightable
    {
        protected Color lightColor = Color.White;
        protected float lightScale = 1f;
        protected float lightIntensity = 0.5f;
        public virtual void DrawLight(SpriteBatch spriteBatch, GameTime gameTime, Rectangle destRectangle)
        {
            Rectangle inflatedRectangle = new Rectangle(destRectangle.X, destRectangle.Y, destRectangle.Width, destRectangle.Height);
            float horizAdjust = (inflatedRectangle.Width * lightScale - inflatedRectangle.Width) / 2;
            float vertAdjust = (inflatedRectangle.Height * lightScale - inflatedRectangle.Height) / 2;
            inflatedRectangle.Inflate(horizAdjust, vertAdjust);
            spriteBatch.Draw(LightShaderFactory.Instance.LightTexture, inflatedRectangle, lightColor * lightIntensity);
        }
    }
}
