using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;

namespace Project.Utilities
{
    class XMLTorchParser
    {
        private XMLTorchParser()
        {
        }
        public static XMLTorchParser Instance = new XMLTorchParser();

        public List<Torch> GetTorchFromRoom(string room)
        {
            List<Torch> torches = new List<Torch>();
            Torch torch;

            using (XmlReader reader = XmlReader.Create(@"../../../Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "Torch")
                    {
                        reader.Read();
                        string strPos = reader.ReadElementContentAsString();
                        float xPos = (float)double.Parse(strPos.Substring(0, strPos.IndexOf(',')));
                        float yPos = (float)double.Parse(strPos.Substring(strPos.IndexOf(',') + 1));
                        Vector2 torchPos = new Vector2(xPos, yPos);
                        reader.Read();
                        string strDir = reader.ReadElementContentAsString();

                        torch = GetTorchFromDirection(strDir, torchPos);
                        torches.Add(torch);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }
            return torches;
        }


        private Torch GetTorchFromDirection(string direction, Vector2 pos)
        {
            switch (direction)
            {
                case "North":
                    return new Torch(pos, false, false);
                case "South":
                    return new Torch(pos, true, false);
                case "West":
                    return new Torch(pos, true, true);
                case "East":
                    return new Torch(pos, false, true);
            }
            return null;
        }


    }


}
