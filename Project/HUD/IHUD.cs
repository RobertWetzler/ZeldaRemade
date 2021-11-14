using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.HUD
{
    public interface IHUD
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
