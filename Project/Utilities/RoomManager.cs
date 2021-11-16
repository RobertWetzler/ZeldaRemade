using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project.Utilities
{
    class RoomManager
    {
        public static Dictionary<int, Room> IdToRoom = new Dictionary<int, Room>();
        private static RoomManager instance = new RoomManager();
        public static RoomManager Instance => instance;
        private Room currentRoom;
        public Room CurrentRoom => currentRoom;
        public void SetCurrentRoom(Room room)
        {
            currentRoom = room;
        }

        public static void LoadAllRooms(IPlayer player, GraphicsDeviceManager graphics)
        {
            IdToRoom = new Dictionary<int, Room>();
            for (int i = 1; i <= 18; i++)
            {
                string currentRoom = "Room" + i;
                List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
                List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
                List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
                List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
                List<IDoor> doors = XMLDoorParser.Instance.GetDoorsFromRoom(currentRoom);
                Room room = new Room(i, XMLParser.instance.GetBackgroundFromRoom(currentRoom, graphics),
                                XMLAdjacentRoomParser.instance.GetNorthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetSouthRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetEastRoomFromRoom(currentRoom),
                                XMLAdjacentRoomParser.instance.GetWestRoomFromRoom(currentRoom),
                                items,
                                blocks,
                                npcs,
                                enemies,
                                doors);

                IdToRoom.Add(i, room);
            }
        }

        public static Room GetRoom(int roomID)
        {
            Room room = null;
            if(IdToRoom.ContainsKey(roomID))
            {
                room = IdToRoom[roomID];
            }
            return room;
        }
 
    }
}
