using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Blocks.MovableBlock;
using Project.Collision;
using Project.Projectiles;
using System.Collections.Generic;
using System.Linq;
using Project.Text;
using Project.Utilities;

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
        private int roomID;
        private IText text;
        private bool noEnemies;
        private int northRoomID;
        private int southRoomID;
        private int eastRoomID;
        private int westRoomID;
    

        public int RoomID { get => roomID; }
        public Room NorthRoom => RoomUtilities.IdToRoom[northRoomID];
        public Room SouthRoom => RoomUtilities.IdToRoom[southRoomID];
        public Room EastRoom => RoomUtilities.IdToRoom[eastRoomID];
        public Room WestRoom => RoomUtilities.IdToRoom[westRoomID];
        public List<ICollidable> Statics => items.Cast<ICollidable>().Concat(blocks.FindAll(b => !(b is MovableBlock))).ToList();
        public List<ICollidable> Dynamics => npcs.Cast<ICollidable>().Concat(enemies).Concat(projectiles).Concat(blocks.FindAll(b => b is MovableBlock)).ToList();
        public Room(int id, Background background, int northRoom, int southRoom, int eastRoom, int westRoom, List<IItems> items, List<IBlock> blocks,
                    List<INPC> npcs, List<IEnemy> enemies)
        {
            this.roomID = id;
            this.background = background;
            this.items = items;
            this.blocks = blocks;
            this.npcs = npcs;
            this.enemies = enemies;
            this.projectiles = new List<IProjectile>();
            this.text = new OldManText();
            this.noEnemies = false;
            this.westRoomID = westRoom;
            this.northRoomID = northRoom;
            this.southRoomID = southRoom;
            this.eastRoomID = eastRoom;
       
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
        public void Update(Rectangle windowBounds, GameTime gameTime)
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
                enemies.Update(windowBounds, gameTime);
            }
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Update(gameTime);
            }
            if (roomID == 1)
            {
                text.Update(gameTime);
            }
            projectiles.RemoveAll(p => p.IsFinished);
            if (this.enemies.Count == 0)
            {
                noEnemies = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.background.Draw(spriteBatch);
            foreach (IBlock block in blocks)
            {
                block.Draw(spriteBatch);
            }
            foreach (INPC npc in npcs)
            {
                npc.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch, gameTime);
            }
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
            if (noEnemies)
            {
                foreach (IItems item in items)
                {
                    item.Draw(spriteBatch);
                }
            }
            if (roomID == 1)
            {
                text.Draw(spriteBatch, gameTime);
            }
        }
    }
}
