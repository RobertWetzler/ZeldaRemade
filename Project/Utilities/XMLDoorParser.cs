using System.Collections.Generic;
using System.Xml;
using Project.Rooms.Doors;

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
                        string doorPos = reader.ReadElementContentAsString();

                        IDoor door = GetDoorFromType(doorType, doorPos);
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

        private IDoor GetDoorFromType(string doorStr, string position)
        {
            IDoor door = null;
            switch (doorStr)
            {
                case "Empty":
                    door = GetWallDoorFromPosition(position);
                    break;
                case "Open":
                    door = GetOpenDoorFromPosition(position);
                    break;
                case "Locked":
                    door = GetLockedDoorFromPosition(position);
                    break;
                case "Closed":
                    door = GetClosedDoorFromPosition(position);
                    break;
                case "Bomb":
                    door = GetBombDoorFromPosition(position);
                    break;
                case "Hidden":
                    door = new HiddenDoor();
                    break;
            }
            return door;

        }

        private IDoor GetWallDoorFromPosition(string position)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.WALL);
                case "East":
                    return new EastDoor(DoorType.WALL);
                case "South":
                    return new SouthDoor(DoorType.WALL);
                case "West":
                    return new WestDoor(DoorType.WALL);
            }
            return null;
        }

        private IDoor GetOpenDoorFromPosition(string position)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.OPEN);
                case "East":
                    return new EastDoor(DoorType.OPEN);
                case "South":
                    return new SouthDoor(DoorType.OPEN);
                case "West":
                    return new WestDoor(DoorType.OPEN);
            }
            return null;
        }
        private IDoor GetClosedDoorFromPosition(string position)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.CLOSED);
                case "East":
                    return new EastDoor(DoorType.CLOSED);
                case "South":
                    return new SouthDoor(DoorType.CLOSED);
                case "West":
                    return new WestDoor(DoorType.CLOSED);
            }
            return null;
        }

        private IDoor GetLockedDoorFromPosition(string position)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.KEY_CLOSED);
                case "East":
                    return new EastDoor(DoorType.KEY_CLOSED);
                case "South":
                    return new SouthDoor(DoorType.KEY_CLOSED);
                case "West":
                    return new WestDoor(DoorType.KEY_CLOSED);
            }
            return null;
        }
        private IDoor GetBombDoorFromPosition(string position)
        {
            switch (position)
            {
                case "North":
                    return new NorthDoor(DoorType.BOMB_CLOSED);
                case "East":
                    return new EastDoor(DoorType.BOMB_CLOSED);
                case "South":
                    return new SouthDoor(DoorType.BOMB_CLOSED);
                case "West":
                    return new WestDoor(DoorType.BOMB_CLOSED);
            }
            return null;
        }

    }


}
