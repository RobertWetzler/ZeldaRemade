using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.ItemSprites;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

        }

        public IItemSprite CreateItemSprite(int spriteRow, int spriteColumn)
        {
            return new ItemSprite(itemSpriteSheet, 28, 25, spriteRow, spriteColumn);
        }
        public IItemSprite CreateFairySprite()
        {
            return new FairySprite(fairySpriteSheet, 1, 2);
        }
        public IWeaponSprites CreateArrowSprite(Facing facing, Vector2 position)
        {
            return new ArrowSprite(arrowSpriteSheet, 1, 5, facing, position);

        }
        public IWeaponSprites CreateBlueArrowSprite(Facing facing, Vector2 position)
        {
            return new BlueArrowSprite(blueArrowSpriteSheet, 1, 5, facing, position);
        }
        public IWeaponSprites CreateBoomerangSprite(Facing facing, Vector2 position)
        {
            return new BoomerangSprite(boomerangSpriteSheet, 1, 6, facing, position);
        }

        public IWeaponSprites CreateBlueBoomerangSprite(Facing facing, Vector2 position)
        {
            return new BoomerangSprite(blueBoomerangSpriteSheet, 1, 6, facing, position);
        }

        public IWeaponSprites CreateBombSprite(Facing facing, Vector2 position)
        {
            return new BombSprite(bombSpriteSheet, 1, 4, facing, position);
        }

        public IWeaponSprites CreateFlameSprite(Facing facing, Vector2 position)
        {
            return new FlameSprite(flameSpriteSheet, 2, 1, facing, position);
        }

        public IWeaponSprites CreateLeftUpFireballSprite(Vector2 position)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 8, 16));
            sourceFrames.Add(new Rectangle(9, 0, 8, 16));
            sourceFrames.Add(new Rectangle(18, 0, 8, 16));
            sourceFrames.Add(new Rectangle(27, 0, 8, 16));
            return new LeftUpFireballSprite(fireballSpriteSheet, sourceFrames, position);
        }

        public IWeaponSprites CreateLeftFireballSprite(Vector2 position)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 8, 16));
            sourceFrames.Add(new Rectangle(9, 0, 8, 16));
            sourceFrames.Add(new Rectangle(18, 0, 8, 16));
            sourceFrames.Add(new Rectangle(27, 0, 8, 16));
            return new LeftFireballSprite(fireballSpriteSheet, sourceFrames, position);
        }

        public IWeaponSprites CreateLeftDownFireballSprite(Vector2 position)
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 8, 16));
            sourceFrames.Add(new Rectangle(9, 0, 8, 16));
            sourceFrames.Add(new Rectangle(18, 0, 8, 16));
            sourceFrames.Add(new Rectangle(27, 0, 8, 16));
            return new LeftDownFireballSprite(fireballSpriteSheet, sourceFrames, position);
        }

        public IItemSprite CreateRupeeSprite()
        {
            return new RupeeSprite(rupeeSpriteSheet, 1, 2);
        }

        public IItemSprite CreateHeartSprite()
        {
            return new HeartSprite(heartSpriteSheet, 1, 2);
        }
        public IItemSprite CreateTriforceSprite()
        {
            return new TriforceSprite(triforceSpriteSheet, 1, 2);
        }
    }
}
