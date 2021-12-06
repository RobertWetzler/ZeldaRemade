using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml;

namespace Project.Utilities
{
    class XMLDoorParser
    {
        private XMLDoorParser()
        {
        }
        public static XMLDoorParser Instance = new XMLDoorParser();

        public List<IDoor> GetDoorsFromRoom(string room)
        {
            List<IDoor> doors = new List<IDoor>();

            using (XmlReader reader = XmlReader.Create(@"Content/XML/Map_Building.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing(room);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "ObjectType"
                        && reader.ReadElementContentAsString() == "Door")
                    {
                        reader.Read();
                        string doorType = reader.ReadElementContentAsString();
                        reader.Read();
                        string doorDirection = reader.ReadElementContentAsString();
                        reader.Read();
                        string strPos = reader.ReadElementContentAsString();
                        float xPos = (float)double.Parse(strPos.Substring(0, strPos.IndexOf(',')));
                        float yPos = (float)double.Parse(strPos.Substring(strPos.IndexOf(',') + 1));
                        Vector2 doorPos = new Vector2(xPos, yPos);
                        

                        IDoor door = GetDoorFromType(doorType, doorDirection, doorPos);
                        doors.Add(door);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == room)
                    {
                        break;
                    }
                }
            }

            return doors;
        }

        private IDoor GetDoorFromType(string doorStr, string direction, Vector2 doorPos)
        {
            IDoor door = null;
            switch (doorStr)
            {
                case "Empty":
                    door = GetWallDoorFromDirection(direction, doorPos);
                    break;
                case "Open":
                    door = GetOpenDoorFromDirection(direction, doorPos);
                    break;
                case "Locked":
                    door = GetLockedDoorFromDirection(direction, doorPos);
                    break;
                case "Closed":
                    door = GetClosedDoorFromDirection(direction, doorPos);
                    break;
                case "Bomb":
                    door = GetBombDoorFromDirection(direction, doorPos);
                    door.CanBeBombed = true;
                    break;
            }
            return door;

        }

        private IDoor GetWallDoorFromDirection(string position, Vector2 doorPos)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.WALL, doorPos);
                case "East":
                    return new EastDoor(DoorType.WALL, doorPos);
                case "South":
                    return new SouthDoor(DoorType.WALL, doorPos);
                case "West":
                    return new WestDoor(DoorType.WALL, doorPos);
            }
            return null;
        }

        private IDoor GetOpenDoorFromDirection(string position, Vector2 doorPos)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.OPEN, doorPos);
                case "East":
                    return new EastDoor(DoorType.OPEN, doorPos);
                case "South":
                    return new SouthDoor(DoorType.OPEN, doorPos);
                case "West":
                    return new WestDoor(DoorType.OPEN, doorPos);
            }
            return null;
        }
        private IDoor GetClosedDoorFromDirection(string position, Vector2 doorPos)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.CLOSED, doorPos);
                case "East":
                    return new EastDoor(DoorType.CLOSED, doorPos);
                case "South":
                    return new SouthDoor(DoorType.CLOSED, doorPos);
                case "West":
                    return new WestDoor(DoorType.CLOSED, doorPos);
            }
            return null;
        }

        private IDoor GetLockedDoorFromDirection(string position, Vector2 doorPos)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.KEY_CLOSED, doorPos);
                case "East":
                    return new EastDoor(DoorType.KEY_CLOSED, doorPos);
                case "South":
                    return new SouthDoor(DoorType.KEY_CLOSED, doorPos);
                case "West":
                    return new WestDoor(DoorType.KEY_CLOSED, doorPos);
            }
            return null;
        }
        private IDoor GetBombDoorFromDirection(string position, Vector2 doorPos)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.WALL, doorPos);
                case "East":
                    return new EastDoor(DoorType.WALL, doorPos);
                case "South":
                    return new SouthDoor(DoorType.WALL, doorPos);
                case "West":
                    return new WestDoor(DoorType.WALL, doorPos);
            }
            return null;
        }

    }


}
