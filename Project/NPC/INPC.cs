
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface INPC
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);

    }
}
