using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Factory
{
    public class FontFactory
    {
        private SpriteFont font;


        private static FontFactory instance = new FontFactory();

        public static FontFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private FontFactory()
        {

        }
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Message");
        }

        public SpriteFont GetOldManMessage()
        {
            return font;
        }

    }

 }