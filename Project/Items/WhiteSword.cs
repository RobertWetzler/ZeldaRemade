﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class WhiteSword : IItems
    {

        private IItemSprite sprite;


        public WhiteSword()
        {

            sprite = ItemSpriteFactory.Instance.CreateItemSprite(1, 10);

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
