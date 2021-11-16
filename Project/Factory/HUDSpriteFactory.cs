using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;
using Project.Sprites.HUDSprites;
using Project.Sprites.ItemSprites;
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
        private Texture2D triforceRectTexture;
        private Texture2D healthBarSpriteSheet;
        private Texture2D whiteSquareTexture;


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
            triforceRectTexture = new Texture2D(graphicsDevice, 1, 1);
            triforceRectTexture.SetData(new[] { Color.White });
            healthBarSpriteSheet = content.Load<Texture2D>("ItemSprites/health_bar");
            whiteSquareTexture = content.Load<Texture2D>("HUD/white_square");
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

        public ISprite CreateTriforceRectangleSprite()
        {
            return new PlayerRectangleSprite(triforceRectTexture);
        }
        public ISprite CreateFullHeart()
        {
            return new HealthBarSprite(healthBarSpriteSheet, 1, 3, 0);
        }
        public ISprite CreateHalfHeart()
        {
            return new HealthBarSprite(healthBarSpriteSheet, 1, 3, 1);
        }
        public ISprite CreateEmptyHeart()
        {
            return new HealthBarSprite(healthBarSpriteSheet, 1, 3, 2);
        }
        public ISprite CreateWhiteSquare()
        {
            return new WhiteSquareSprite(whiteSquareTexture);
        }

    }
}
