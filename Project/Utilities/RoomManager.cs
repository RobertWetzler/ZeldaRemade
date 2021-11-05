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
    }
}
