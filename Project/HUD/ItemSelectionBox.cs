using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HUD
{
    class ItemSelectionBox : IHUD
    {
        ISprite sprite;
        public ItemSelectionBox()
        {
            sprite = HUDSpriteFactory.Instance.CreateItemSelectionBoxSprite();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //sprite.Draw
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
