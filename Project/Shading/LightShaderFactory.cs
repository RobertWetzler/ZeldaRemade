using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Shading
{
    public class LightShaderFactory
    {
        private Texture2D lightTexture;
        private Effect lightShader;
        public Texture2D LightTexture => lightTexture;
        public Effect LightShader => lightShader;
        private static LightShaderFactory instance = new LightShaderFactory();
        public static LightShaderFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllContent(ContentManager content)
        {
            lightTexture = content.Load<Texture2D>("Lights/light-texture");
            lightShader = content.Load<Effect>("Lights/light-shader");
        }
    }
}
