using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public interface IEnemySprite
    {
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void Update();
    }
}
