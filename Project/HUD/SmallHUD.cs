using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HUD
{
    /**
     * Describe the part of the HUD with the life bar,
     * A/B items, coin/key/bomb counts, and blue map
     */
    class SmallHUD : IHUD
    {
        private int bombs;
        private int coins;
        private int keys;
        private IProjectile aItem;
        private IProjectile bItem;
        private bool showMap;
        private Rectangle playerLocation;

        public SmallHUD()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
