using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;

namespace Project.NPC
{
    class NPCSpawning : INPCState
    {
        private IEnemySprite sprite;

        public NPCSpawning()
        {
            sprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
        }
        public IEnemySprite Sprite => sprite;

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
