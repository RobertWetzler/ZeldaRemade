using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GameState
{
    public interface IGameState
    {
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public void Update(GameTime gameTime, Rectangle playerBounds);
    }
}
