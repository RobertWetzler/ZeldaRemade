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
        private Texture2D bombSpriteSheet;
        private Texture2D darknutSpriteSheet;


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
            bombSpriteSheet = content.Load<Texture2D>("ItemSprites/weapon_bomb_explosion");
            darknutSpriteSheet = content.Load<Texture2D>("EnemySprites/Darknut");
        }

        public ISprite CreateEnemySpawnSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            sourceFrames.Add(new Rectangle(34, 0, 16, 16));
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            return new EnemySpawnSprite(bombSpriteSheet, sourceFrames);
        }

        public ISprite CreateBatSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new GenericEnemySprite(batSpriteSheet, sourceFrames);
        }
        public ISprite CreateSkeletonSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));

            return new SkeletonSprite(skeletonSpriteSheet);
        }
        public ISprite CreateBigJellySprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new GenericEnemySprite(zolSpriteSheet, sourceFrames);
        }
        public ISprite CreateSmallJellySprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 5, 8, 8));
            sourceFrames.Add(new Rectangle(10, 4, 6, 9));
            return new GenericEnemySprite(gelSpriteSheet, sourceFrames);
        }
        public ISprite CreateGoriyaWalkEastSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(34, 0, 16, 16));
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            return new GoriyaWalkRightSprite(goriyaSpriteSheet, sourceFrames);
        }
        public ISprite CreateGoriyaWalkWestSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(34, 0, 16, 16));
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            return new GoriyaWalkLeftSprite(goriyaSpriteSheet, sourceFrames);
        }
        public ISprite CreateGoriyaWalkNorthSprite()
        {
            Rectangle source = new Rectangle(17, 0, 16, 16);
            return new GoriyaWalkUpDownSprite(goriyaSpriteSheet, source);
        }
        public ISprite CreateGoriyaWalkSouthSprite()
        {
            Rectangle source = new Rectangle(0, 0, 16, 16);
            return new GoriyaWalkUpDownSprite(goriyaSpriteSheet, source);
        }
        public ISprite CreateGoriyaUseItemSprite(Facing dir)
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
        public ISprite CreateDarknutWalkEastSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            sourceFrames.Add(new Rectangle(68, 0, 16, 16));
            return new DarknutWalkRightSprite(darknutSpriteSheet, sourceFrames);
        }
        public ISprite CreateDarknutWalkWestSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(51, 0, 16, 16));
            sourceFrames.Add(new Rectangle(68, 0, 16, 16));
            return new DarknutWalkLeftSprite(darknutSpriteSheet, sourceFrames);
        }

        public ISprite CreateDarknutWalkNorthSprite()
        {
            Rectangle source = new Rectangle(34, 0, 16, 16);
            return new DarknutWalkUpSprite(darknutSpriteSheet, source);
        }
        public ISprite CreateDarknutWalkSouthSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new DarknutWalkDownSprite(darknutSpriteSheet, sourceFrames);
        }
        public ISprite CreateTrapSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));

            return new TrapSprite(trapSpriteSheet);
        }

        public ISprite CreateDragonWalkSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(50, 0, 24, 32));
            sourceFrames.Add(new Rectangle(75, 0, 24, 32));
            return new DragonSprite(bossDragonSpriteSheet, sourceFrames);
        }

        public ISprite CreateDragonAttackSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 24, 32));
            sourceFrames.Add(new Rectangle(25, 0, 24, 32));
            return new DragonSprite(bossDragonSpriteSheet, sourceFrames);
        }

        public ISprite CreateWallMasterSprite(Facing dir)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new WallMasterSprite(wallmasterSpriteSheet, sourceFrames, dir);
        }

        public ISprite CreateSnakeSprite(Facing dir)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));
            sourceFrames.Add(new Rectangle(17, 0, 16, 16));
            return new SnakeEnemySprite(snakeSpriteSheet, sourceFrames, dir);
        }

        public ISprite CreateDinosaurWalkRightSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 32, 16));
            sourceFrames.Add(new Rectangle(33, 0, 32, 16));
            sourceFrames.Add(new Rectangle(66, 0, 32, 16));
            return new DinosaurWalkRightSprite(dinosaurLeftRightSpriteSheet, sourceFrames);
        }

        public ISprite CreateDinosaurWalkLeftSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 32, 16));
            sourceFrames.Add(new Rectangle(33, 0, 32, 16));
            sourceFrames.Add(new Rectangle(66, 0, 32, 16));
            return new DinosaurWalkLeftSprite(dinosaurLeftRightSpriteSheet, sourceFrames);
        }
        public ISprite CreateDinosaurWalkUpSprite()
        {
            Rectangle source = new Rectangle(34, 0, 16, 16);
            return new DinosaurWalkUpSprite(dinosaurUpDownSpriteSheet, source);
        }

        public ISprite CreateDinosaurWalkDownSprite()
        {
            Rectangle source = new Rectangle(0, 0, 16, 16);
            return new DinosaurWalkDownSprite(dinosaurUpDownSpriteSheet, source);
        }

    }
}