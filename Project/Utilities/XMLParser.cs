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
        private XMLParser()
        {
            reader = XmlReader.Create(@"../../../XML/mapbuilding.xml");
        }
        public static XMLParser instance = new XMLParser();
        public (List<IItems>, List<IEnemy>, List<INPC>) GetObjectsFromRoom(string room)
        {
            //Add background
            List<IEnemy> enemies = new List<IEnemy>();
            List<IItems> items = new List<IItems>();
            List<INPC> npcs = new List<INPC>();
            //Add blocks

            reader.MoveToContent();
            reader.ReadToFollowing(room);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType")
                {
                    Debug.WriteLine(" Type: " + reader.ReadElementContentAsString());
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectName")
                {
                    Debug.WriteLine(" Type: " + reader.ReadElementContentAsString());
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "Position")
                {
                    Debug.WriteLine(" Position: " + reader.ReadElementContentAsString());
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                {
                    return (items, enemies, npcs);
                }
            }

            return (items, enemies, npcs);
        }


    }
}
