﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;

namespace Project.Items
{
    class PyramidBlock : IBlockSprite
    {

        private IBlockSprite block;


        public PyramidBlock()
        {

            block = BlockSpriteFactory.Instance.CreatePyramidBlockSprite();

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            block.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            block.Update(gameTime);
        }
    }
}