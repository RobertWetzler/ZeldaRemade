using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface INPCState
    {
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void Update();
    }
}
