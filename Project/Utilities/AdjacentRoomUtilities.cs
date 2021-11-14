using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Utilities
{
    class AdjacentRoomUtilities
    {
        public static Room NorthRoom(int roomID, IPlayer player)
        { 

            string currentRoom = "Room" + roomID;
                List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
                List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
                List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
                List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
                Room room = new Room(roomID, XMLParser.instance.GetBackgroundFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetNorthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetSouthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetEastRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetWestRoomFromRoom(currentRoom),
                                items,
                                blocks,
                                npcs,
                                enemies);

            if (roomID == 0)
                room = null;

            return room;  

        }
        public static Room SouthRoom(int roomID, IPlayer player)
        {
              string currentRoom = "Room" + roomID;
                List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
                List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
                List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
                List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
                Room room = new Room(roomID, XMLParser.instance.GetBackgroundFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetNorthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetSouthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetEastRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetWestRoomFromRoom(currentRoom),
                                items,
                                blocks,
                                npcs,
                                enemies);
            if (roomID == 0)
                room = null;

            return room;
        }

        public static Room EastRoom(int roomID, IPlayer player)
        {
            string currentRoom = "Room" + roomID;
            List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
            List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
            List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
            List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
            Room room = new Room(roomID, XMLParser.instance.GetBackgroundFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetNorthRoomFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetSouthRoomFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetEastRoomFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetWestRoomFromRoom(currentRoom),
                            items,
                            blocks,
                            npcs,
                            enemies);

            if (roomID == 0)
                room = null;
            return room;
        }

        public static Room WestRoom(int roomID, IPlayer player)
        {
            string currentRoom = "Room" + roomID;
            List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
            List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
            List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
            List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
            Room room = new Room(roomID, XMLParser.instance.GetBackgroundFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetNorthRoomFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetSouthRoomFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetEastRoomFromRoom(currentRoom),
                            XMLAdjacentRoomParser.instance.GetWestRoomFromRoom(currentRoom),
                            items,
                            blocks,
                            npcs,
                            enemies);

            if (roomID == 0)
                room = null;

            return room;
        }
    }
}
