using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Room
{
    public class Room
    {
        
        private List<IItems> items;
        private List<ISprite> blocks;
        private List<INPC> npcs;
        private List<IEntity> entity;
        private List<IEnemy> enemies;
        

        public Room()
        {
            items = new List<IItems>();
            blocks = new List<ISprite>();
            npcs = new List<INPC>();
            entity = new List<IEntity>();
            enemies = new List<IEnemy>();
        }

        
        public void Update(Rectangle rectangle, GameTime gameTime)
        {
            
            foreach (IItems items in items)
            {
                items.Update(gameTime);
            }
            foreach (ISprite blocks in blocks)
            {
                blocks.Update(rectangle, gameTime);
            }
            foreach (INPC npcs in npcs)
            {
                npcs.Update(gameTime);
            }
            foreach (IEntity entity in entity)
            {
                entity.Update(rectangle, gameTime);
            }
            foreach (IEnemy enemies in enemies)
            {
                enemies.Update(rectangle, gameTime);
            }

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Background.Instance.Draw(spriteBatch, graphics);
            foreach (ISprite blocks in blocks)
            {
                blocks.Draw(spriteBatch, gameTime);
            }
            foreach (INPC npcs in npcs)
            {
                npcs.Draw(spriteBatch);
            }
            foreach (IEntity entity in entity)
            {
                entity.Draw(spriteBatch, gameTime);
            }
            foreach (IEnemy enemies in enemies)
            {
                enemies.Draw(spriteBatch, gameTime);
            }

            
        }


    }
}
