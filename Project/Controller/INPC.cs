using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.CollisionHandler;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
public interface INPC : ICollider
    {
        void Draw(SpriteBatch spriteBatch);
        void Update();
        void TakeDamage();
        void ChangeDirection();
    }
}
