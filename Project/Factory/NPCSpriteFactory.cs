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
        private Texture2D batSpriteSheet;
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
            batSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-bat");
            bossDragonSpriteSheet = content.Load<Texture2D>("EnemySprites/boss-dragon");
            dinosaurLeftRightSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-front-back");
            dinosaurUpDownSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-left-right");
            gelSpriteSheet= content.Load<Texture2D>("EnemySprites/enemy-gel");
            skeletonSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-skeleton");
            goriyaSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-goriya-walking");
            snakeSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-snake");
            wallmasterSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-wallmaster");
            zolSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-zol");
            //If we use this spritesheet, we have to get rid of the grey backgrounds
            enemySpriteSheet = content.Load<Texture2D>("EnemySprites/enemysheet");


        }

        public Texture2D GetEnemySpriteSheet()
        {

            return enemySpriteSheet;
        }
        //public static Rectangle BAT_1 = new Rectangle(3 + 18 * 10, 11, 16, 16);
        //public static Rectangle BAT_2 = new Rectangle(0 + 20 * 10, 11, 16, 16);
        //public static Rectangle SKELETON_1 = new Rectangle(3 + 18 * 10, 11, 16, 16);
        //public static Rectangle SKELETON_2 = new Rectangle(0 + 20 * 10, 11, 16, 16);
        public IEnemySprite CreateBatSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new BatSprite(batSpriteSheet, sourceFrames);
        }
        public IEnemySprite CreateSkeletonSprite()
        {
            return new SkeletonSprite(skeletonSpriteSheet);
        }
        public IEnemySprite CreateBigJellySprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new BatSprite(zolSpriteSheet, sourceFrames);
        }

    }
}