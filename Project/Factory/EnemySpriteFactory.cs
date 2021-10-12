using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System.Collections.Generic;

namespace Project.Factory
{
    public class EnemySpriteFactory
    {
        private Texture2D batSpriteSheet;
        private Texture2D bossDragonSpriteSheet;
        private Texture2D dinosaurUpDownSpriteSheet;
        private Texture2D dinosaurLeftRightSpriteSheet;
        private Texture2D gelSpriteSheet;
        private Texture2D skeletonSpriteSheet;
        private Texture2D goriyaSpriteSheet;
        private Texture2D snakeSpriteSheet;
        private Texture2D wallmasterSpriteSheet;
        private Texture2D zolSpriteSheet;
        private Texture2D trapSpriteSheet;


        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            bossDragonSpriteSheet = content.Load<Texture2D>("EnemySprites/boss-dragon");
            dinosaurUpDownSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-front-back");
            dinosaurLeftRightSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-left-right");
            gelSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-gel");
            skeletonSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-skeleton");
            goriyaSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-goriya-walking");
            snakeSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-snake");
            wallmasterSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-wallmaster");
            zolSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-zol");
            batSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-bat");
            trapSpriteSheet = content.Load<Texture2D>("EnemySprites/trap");

        }

        public IEnemySprite CreateBatSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new GenericEnemySprite(batSpriteSheet, sourceFrames);
        }
        public IEnemySprite CreateSkeletonSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));

            return new SkeletonSprite(skeletonSpriteSheet);
        }
        public IEnemySprite CreateBigJellySprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new GenericEnemySprite(zolSpriteSheet, sourceFrames);
        }
        public IEnemySprite CreateSmallJellySprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 5, 8, 8));
            sourceFrames.Add(new Rectangle(10, 4, 6, 9));
            return new GenericEnemySprite(gelSpriteSheet, sourceFrames);
        }
        public IEnemySprite CreateGoriyaWalkEastSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(34, 0, 16, 16));
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            return new GoriyaWalkRightSprite(goriyaSpriteSheet, sourceFrames);
        }
        public IEnemySprite CreateGoriyaWalkWestSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(34, 0, 16, 16));
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            return new GoriyaWalkLeftSprite(goriyaSpriteSheet, sourceFrames);
        }
        public IEnemySprite CreateGoriyaWalkNorthSprite()
        {
            Rectangle source = new Rectangle(17, 0, 16, 16);
            return new GoriyaWalkUpDownSprite(goriyaSpriteSheet, source);
        }
        public IEnemySprite CreateGoriyaWalkSouthSprite()
        {
            Rectangle source = new Rectangle(0, 0, 16, 16);
            return new GoriyaWalkUpDownSprite(goriyaSpriteSheet, source);
        }
        public IEnemySprite CreateGoriyaUseItemSprite(Facing dir)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(34, 0, 16, 16));
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            Rectangle downFrame = new Rectangle(0, 0, 16, 16);
            Rectangle upFrame = new Rectangle(17, 0, 16, 16);
            switch (dir)
            {
                case Facing.Up:
                    return new GoriyaWalkUpDownSprite(goriyaSpriteSheet, upFrame);
                case Facing.Down:
                    return new GoriyaWalkUpDownSprite(goriyaSpriteSheet, downFrame);
                case Facing.Left:
                    return new GoriyaWalkLeftSprite(goriyaSpriteSheet, sourceFrames);
                default:
                    return new GoriyaWalkRightSprite(goriyaSpriteSheet, sourceFrames);
            }
        }

        public IEnemySprite CreateTrapSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));

            return new TrapSprite(trapSpriteSheet);
        }

        public IEnemySprite CreateDragonWalkSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(50, 0, 24, 32));
            sourceFrames.Add(new Rectangle(75, 0, 24, 32));
            return new DragonSprite(bossDragonSpriteSheet, sourceFrames);
        }

        public IEnemySprite CreateDragonAttackSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 24, 32));
            sourceFrames.Add(new Rectangle(25, 0, 24, 32));
            return new DragonSprite(bossDragonSpriteSheet, sourceFrames);
        }

        public IEnemySprite CreateWallMasterSprite(Facing dir)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new WallMasterSprite(wallmasterSpriteSheet, sourceFrames, dir);
        }

        public IEnemySprite CreateSnakeSprite(Facing dir)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new SnakeEnemySprite(snakeSpriteSheet, sourceFrames, dir);
        }

        public IEnemySprite CreateDinosaurLeftRightSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 32, 16));
            sourceFrames.Add(new Rectangle(33, 0, 32, 16));
            sourceFrames.Add(new Rectangle(66, 0, 32, 16));
            return new DinosaurWalkLeftRightSprite(dinosaurLeftRightSpriteSheet, sourceFrames);
        }
       
    }
}