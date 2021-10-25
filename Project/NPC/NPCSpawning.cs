using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;

namespace Project.NPC
{
    class NPCSpawning : INPCState
    {
        private ISprite sprite;

        public NPCSpawning()
        {
            sprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
        }
        public ISprite Sprite => sprite;

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            sprite.Draw(spriteBatch, pos);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
