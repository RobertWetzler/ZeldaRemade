using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Room
    {
        private Background background;
        private List<IItems> items;
        private List<IBlock> blocks;
        private List<INPC> npcs;
        private List<IEnemy> enemies;
        

        public Room(Background background, List<IItems> items, List<IBlock> blocks,
                    List<INPC> npcs, List<IEnemy> enemies)
        {
            this.background = background;
            this.items = items;
            this.blocks = blocks;
            this.npcs = npcs;
            this.enemies = enemies;
        }

        
        public void Update(Rectangle rectangle, GameTime gameTime)
        {
            foreach (IBlock blocks in blocks)
            {
                blocks.Update(gameTime);
            }
            foreach (INPC npcs in npcs)
            {
                npcs.Update(gameTime);
            }
            foreach (IItems item in items)
            {
                item.Update(gameTime);
            }
            foreach (IEnemy enemies in enemies)
            {
                enemies.Update(rectangle, gameTime);
            }

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            this.background.Draw(spriteBatch, graphics);
            foreach (IBlock block in blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (INPC npc in npcs)
            {
                npc.Draw(spriteBatch);
            }
            foreach (IItems item in items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch, gameTime);
            }
        }


    }
}
