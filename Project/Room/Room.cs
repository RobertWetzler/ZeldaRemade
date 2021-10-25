using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<IProjectile> projectiles;

        public List<ICollidable> Statics => items.Cast<ICollidable>().Concat(blocks).ToList();
        public List<ICollidable> Dynamics => npcs.Cast<ICollidable>().Concat(enemies).Concat(projectiles).ToList();
        public Room(Background background, List<IItems> items, List<IBlock> blocks,
                    List<INPC> npcs, List<IEnemy> enemies)
        {
            this.background = background;
            this.items = items;
            this.blocks = blocks;
            this.npcs = npcs;
            this.enemies = enemies;
            this.projectiles = new List<IProjectile>();
        }
        public void AddItem(IItems item)
        {
            items.Add(item);
        }
        public void RemoveItem(IItems item)
        {
            items.Remove(item);
        }
        public void AddProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);
        }
        public void RemoveProjectile(IProjectile projectile)
        {
            projectiles.Remove(projectile);
        }
        public void AddEnemy(IEnemy enemy)
        {
            enemies.Add(enemy);
        }
        public void RemoveEnemy(IEnemy enemy)
        {
            enemies.Remove(enemy);
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
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Update(gameTime);
            }
            projectiles.RemoveAll(p => p.IsFinished);
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
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
        }
    }
}
