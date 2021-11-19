using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Text;
using Project.Utilities;

namespace Project.HUD
{

    class SmallHUD : IHUD
    {
        private Vector2 mapPos;
        private Vector2 playerRectPos, triforcePos;
        private ISprite backgroundHUDSprite;
        private ISprite blueMapSprite;
        private ISprite playerRectSprite, triforceRectSprite;
        private IText numCoinsText, numBombsText, numKeysText;
        private IPlayer player;
        private int numCoins, numKeys, numBombs;
        private IHUD healthBar;

        private Vector2 topLeftPos;
        private Vector2 aItemPos;
        private Vector2 bItemPos;
        private ItemType aItemType;
        private ItemType bItemType;
        private IItems aItem;
        private IItems bItem;

        public Vector2 TopLeftPosition { get => topLeftPos; set => topLeftPos = value; }
        public Vector2 PlayerRectPosition { get => playerRectPos; set => playerRectPos = value; }

        public SmallHUD(bool HUDState)
        {
            player = Game1.Instance.Player;
            backgroundHUDSprite = HUDSpriteFactory.Instance.CreateSmallHUDSprite();
            blueMapSprite = HUDSpriteFactory.Instance.CreateBlueMapSprite();
            playerRectSprite = HUDSpriteFactory.Instance.CreatePlayerRectangleSprite();
            if (!HUDState)
            {
                topLeftPos = Vector2.Zero;
            }
            else
            {
                topLeftPos = new Vector2(0, RoomManager.Instance.CurrentRoom.Background.Bounds.Height);
            }
            triforceRectSprite = HUDSpriteFactory.Instance.CreateTriforceRectangleSprite();

            mapPos = new Vector2(topLeftPos.X + 50, topLeftPos.Y + 50);
            aItemPos = new Vector2(topLeftPos.X + 582, topLeftPos.Y + 100);
            bItemPos = new Vector2(topLeftPos.X + 490, topLeftPos.Y + 100);
            aItemType = player.Inventory.AItem;
            bItemType = player.Inventory.BItem;
            aItem = HoldableItemUtilities.GetHoldableItem(aItemType, aItemPos);
            bItem = HoldableItemUtilities.GetHoldableItem(bItemType, bItemPos);

            numCoins = player.Inventory.GetItemCount(ItemType.Rupee);
            numKeys = player.Inventory.GetItemCount(ItemType.Key);
            numBombs = player.Inventory.GetItemCount(ItemType.Bomb);
            numCoinsText = new NumberItemsText(numCoins, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 65));
            numKeysText = new NumberItemsText(numKeys, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 130));
            numBombsText = new NumberItemsText(numBombs, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 160));
            healthBar = new LivesBar(player, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            playerRectPos = HUDUtilities.Instance.GetPlayerRectLocationSmallHUD(topLeftPos);
            triforcePos = HUDUtilities.Instance.GetTriforceRoomPos(topLeftPos);
            backgroundHUDSprite.Draw(spriteBatch, topLeftPos);
            if (player.Inventory.GetItemCount(ItemType.Map) > 0)
            {
                blueMapSprite.Draw(spriteBatch, mapPos);

            }
            if (player.Inventory.GetItemCount(ItemType.Compass) > 0)
            {
                triforceRectSprite.Draw(spriteBatch, triforcePos, Color.Red);
            }
            playerRectSprite.Draw(spriteBatch, playerRectPos, Color.LightGreen);
            numCoinsText.Draw(spriteBatch);
            numKeysText.Draw(spriteBatch);
            numBombsText.Draw(spriteBatch);
            healthBar.Draw(spriteBatch);
            if (aItem != null)
            {
                aItem.Draw(spriteBatch);
            }
            if (bItem != null)
            {
                bItem.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            numCoins = player.Inventory.GetItemCount(ItemType.Rupee);
            numKeys = player.Inventory.GetItemCount(ItemType.Key);
            numBombs = player.Inventory.GetItemCount(ItemType.Bomb);
            ((NumberItemsText)numCoinsText).Number = numCoins;
            ((NumberItemsText)numKeysText).Number = numKeys;
            ((NumberItemsText)numBombsText).Number = numBombs;
            healthBar.Update();
            UpdateABItems();
        }
        private void UpdateABItems()
        {
            if (player.Inventory.AItem != aItemType)
            {
                aItemType = player.Inventory.AItem;
                aItem = HoldableItemUtilities.GetHoldableItem(aItemType, aItemPos);
            }
            if (player.Inventory.BItem != bItemType)
            {
                bItemType = player.Inventory.BItem;
                bItem = HoldableItemUtilities.GetHoldableItem(bItemType, bItemPos);
            }
        }
    }
}