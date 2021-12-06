using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;
using Project.Sprites.BackgroundSprites;

namespace Project.Factory
{
    class BackgroundSpriteFactory
    {
        private Texture2D backgroundSpriteSheet;
        private Texture2D titleScreenSheet;
        private Texture2D itemSelectionScreenSheet;
        private Texture2D torchSpriteSheet;

        private static BackgroundSpriteFactory instance = new BackgroundSpriteFactory();
        public static BackgroundSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BackgroundSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            backgroundSpriteSheet = content.Load<Texture2D>("Level1");
            titleScreenSheet = content.Load<Texture2D>("titleScreen");
            itemSelectionScreenSheet = content.Load<Texture2D>("HUD/main-hud-screen");
            torchSpriteSheet = content.Load<Texture2D>("torch_Sprite_Sheet");
        }

        public IBackgroundSprite CreateOldManRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 0, 6, 6);
        }

        public IBackgroundSprite CreateStairRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 0, 1, 6, 6);
        }

        public IBackgroundSprite CreateOneBlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 1, 6, 6);
        }

        public IBackgroundSprite CreateSixBlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 3, 1, 6, 6);
        }

        public IBackgroundSprite CreateWaterRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 0, 2, 6, 6);
        }

        public IBackgroundSprite CreateLotsWaterRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 1, 2, 6, 6);
        }

        public IBackgroundSprite CreateXRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 2, 6, 6);
        }

        public IBackgroundSprite Create4BlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 3, 2, 6, 6);
        }

        public IBackgroundSprite CreateBig4BlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 3, 3, 6, 6);
        }

        public IBackgroundSprite CreateWallMasterRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 4, 6, 6);
        }

        public IBackgroundSprite CreateDragonBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 1, 4, 6, 6);
        }

        public IBackgroundSprite CreateFinalRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 1, 5, 6, 6);
        }

        public IBackgroundSprite CreateEmptyRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 5, 1, 6, 6);
        }

        public IBackgroundSprite CreateStartRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 5, 2, 6, 6);
        }

        public IBackgroundSprite CreateTwo6BlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 5, 3, 6, 6);
        }

        public IBackgroundSprite CreateHiddenRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 0, 0, 6, 6);
        }

        public IBackgroundSprite CreateTitleScreen()
        {
            return new TitleScreenSprite(titleScreenSheet, 0, 0, 1, 3);
        }

        public IBackgroundSprite CreateItemSelectionScreen()
        {
            return new ItemSelectionScreenSprite(itemSelectionScreenSheet, 0, 0, 1, 1);
        }

        public ISprite CreateTorchSprite()
        {
            return new TorchSprite(torchSpriteSheet,1,6);
        }
    }
}
