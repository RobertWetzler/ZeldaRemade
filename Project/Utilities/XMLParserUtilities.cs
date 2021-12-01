using Microsoft.Xna.Framework;
using Project.Blocks;
using Project.Blocks.MovableBlock;
using Project.Items;
using Project.NPC.Flame;
using Project.NPC.OldMan;


namespace Project.Utilities
{
    static class XMLParserUtilities
    {
        public static IEnemy GetEnemy(string enemyStr, Vector2 pos, IPlayer player)
        {
            IEnemy enemy = null;
            switch (enemyStr)
            {
                case "Bat":
                    enemy = new Bat(pos, player);
                    break;
                case "Dragon":
                    enemy = new Dragon(pos);
                    break;
                case "Goriya":
                    enemy = new Goriya(pos);
                    break;
                case "Skeleton":
                    enemy = new Skeleton(pos);
                    break;
                case "SmallJelly":
                    enemy = new SmallJelly(pos);
                    break;
                case "Trap":
                    enemy = new Trap(pos, player);
                    break;
                case "WallMaster":
                    enemy = new WallMaster(pos);
                    break;
            }
            return enemy;
        }

        public static INPC GetNPC(string npcStr, Vector2 pos)
        {
            INPC npc = null;
            switch (npcStr)
            {
                case "OldMan":
                    npc = new OldMan(pos);
                    break;
                case "Flame":
                    npc = new Flame(pos);
                    break;
            }
            return npc;
        }

        public static IItems GetItem(string itemStr, Vector2 pos)
        {
            IItems item = null;
            switch (itemStr)
            {
                case "Key":
                    item = new Key(pos);
                    break;
                case "HeartContainer":
                    item = new HeartContainer(pos);
                    break;
                case "Triforce":
                    item = new Triforce(pos);
                    break;
                case "Map":
                    item = new Map(pos);
                    break;
                case "Boomerang":
                    item = new BoomerangItem(pos);
                    break;
                case "Compass":
                    item = new Compass(pos);
                    break;
                case "Bow":
                    item = new Bow(pos);
                    break;
            }
            return item;
        }

        public static IBlock GetBlock(string blockStr, Vector2 pos)
        {
            IBlock block = null;
            switch (blockStr)
            {
                case "Pyramid":
                    block = new PyramidBlock(pos);
                    break;
                case "Stairs":
                    block = new StairBlock(pos);
                    break;
                case "Moveable":
                    block = new MovableBlock(pos);
                    break;
                case "LeftDragon":
                    block = new LeftFacingDragonBlock(pos);
                    break;
                case "RightDragon":
                    block = new RightFacingDragonBlock(pos);
                    break;
                case "Rectangle1":
                    block = new Rectangle1(pos);
                    break;
                case "Rectangle2":
                    block = new Rectangle2(pos);
                    break;
                case "Blue":
                    block = new BlueBlock(pos);
                    break;
                case "Black":
                    block = new BlackBlock(pos);
                    break;
                case "Brick":
                    block = new BrickBlock(pos);
                    break;
            }
            return block;
        }


    }
}
