using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Factory
{
    class HUDSpriteFactory
    {
        private Texture2D smallHudSpriteSheet;
        private Texture2D blueMapSpritesheet;

        private static HUDSpriteFactory instance = new HUDSpriteFactory();
        public static HUDSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private HUDSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            smallHudSpriteSheet = content.Load<Texture2D>("HUD/bottom-hud");
            blueMapSpritesheet = content.Load<Texture2D>("HUD/blue-map");
        }
        public ISprite CreateSmallHUDSprite()
        {
            return new SmallHudSprite(smallHudSpriteSheet);
        }
        public ISprite CreateBlueMapSprite()
        {
            return new BlueMapSprite(blueMapSpritesheet);
        }

    }
}
