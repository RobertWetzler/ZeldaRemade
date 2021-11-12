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
        private int bombs;
        private int coins;
        private int keys;
        private int lives;
        private IProjectile aItem;
        private IProjectile bItem;
        private bool showMap;
        private Rectangle playerLocation;
        private Vector2 topLeftPos;

        public SmallHUD()
        {
            backgroundHUDSprite = HUDSpriteFactory.Instance.CreateSmallHUDSprite();
            topLeftPos = Vector2.Zero;
            lives = 3;
            coins = 0;
            keys = 0;
            bombs = 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundHUDSprite.Draw(spriteBatch, topLeftPos);
        }

        public void Update()
        {
        }
    }
}
