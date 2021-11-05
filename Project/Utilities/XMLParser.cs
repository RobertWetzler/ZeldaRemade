using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;

namespace Project.Utilities
{
    class XMLParser
    {

        private static int X_OFFSET = 128;
        private static int Y_OFFSET = 126;
        private static int BLOCK_WIDTH = 64;
        private static int BLOCK_HEIGHT = 64;
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
                        float xPos = (float)double.Parse(strPos.Substring(0, strPos.IndexOf(' ')));
                        float yPos = (float)double.Parse(strPos.Substring(strPos.IndexOf(' ') + 1));
                        xPos = (xPos * BLOCK_WIDTH) + X_OFFSET;
                        yPos = (yPos * BLOCK_HEIGHT) + Y_OFFSET;
                        enemy = XMLParserUtilities.GetEnemy(enemyType, new Vector2(xPos, yPos));
                        enemies.Add(enemy);
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
                        float xPos = (float)double.Parse(strPos.Substring(0, strPos.IndexOf(' ')));
                        float yPos = (float)double.Parse(strPos.Substring(strPos.IndexOf(' ') + 1));
                        xPos = (xPos * BLOCK_WIDTH) + X_OFFSET;
                        yPos = (yPos * BLOCK_HEIGHT) + Y_OFFSET;
                        npc = XMLParserUtilities.GetNPC(npcType, new Vector2(xPos, yPos));
                        npcs.Add(npc);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }


            return npcs;
        }

        public List<IItems> GetItemsFromRoom(string room)
        {
            List<IItems> items = new List<IItems>();
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
                        yPos = (yPos * BLOCK_HEIGHT) + Y_OFFSET;
                        item = XMLParserUtilities.GetItem(itemType, new Vector2(xPos, yPos));
                        items.Add(item);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return items;
        }

        public List<IBlock> GetBlocksFromRoom(string room)
        {
            List<IBlock> blocks = new List<IBlock>();
            IBlock block;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "Block")
                    {
                        reader.Read();
                        string blockType = reader.ReadElementContentAsString();
                        reader.Read();
                        string strPos = reader.ReadElementContentAsString();
                        float xPos = (float)double.Parse(strPos.Substring(0, strPos.IndexOf(' ')));
                        float yPos = (float)double.Parse(strPos.Substring(strPos.IndexOf(' ') + 1));
                        xPos = (xPos * BLOCK_WIDTH) + X_OFFSET;
                        yPos = (yPos * BLOCK_HEIGHT) + Y_OFFSET;
                        block = XMLParserUtilities.GetBlock(blockType, new Vector2(xPos, yPos));
                        blocks.Add(block);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return blocks;
        }

        public Background GetBackgroundFromRoom(string room)
        {
            Background background = null;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "Background")
                    {
                        reader.Read();
                        string roomNumber = reader.ReadElementContentAsString();
                        background = new Background(roomNumber);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return background;
        }
    }
}
