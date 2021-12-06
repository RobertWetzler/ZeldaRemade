using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Blocks.MovableBlock;
using Project.Blocks.Walls;
using Project.Collision;
using Project.Projectiles;
using Project.Text;
using Project.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    public class Room
    {
        private Background background;
        private List<IItems> items;
        private List<IItems> randomItems;
        private List<IBlock> blocks;
        private List<INPC> npcs;
        private List<IEnemy> enemies;
        private List<IProjectile> projectiles;
        private List<IDoor> doors;
        private List<Torch> torches;
        private int roomID;
        private IText text;
        private bool noEnemies;
        private int northRoomID;
        private int southRoomID;
        private int eastRoomID;
        private int westRoomID;


        public int RoomID { get => roomID; }
        public Room NorthRoom => RoomManager.GetRoom(northRoomID);
        public Room SouthRoom => RoomManager.GetRoom(southRoomID);
        public Room EastRoom => RoomManager.GetRoom(eastRoomID);
        public Room WestRoom => RoomManager.GetRoom(westRoomID);
        public Background Background => background;
        public List<ICollidable> Statics => items.Cast<ICollidable>().Concat(blocks.FindAll(b => !(b is MovableBlock))).Concat(doors).Concat(randomItems).ToList();
        public List<ICollidable> Dynamics => npcs.Cast<ICollidable>().Concat(enemies).Concat(projectiles).Concat(blocks.FindAll(b => b is MovableBlock)).ToList();
        public List<IDoor> Doors => doors;
        public Room(int id, Background background, int northRoom, int southRoom, int eastRoom, int westRoom, List<IItems> items, List<IBlock> blocks,
                    List<INPC> npcs, List<IEnemy> enemies, List<IDoor> doors, List<Torch> torches)
        {
            this.roomID = id;
            this.background = background;
            this.items = items;
            this.randomItems = new List<IItems>();
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
            this.doors = doors;
            this.torches = torches;

            blocks.AddRange(WallCreator.CreateWalls(this.background.Bounds, this.doors));
        }

        public void AddItem(IItems item)
        {
            items.Add(item);
        }
        public void RemoveItem(IItems item)
        {
            items.Remove(item);
        }
        public void AddRandomItem(IItems item)
        {
            randomItems.Add(item);
        }
        public void RemoveRandomItem(IItems item)
        {
            randomItems.Remove(item);
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
            foreach (Torch torch in torches)
            {
                torch.Update(gameTime);
            }
            foreach (INPC npcs in npcs)
            {
                npcs.Update(gameTime);
            }
            foreach (IItems item in items)
            {
                item.Update(gameTime);
            }
            foreach (IItems item in randomItems)
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
                if (roomID != 3)
                {
                    DoorUtilities.UnlockClosedDoors();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.background.Draw(spriteBatch);
            foreach (IDoor door in doors)
            {
                door.Draw(spriteBatch);
            }
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
            foreach (IItems item in randomItems)
            {
                item.Draw(spriteBatch);
            }
            foreach (Torch torch in torches)
            {
                torch.Draw(spriteBatch);
            }

            if (noEnemies)
            {
                foreach (IItems item in items)
                {
                    item.Draw(spriteBatch);
                }
            }
            else
            {
                foreach (IItems item in items)
                {
                    if (item.type == ItemType.Triforce || item.type == ItemType.Bow || item.type == ItemType.Map 
                        || item.type == ItemType.Compass)
                    {
                        item.Draw(spriteBatch);
                    }
            
                }
            }
        }
        public void DrawForeground(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (IDoor door in doors)
            {
                door.DrawForeground(spriteBatch);
            }
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
            if (roomID == 1)
            {
                text.Draw(spriteBatch);
            }
        }
    }
}
