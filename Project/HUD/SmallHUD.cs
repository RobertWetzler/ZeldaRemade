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
        private Vector2 playerRectPos;
        private ISprite backgroundHUDSprite;
        private ISprite blueMapSprite;
        private ISprite playerRectSprite;
        private IText numCoinsText, numBombsText, numKeysText;
        private int numCoins, numBombs, numKeys;

        private bool showMap;
        private Vector2 topLeftPos;

        public bool ShowMap { set => showMap = value; }
        public Vector2 TopLeftPosition { get => topLeftPos; set => topLeftPos = value; }
        public Vector2 PlayerRectPosition { get => playerRectPos; set => playerRectPos = value; }

        public SmallHUD(bool HUDState)
        {
            backgroundHUDSprite = HUDSpriteFactory.Instance.CreateSmallHUDSprite();
            blueMapSprite = HUDSpriteFactory.Instance.CreateBlueMapSprite();
            playerRectSprite = HUDSpriteFactory.Instance.CreatePlayerRectangleSprite();
            if (!HUDState)
            {
                topLeftPos = Vector2.Zero;
            }
            else
            {
                topLeftPos = new Vector2(0, 700);   // need to change
            }
            mapPos = new Vector2(topLeftPos.X + 50, topLeftPos.Y + 50);
            showMap = false;
            numCoins = 0; 
            numBombs = 10; 
            numKeys = 0;
            numCoinsText = new NumberItemsText(numCoins, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 65));
            numKeysText = new NumberItemsText(numKeys, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 130));
            numBombsText = new NumberItemsText(numBombs, new Vector2(topLeftPos.X + 390, topLeftPos.Y + 160));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerRectPos = HUDUtilities.Instance.GetPlayerRectLocationSmallHUD(topLeftPos);
            backgroundHUDSprite.Draw(spriteBatch, topLeftPos);
            if (showMap)
            {
                blueMapSprite.Draw(spriteBatch, mapPos);
                
            }
            playerRectSprite.Draw(spriteBatch, playerRectPos, Color.LightGreen);
            numCoinsText.Draw(spriteBatch);
            numKeysText.Draw(spriteBatch);
            numBombsText.Draw(spriteBatch);
        }

        public void Update()
        {
        }
    }
}
