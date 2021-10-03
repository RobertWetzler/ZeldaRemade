using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Factory
{
    public class NPCSpriteFactory
    {
        private Texture2D bossDragonSpriteSheet;
        private Texture2D dinosaurLeftRightSpriteSheet;
        private Texture2D dinosaurUpDownSpriteSheet; 
        private Texture2D gelSpriteSheet;
        private Texture2D skeletonSpriteSheet;
        private Texture2D goriyaSpriteSheet;
        private Texture2D snakeSpriteSheet;
        private Texture2D wallmasterSpriteSheet;
        private Texture2D zolSpriteSheet;
        private Texture2D enemySpriteSheet;
        private Texture2D batSpriteSheet;
        private Texture2D oldManSpriteSheet;
        private Texture2D merchantSpriteSheet;

        private static NPCSpriteFactory instance = new NPCSpriteFactory();

        public static NPCSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private NPCSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            bossDragonSpriteSheet = content.Load<Texture2D>("EnemySprites/boss-dragon");
            dinosaurLeftRightSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-front-back");
            dinosaurUpDownSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-left-right");
            gelSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-gel");
            skeletonSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-skeleton");
            goriyaSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-goriya-walking");
            snakeSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-snake");
            wallmasterSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-wallmaster");
            zolSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-zol");
            enemySpriteSheet = content.Load<Texture2D>("EnemySprites/enemysheet");
            batSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-bat");
            oldManSpriteSheet = content.Load<Texture2D>("EnemySprites/oldman"); ;
            merchantSpriteSheet = content.Load<Texture2D>("EnemySprites/merchant"); ;
        }

        public Texture2D GetBatSpriteSheet()
        {

                return batSpriteSheet;
        }

        public Texture2D GetSkeletonSpriteSheet()
        {

            return skeletonSpriteSheet;
        }

        public Texture2D GetOldManSpriteSheet()
        {

            return oldManSpriteSheet;
        }

        public Texture2D GetMerchantSpriteSheet()
        {

            return merchantSpriteSheet;
        }

        public static Rectangle BAT_1 = new Rectangle(3 + 18 * 10, 11, 16, 16);
        public static Rectangle BAT_2 = new Rectangle(0 + 20 * 10, 11, 16, 16);

        public static Rectangle SKELETON_1 = new Rectangle(3 + 18 * 10, 11, 16, 16);
        public static Rectangle SKELETON_2 = new Rectangle(0 + 20 * 10, 11, 16, 16);

        public static Rectangle OLD_MAN = new Rectangle(1 * 10, 11, 16, 16);
        public static Rectangle MERCHANT = new Rectangle(1 * 10, 11, 16, 16);

    }
}