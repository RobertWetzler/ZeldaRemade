using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project.Utilities
{
    class RoomManager
    {
        private static RoomManager instance = new RoomManager();
        public static RoomManager Instance => instance;
        private Room currentRoom;
        public Room CurrentRoom => currentRoom;
        public void SetCurrentRoom(Room room)
        {
            currentRoom = room;
        }

        public static void GetRoom(IPlayer player, GraphicsDeviceManager graphics)
        {
            
            for (int i = 1; i <= 18; i++)
            {
                string currentRoom = "Room" + i;
                List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
                List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
                List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
                List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
                Room room = new Room(i, XMLParser.instance.GetBackgroundFromRoom(currentRoom, graphics),
                                XMLAdjacentRoomParser.instance.GetNorthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetSouthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetEastRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetWestRoomFromRoom(currentRoom),
                                items,
                                blocks,
                                npcs,
                                enemies);

                RoomUtilities.IdToRoom.Add(i - 1, room);
            }

        }
 
    }
}
