using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Factory
{
    class ItemSpriteFactory
    {
        private Texture2D arrowSpriteSheet;
        private Texture2D blueArrowSpriteSheet;
        private Texture2D wandSpriteSheet;
        private Texture2D bombSpriteSheet;
        private Texture2D boomerangSpriteSheet;
        private Texture2D bottleSpriteSheet;
        private Texture2D candleSpriteSheet;
        private Texture2D clockSpriteSheet;
        private Texture2D compassSpriteSheet;
        private Texture2D fairySpriteSheet;
        private Texture2D fluteSpriteSheet;
        private Texture2D healthSpriteSheet;
        private Texture2D heartContSpriteSheet;
        private Texture2D keySpriteSheet;
        private Texture2D ringSpriteSheet;
        private Texture2D rupeesSpriteSheet;
        private Texture2D triforceSpriteSheet;
        private Texture2D swordSpriteSheet;
        private Texture2D heartSpriteSheet;
        private Texture2D mapSpriteSheet;
        private Texture2D bowSpriteSheet;
        



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
            arrowSpriteSheet = content.Load<Texture2D>("ItemSprites/items_arrows");
            blueArrowSpriteSheet = content.Load<Texture2D>("ItemSprites/items_blue_arrows");
            bombSpriteSheet = content.Load<Texture2D>("ItemSprites/items_bomb");
            boomerangSpriteSheet = content.Load<Texture2D>("ItemSprites/items_boomerangs");
            bottleSpriteSheet = content.Load<Texture2D>("ItemSprites/items_bottles");
            candleSpriteSheet = content.Load<Texture2D>("ItemSprites/items_candles");
            clockSpriteSheet = content.Load<Texture2D>("ItemSprites/items_clock");
            compassSpriteSheet = content.Load<Texture2D>("ItemSprites/items_compass");
            fairySpriteSheet = content.Load<Texture2D>("ItemSprites/items_fairy");
            fluteSpriteSheet = content.Load<Texture2D>("ItemSprites/items_flute");
            healthSpriteSheet = content.Load<Texture2D>("ItemSprites/health_bar");
            heartSpriteSheet = content.Load<Texture2D>("ItemSprites/item_full_heart");
            heartContSpriteSheet = content.Load<Texture2D>("ItemSprites/items_heart_container");
            keySpriteSheet = content.Load<Texture2D>("ItemSprites/items_regular_key");
            ringSpriteSheet = content.Load<Texture2D>("ItemSprites/items_rings");
            rupeesSpriteSheet = content.Load<Texture2D>("ItemSprites/items_rupees");
            triforceSpriteSheet = content.Load<Texture2D>("ItemSprites/items_triforce");
            swordSpriteSheet = content.Load<Texture2D>("ItemSprites/items_swords");
            mapSpriteSheet = content.Load<Texture2D>("ItemSprites/items_map");
            bowSpriteSheet = content.Load<Texture2D>("ItemSprites/items_wooden_bow");
        }

        public IItemSprite CreateArrowSprite()
        {
            return new ArrowSprite(arrowSpriteSheet, 1, 4);
            
        }

        public IItemSprite CreateBlueArrowSprite()
        {
            return new ArrowSprite(blueArrowSpriteSheet, 1, 4);

        }

        public IItemSprite CreateWandSprite()
        {
            return new WandSprite(wandSpriteSheet, 1, 1);
        }

        public IItemSprite CreateMapSprite()
        {
            return new MapSprite(mapSpriteSheet, 1, 1);
        }

        public IItemSprite CreateBowSprite()
        {
            return new BowSprite(bowSpriteSheet, 1, 1);
        }


        public IItemSprite CreateHeartSprite()
        {
            return new HeartSprite(heartSpriteSheet, 1, 1);
        }

        public IItemSprite CreateBombSprite()
        {
            return new BombSprite(bombSpriteSheet, 1, 1);
           
        }

       

        public IItemSprite CreateBoomerangSprite()
        {
            return new BoomerangSprite(boomerangSpriteSheet, 1, 1);
           
        }

        public IItemSprite CreateBottleSprite()
        {
            return new BottleSprite(bottleSpriteSheet, 1, 2);
            
        }

        public IItemSprite CreateBlueBottleSprite()
        {
            return new BlueBottleSprite(bottleSpriteSheet, 1, 2);

        }

        public IItemSprite CreateCandleSprite()
        {
            return new CandleSprite(candleSpriteSheet, 1, 2);
            
        }

        public IItemSprite CreateBlueCandleSprite()
        {
            return new BlueCandleSprite(candleSpriteSheet, 1, 2);
            
        }

        public IItemSprite CreateClockSprite()
        {
            return new ClockSprite(clockSpriteSheet, 1, 1);
            
        }

        public IItemSprite CreateCompassSprite()
        {
            return new CompassSprite(compassSpriteSheet, 1, 1);
            
        }

        public IItemSprite CreateFairySprite()
        {
            return new FairySprite(fairySpriteSheet, 1, 2);
           
        }

        public IItemSprite CreateFluteSprite()
        {
            return new FluteSprite(fluteSpriteSheet, 1, 1);
           
        }

        public IItemSprite CreateHealthSprite()
        {
            return new HealthSprite(healthSpriteSheet, 1, 3);
            
        }

        public IItemSprite CreateHeartContSprite()
        {
            return new HeartContSprite(heartContSpriteSheet, 1, 1);
           
        }
        public IItemSprite CreateKeySprite()
        {
            return new KeySprite(keySpriteSheet, 1, 1);
           
        }
        public IItemSprite CreateRingSprite()
        {
            return new RingSprite(ringSpriteSheet, 1, 2);
            
        }
        public IItemSprite CreateRupeesSprite()
        {
            return new RupeeSprite(rupeesSpriteSheet, 1, 2);
           
        }
        public IItemSprite CreateBlueRupeesSprite()
        {
            return new BlueRupeeSprite(rupeesSpriteSheet, 1, 2);

        }
        public IItemSprite CreateTriforceSprite()
        {
            return new TriforceSprite(triforceSpriteSheet, 1, 1);
            
        }
        public IItemSprite CreateSwordSprite()
        {
            return new SwordSprite(swordSpriteSheet, 1, 2);
            
        }
        public IItemSprite CreateBlueSwordSprite()
        {
            return new BlueSwordSprite(swordSpriteSheet, 1, 2);

        }
        public IItemSprite CreateBlueRingSprite()
        {
            return new BlueRingSprite(ringSpriteSheet, 1, 2);

        }


    }
}
