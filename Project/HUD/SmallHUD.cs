using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Projectiles;
using Project.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HUD
{

    class SmallHUD : IHUD
    {
        private ISprite backgroundHUDSprite;
        private ISprite blueMapSprite;
        private int bombs;
        private int coins;
        private int keys;
        private int lives;
        private IProjectile aItem;
        private IProjectile bItem;
        private bool showMap;
        private Rectangle playerLocation;
        private Vector2 topLeftPos;

        public bool ShowMap { set => showMap = value; }

        public SmallHUD()
        {
            backgroundHUDSprite = HUDSpriteFactory.Instance.CreateSmallHUDSprite();
            blueMapSprite = HUDSpriteFactory.Instance.CreateBlueMapSprite();
            topLeftPos = Vector2.Zero;
            lives = 3;
            coins = 0;
            keys = 0;
            bombs = 3;
            showMap = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundHUDSprite.Draw(spriteBatch, topLeftPos);
            if (showMap)
            {
                blueMapSprite.Draw(spriteBatch, new Vector2(topLeftPos.X + 50, topLeftPos.Y + 50));
            }
          
        }

        public int GetLives()
        {
            return lives;
        }

        public void Death()
        {
            lives--;
        }

        public void Update()
        {
        }
    }
}
