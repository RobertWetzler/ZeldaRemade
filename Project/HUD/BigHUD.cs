using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Utilities;
using System.Collections.Generic;

namespace Project.HUD
{
    class BigHUD : IHUD
    {
        private Game1 game;
        private ItemSelectionScreen itemSelectionScreen;
        private ItemSelectionBox itemSelector;
        private IItems equipableItem;
        private Vector2 itemSelectedPosition;
        private IPlayer player;
        private ItemType itemType; 
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

        }
        public void Update(GameTime gameTime)
        {
            itemType = ItemSelectionUtilities.IdToItem[Game1.Instance.ItemIdx];
            itemSelectionScreen.Update(gameTime);
            itemSelector.Update(gameTime);
            posDot.Update();
            //ItemSelectionUtilities.UpdateAllInventoryItems();
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            itemSelectionScreen.Draw(spriteBatch);
            itemSelector.Draw(spriteBatch);

            if (ItemSelectionUtilities.IdToItem.ContainsKey(game.ItemIdx) && player.Inventory.GetItemCount(itemType) > 0)
            {
                equipableItem =  ItemSelectionUtilities.GetSelectedItem(itemType,itemSelectedPosition);
                equipableItem.Draw(spriteBatch);

                Game1.Instance.getItem = itemType;
            }

            foreach (IItems item in ItemSelectionUtilities.InventoryItems)
            {
                item.Draw(spriteBatch);
            }
            
            mapTiles.Draw(spriteBatch);
            posDot.Draw(spriteBatch);
        }
        public void Update() { }
    }
}
