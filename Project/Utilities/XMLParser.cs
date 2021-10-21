using Microsoft.Xna.Framework;
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
        private XmlReader reader;
        private static int X_OFFSET = 16;
        private static int Y_OFFSET = 16;
        private static int BLOCK_WIDTH = 64;
        private XMLParser()
        {
            reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml");
        }
        public static XMLParser instance = new XMLParser();
        public List<IEnemy> GetEnemiesFromRoom(string room)
        {
            List<IEnemy> enemies = new List<IEnemy>();
            IEnemy enemy;

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
                    return enemies;
                }
            }

            return enemies;
        }

        private IEnemy GetEnemy(string enemyStr, Vector2 pos)
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
    }
}
