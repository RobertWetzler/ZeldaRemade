using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;

namespace Project.Utilities
{
    class XMLAdjacentRoomParser
    {
        public static XMLAdjacentRoomParser instance = new XMLAdjacentRoomParser();
        public int GetNorthRoomFromRoom(string room)
        {
            int northRoomID = 0;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "NorthRoom")
                    {
                        reader.Read();
                        string roomNumber = reader.ReadElementContentAsString();
                        northRoomID = int.Parse(roomNumber);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return northRoomID;
        }
        public int GetSouthRoomFromRoom(string room)
        {
            int southRoomID = 0;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "SouthRoom")
                    {
                        reader.Read();
                        string roomNumber = reader.ReadElementContentAsString();
                        southRoomID = int.Parse(roomNumber);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return southRoomID;
        }
        public int GetEastRoomFromRoom(string room)
        {
            int eastRoomID = 0;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "NorthRoom")
                    {
                        reader.Read();
                        string roomNumber = reader.ReadElementContentAsString();
                        eastRoomID = int.Parse(roomNumber);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return eastRoomID;
        }
        public int GetWestRoomFromRoom(string room)
        {
            int westRoomID = 0;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "NorthRoom")
                    {
                        reader.Read();
                        string roomNumber = reader.ReadElementContentAsString();
                        westRoomID = int.Parse(roomNumber);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return westRoomID;
        }
    }
}
