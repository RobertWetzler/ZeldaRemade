using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.HUD
{
    class BigHUD : IHUD
    {
        private Game1 game;
        private ItemSelectionScreen itemSelectionScreen;
        private ItemSelectionBox itemSelector;
        private ISprite blueBoomerang, boomerang, sword, bow, blueCandle, map, compass;
        private Vector2 itemSelectedPosition;
        private IPlayer player;
        private MapTiles mapTiles;
        private PositionDot posDot;

        public BigHUD(Game1 game)
        {
            this.game = game;
            this.player = game.Player;
            itemSelector = new ItemSelectionBox(game);
            mapTiles = new MapTiles(game);
            posDot = new PositionDot();
            itemSelectedPosition = new Vector2(245, 180);
            this.itemSelectionScreen = new ItemSelectionScreen(game.Graphics);

            blueBoomerang = ItemSpriteFactory.Instance.CreateItemSprite(1, 1);
            boomerang = ItemSpriteFactory.Instance.CreateItemSprite(1, 0);
            sword = ItemSpriteFactory.Instance.CreateItemSprite(0, 10);
            bow = ItemSpriteFactory.Instance.CreateItemSprite(0, 7);
            blueCandle = ItemSpriteFactory.Instance.CreateItemSprite(0, 3);
            map = ItemSpriteFactory.Instance.CreateItemSprite(1, 8);
            compass = ItemSpriteFactory.Instance.CreateItemSprite(1, 9);
        }
        public void Update(GameTime gameTime)
        {
            itemSelectionScreen.Update(gameTime);
            itemSelector.Update(gameTime);
            posDot.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            /*
             * Display big HUD screen
             */
            itemSelectionScreen.Draw(spriteBatch);
            itemSelector.Draw(spriteBatch);
            /*
             * Displays Items in the Selected box 
             */
            if (game.ItemIdx == 0 && player.Inventory.GetItemCount(ItemType.Blue_Boomerang) > 0)
            {
                blueBoomerang.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Blue_Boomerang;
            }

            if (game.ItemIdx == 1 && player.Inventory.GetItemCount(ItemType.Blue_Candle) > 0)
            {
                blueCandle.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Blue_Candle;
            }

            if (game.ItemIdx == 2 && player.Inventory.GetItemCount(ItemType.Bow) > 0)
            {
                bow.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Bow;
            }

            if (game.ItemIdx == 3 && player.Inventory.GetItemCount(ItemType.Boomerang) > 0)
            {
                boomerang.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Boomerang;
            }

            if (game.ItemIdx == 4 && player.Inventory.GetItemCount(ItemType.Sword) > 0)
            {
                sword.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Sword;
            }
            /*
             * Displays Items in the inventory box          
             */
            if (player.Inventory.GetItemCount(ItemType.Blue_Boomerang) > 0)
                blueBoomerang.Draw(spriteBatch, new Vector2(500, 180));

            if (player.Inventory.GetItemCount(ItemType.Blue_Candle) > 0)
                blueCandle.Draw(spriteBatch, new Vector2(600, 180));

            if (player.Inventory.GetItemCount(ItemType.Bow) > 0)
                bow.Draw(spriteBatch, new Vector2(700, 180));

            if (player.Inventory.GetItemCount(ItemType.Boomerang) > 0)
                boomerang.Draw(spriteBatch, new Vector2(800, 180));

            if (player.Inventory.GetItemCount(ItemType.Sword) > 0)
                sword.Draw(spriteBatch, new Vector2(500, 250));

            if (player.Inventory.GetItemCount(ItemType.Map) > 0)
                map.Draw(spriteBatch, new Vector2(165, 440));

            if (player.Inventory.GetItemCount(ItemType.Compass) > 0)
                compass.Draw(spriteBatch, new Vector2(165, 600));

            mapTiles.Draw(spriteBatch);
            posDot.Draw(spriteBatch);
        }
        public void Update() { }
    }
}
