using Microsoft.Xna.Framework;
using Project.Items;
using Project.NPC.Flame;
using Project.NPC.OldMan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace Project.Utilities
{
    class XMLParser
    {

        private static int X_OFFSET = 16;
        private static int Y_OFFSET = 16;
        private static int BLOCK_WIDTH = 64;
        private XMLParser()
        {
        }
        public static XMLParser instance = new XMLParser();
        public List<IEnemy> GetEnemiesFromRoom(string room)
        {
            List<IEnemy> enemies = new List<IEnemy>();
            IEnemy enemy;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "Enemy")
                    {

                        reader.Read();
                        string enemyType = reader.ReadElementContentAsString();
                        reader.Read();
                        string strPos = reader.ReadElementContentAsString();
                        float xPos = int.Parse(strPos.Substring(0, strPos.IndexOf(' ')));
                        float yPos = int.Parse(strPos.Substring(strPos.IndexOf(' ') + 1));
                        xPos = (xPos * BLOCK_WIDTH) + X_OFFSET;
                        yPos = (yPos * BLOCK_WIDTH) + Y_OFFSET;
                        enemy = GetEnemy(enemyType, new Vector2(xPos, yPos));
                        enemies.Add(enemy);
                        Debug.WriteLine(" Enemy " + enemyType + " in " + room + " at (" + xPos + ", " + yPos + ")");
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }


            return enemies;
        }

        public List<INPC> GetNPCSFromRoom(string room)
        {
            List<INPC> npcs = new List<INPC>();
            INPC npc;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "NPC")
                    {

                        reader.Read();
                        string npcType = reader.ReadElementContentAsString();
                        reader.Read();
                        string strPos = reader.ReadElementContentAsString();
                        float xPos = int.Parse(strPos.Substring(0, strPos.IndexOf(' ')));
                        float yPos = int.Parse(strPos.Substring(strPos.IndexOf(' ') + 1));
                        xPos = (xPos * BLOCK_WIDTH) + X_OFFSET;
                        yPos = (yPos * BLOCK_WIDTH) + Y_OFFSET;
                        npc = GetNPC(npcType, new Vector2(xPos, yPos));
                        npcs.Add(npc);
                        Debug.WriteLine(" NPC " + npcType + " in " + room + " at (" + xPos + ", " + yPos + ")");
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
                

            return npcs;
        }

        public List<(IItems, Vector2)> GetItemsFromRoom(string room)
        {
            List<(IItems, Vector2)> items = new List<(IItems, Vector2)>();
            IItems item;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "Item")
                    {

                        reader.Read();
                        string itemType = reader.ReadElementContentAsString();
                        reader.Read();
                        string strPos = reader.ReadElementContentAsString();
                        float xPos = (float)double.Parse(strPos.Substring(0, strPos.IndexOf(' ')));
                        float yPos = (float)double.Parse(strPos.Substring(strPos.IndexOf(' ') + 1));
                        xPos = (xPos * BLOCK_WIDTH) + X_OFFSET;
                        yPos = (yPos * BLOCK_WIDTH) + Y_OFFSET;
                        item = GetItem(itemType);
                        items.Add((item, new Vector2(xPos, yPos)));
                        Debug.WriteLine(" Item " + itemType + " in " + room + " at (" + xPos + ", " + yPos + ")");
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return items;
        }

        private static IEnemy GetEnemy(string enemyStr, Vector2 pos)
        {
            IEnemy enemy = null;
            switch (enemyStr)
            {
                case "Bat":
                    enemy = new Bat(pos);
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
                    enemy = new Trap(pos);
                    break;
                case "WallMaster":
                    enemy = new WallMaster(pos);
                    break;
            }
            return enemy;
        }

        private static INPC GetNPC(string npcStr, Vector2 pos)
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

        private static IItems GetItem(string itemStr)
        {
            IItems item = null;
            switch (itemStr)
            {
                case "Key":
                    item = new Key();
                    break;
                case "HeartContainer":
                    item = new HeartContainer();
                    break;
                case "Triforce":
                    item = new Triforce();
                    break;
            }
            return item;
        }
    }
}
