using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Sprites.ItemSprites;
using System.Collections.Generic;

namespace Project.Factory
{
    class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private Texture2D arrowSpriteSheet;
        private Texture2D blueArrowSpriteSheet;
        private Texture2D bombSpriteSheet;
        private Texture2D boomerangSpriteSheet;
        private Texture2D blueBoomerangSpriteSheet;
        private Texture2D flameSpriteSheet;
        private Texture2D fairySpriteSheet;
        private Texture2D heartSpriteSheet;
        private Texture2D rupeeSpriteSheet;
        private Texture2D triforceSpriteSheet;
        private Texture2D fireballSpriteSheet;
        private Texture2D swordBeamSpriteSheet;
        private Texture2D swordBeamImpactSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("ItemSprites/spriteSheet_items");
            arrowSpriteSheet = content.Load<Texture2D>("ItemSprites/weapon_arrows");
            blueArrowSpriteSheet = content.Load<Texture2D>("ItemSprites/weapon_blue_arrow");
            bombSpriteSheet = content.Load<Texture2D>("ItemSprites/weapon_bomb_explosion");
            blueBoomerangSpriteSheet = content.Load<Texture2D>("ItemSprites/blue_weapon_boomerang");
            boomerangSpriteSheet = content.Load<Texture2D>("ItemSprites/weapon_boomerang_test");
            flameSpriteSheet = content.Load<Texture2D>("EnemySprites/flame");
            fairySpriteSheet = content.Load<Texture2D>("ItemSprites/fairy");
            heartSpriteSheet = content.Load<Texture2D>("ItemSprites/flashing_heart");
            rupeeSpriteSheet = content.Load<Texture2D>("ItemSprites/rupee");
            fireballSpriteSheet = content.Load<Texture2D>("EnemySprites/dragon-fireballs");
            triforceSpriteSheet = content.Load<Texture2D>("ItemSprites/triforce");
            swordBeamSpriteSheet = content.Load<Texture2D>("ItemSprites/Sword_Beam");
            swordBeamImpactSpriteSheet = content.Load<Texture2D>("ItemSprites/Sword_Beam_Impact");

        }

        public ISprite CreateItemSprite(int spriteRow, int spriteColumn)
        {
            return new ItemSprite(itemSpriteSheet, 28, 25, spriteRow, spriteColumn);
        }
        public ISprite CreateFairySprite()
        {
            return new FairySprite(fairySpriteSheet, 1, 2);
        }
        public IProjectileSprite CreateArrowSprite(Facing facing)
        {
            return new ArrowSprite(arrowSpriteSheet, 1, 5, facing);

        }
        public IProjectileSprite CreateBlueArrowSprite(Facing facing)
        {
            return new BlueArrowSprite(blueArrowSpriteSheet, 1, 5, facing);
        }
        public IProjectileSprite CreateBoomerangSprite(Facing facing)
        {
            return new BoomerangSprite(boomerangSpriteSheet, 1, 6, facing);
        }

        public IProjectileSprite CreateBlueBoomerangSprite(Facing facing)
        {
            return new BlueBoomerangSprite(blueBoomerangSpriteSheet, 1, 6, facing);
        }

        public IProjectileSprite CreateBombSprite(Facing facing)
        {
            return new BombSprite(bombSpriteSheet, 1, 4, facing);
        }

        public IProjectileSprite CreateFlameSprite(Facing facing)
        {
            return new FlameSprite(flameSpriteSheet, 1, 1, facing);
        }
        public IProjectileSprite CreateSwordSprite(Facing facing)
        {
            return new SwordBeamSprite(swordBeamSpriteSheet, 4, 2, facing);
        }


        public IProjectileSprite CreateLeftUpFireballSprite(Vector2 position)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 8, 16));
            sourceFrames.Add(new Rectangle(9, 0, 8, 16));
            sourceFrames.Add(new Rectangle(18, 0, 8, 16));
            sourceFrames.Add(new Rectangle(27, 0, 8, 16));
            return new LeftUpFireballSprite(fireballSpriteSheet, sourceFrames, position);
        }

        public IProjectileSprite CreateLeftFireballSprite(Vector2 position)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 8, 16));
            sourceFrames.Add(new Rectangle(9, 0, 8, 16));
            sourceFrames.Add(new Rectangle(18, 0, 8, 16));
            sourceFrames.Add(new Rectangle(27, 0, 8, 16));
            return new LeftFireballSprite(fireballSpriteSheet, sourceFrames, position);
        }

        public IProjectileSprite CreateLeftDownFireballSprite(Vector2 position)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 8, 16));
            sourceFrames.Add(new Rectangle(9, 0, 8, 16));
            sourceFrames.Add(new Rectangle(18, 0, 8, 16));
            sourceFrames.Add(new Rectangle(27, 0, 8, 16));
            return new LeftDownFireballSprite(fireballSpriteSheet, sourceFrames, position);
        }

        public ISprite CreateRupeeSprite()
        {
            return new RupeeSprite(rupeeSpriteSheet, 1, 2);
        }

        public ISprite CreateHeartSprite()
        {
            return new HeartSprite(heartSpriteSheet, 1, 2);
        }
        public ISprite CreateTriforceSprite()
        {
            return new TriforceSprite(triforceSpriteSheet, 1, 2);
        }
    }
}
