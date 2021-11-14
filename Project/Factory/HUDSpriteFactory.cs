using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;
using Project.Sprites.HUDSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Factory
{
    class HUDSpriteFactory
    {
        private Texture2D smallHudSpriteSheet;
        private Texture2D blueMapSpritesheet;
        private Texture2D playerRectTexture;

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

        public void LoadAllTextures(ContentManager content, GraphicsDevice graphicsDevice)
        {
            smallHudSpriteSheet = content.Load<Texture2D>("HUD/bottom-hud");
            blueMapSpritesheet = content.Load<Texture2D>("HUD/blue-map");
            playerRectTexture = new Texture2D(graphicsDevice, 1, 1);
            playerRectTexture.SetData(new[] { Color.White });
        }
        public ISprite CreateSmallHUDSprite()
        {
            return new SmallHudSprite(smallHudSpriteSheet);
        }
        public ISprite CreateBlueMapSprite()
        {
            return new BlueMapSprite(blueMapSpritesheet);
        }

        public ISprite CreatePlayerRectangleSprite()
        {
            return new PlayerRectangleSprite(playerRectTexture);
        }

    }
}
