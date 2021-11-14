using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Projectiles;
using Project.Sprites;
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

        private bool showMap;
        private Vector2 topLeftPos;

        public bool ShowMap { set => showMap = value; }
        public Vector2 TopLeftPosition { get => topLeftPos; set => topLeftPos = value; }
        public Vector2 PlayerRectPosition { get => playerRectPos; set => playerRectPos = value; }

        public SmallHUD()
        {
            backgroundHUDSprite = HUDSpriteFactory.Instance.CreateSmallHUDSprite();
            blueMapSprite = HUDSpriteFactory.Instance.CreateBlueMapSprite();
            playerRectSprite = HUDSpriteFactory.Instance.CreatePlayerRectangleSprite();
            topLeftPos = Vector2.Zero;
            mapPos = new Vector2(topLeftPos.X + 50, topLeftPos.Y + 50);
            showMap = false;
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

        }

        public void Update()
        {
        }
    }
}
