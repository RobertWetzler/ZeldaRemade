using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HUD
{
    class HardButton
    {
        ISprite sprite;
        public HardButton()
        {
            sprite = HUDSpriteFactory.Instance.CreateHardButtonSprite();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(370, 800));
        }

        public void Update(GameTime gameTime)
        {
            if(GameOptions.IsHarderVersion)
                sprite.Update(gameTime);
        }
    }
}
