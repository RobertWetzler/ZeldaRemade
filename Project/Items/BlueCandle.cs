﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class BlueCandle : IItem
    {

<<<<<<< HEAD
        private IItemSprite sprite;
        private Vector2 position;

=======
        private ISprite sprite;
        private Vector2 position;
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678
        public BlueCandle(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 3);

        }

        public Rectangle BoundingBox => sprite.DestRectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
