using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.BlockSprites
{
    public interface IBlock
    {
        //drawing sprite and position of it on screen
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        
        // most blocks do not move
        void Update();
    }
}
