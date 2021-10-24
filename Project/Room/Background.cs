using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Room
{
    public class Background
    {
        private Texture2D backgroundSpriteSheet;
       
        

        private static Background instance = new Background();

        public static Background Instance
        {
            get
            {
                return instance;
            }
        }

        private Background()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            backgroundSpriteSheet = content.Load<Texture2D>("");
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(backgroundSpriteSheet, new Vector2 (0,0), new Rectangle (0,0,graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
        }

       
        

            
    }
}
