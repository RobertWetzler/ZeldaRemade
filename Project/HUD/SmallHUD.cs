using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Projectiles;
using Project.Sprites;
using Project.Text;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

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

        private Vector2 topLeftPos;

        public Vector2 TopLeftPosition { get => topLeftPos; set => topLeftPos = value; }
        public Vector2 PlayerRectPosition { get => playerRectPos; set => playerRectPos = value; }

        public SmallHUD(IPlayer player)
        {
            this.player = player;
            backgroundHUDSprite = HUDSpriteFactory.Instance.CreateSmallHUDSprite();
            blueMapSprite = HUDSpriteFactory.Instance.CreateBlueMapSprite();
            playerRectSprite = HUDSpriteFactory.Instance.CreatePlayerRectangleSprite();
            triforceRectSprite = HUDSpriteFactory.Instance.CreateTriforceRectangleSprite();
            topLeftPos = Vector2.Zero;
            mapPos = new Vector2(topLeftPos.X + 50, topLeftPos.Y + 50);

            numCoins = player.Inventory.GetItemCount(ItemType.Rupee);
            numKeys = player.Inventory.GetItemCount(ItemType.Key);
            numBombs = player.Inventory.GetItemCount(ItemType.Bomb);
            numCoinsText = new NumberItemsText(numCoins, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 65));
            numKeysText = new NumberItemsText(numKeys, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 130));
            numBombsText = new NumberItemsText(numBombs, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 160));
            
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

        }

        public void Update()
        {
            numCoins = player.Inventory.GetItemCount(ItemType.Rupee);
            numKeys = player.Inventory.GetItemCount(ItemType.Key); 
            numBombs = player.Inventory.GetItemCount(ItemType.Bomb);
            numCoinsText = new NumberItemsText(numCoins, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 65));
            numKeysText = new NumberItemsText(numKeys, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 130));
            numBombsText = new NumberItemsText(numBombs, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 160));
        }
    }
}
