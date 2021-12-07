using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Utilities;

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
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            itemSelectionScreen.Draw(spriteBatch);
            itemSelector.Draw(spriteBatch);

            itemType = ItemSelectionUtilities.IdToItem[Game1.Instance.ItemIdx];
            if (ItemSelectionUtilities.IdToItem.ContainsKey(game.ItemIdx) && player.Inventory.GetItemCount(itemType) > 0)
            {
                equipableItem = ItemSelectionUtilities.GetSelectedItem(itemType, itemSelectedPosition);
                equipableItem.Draw(spriteBatch);

                Game1.Instance.getItem = itemType;
            }
            else
            {
                Game1.Instance.getItem = ItemType.Null;
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
