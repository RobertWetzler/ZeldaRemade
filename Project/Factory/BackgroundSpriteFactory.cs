using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Factory
{
    class BackgroundSpriteFactory
    {
        private Texture2D backgroundSpriteSheet;

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
        }

        public BackgroundSprite CreateOldManRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 0, 6, 6);
        }

        public BackgroundSprite CreateStairRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 0, 1, 6, 6);
        }

        public BackgroundSprite CreateOneBlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 1, 6, 6);
        }

        public BackgroundSprite CreateSixBlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 3, 1, 6, 6);
        }

        public BackgroundSprite CreateWaterRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 0, 2, 6, 6);
        }

        public BackgroundSprite CreateLotsWaterRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 1, 2, 6, 6);
        }

        public BackgroundSprite CreateXRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 2, 6, 6);
        }

        public BackgroundSprite Create4BlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 3, 2, 6, 6);
        }

        public BackgroundSprite CreateBig4BlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 3, 3, 6, 6);
        }

        public BackgroundSprite CreateWallMasterRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 2, 4, 6, 6);
        }

        public BackgroundSprite CreateDragonBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 1, 4, 6, 6);
        }

        public BackgroundSprite CreateFinalRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 1, 5, 6, 6);
        }

        public BackgroundSprite CreateEmptyRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 5, 1, 6, 6);
        }

        public BackgroundSprite CreateStartRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 5, 2, 6, 6);
        }

        public BackgroundSprite CreateTwo6BlockRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 5, 3, 6, 6);
        }

        public BackgroundSprite CreateHiddenRoomBackgroundSprite()
        {
            return new BackgroundSprite(backgroundSpriteSheet, 0, 0, 6, 6);
        }

    }
}
