using Project.Rooms.Doors;
using System.Collections.Generic;

namespace Project.Utilities
{
    public static class DoorUtilities
    {
        public static void UnlockClosedDoors()
        {
            List<IDoor> doors = RoomManager.Instance.CurrentRoom.Doors;
            List<IDoor> closedDoors = doors.FindAll(x => x.DoorType == DoorType.CLOSED);
            foreach (IDoor closedDoor in closedDoors)
            {
                closedDoor.Unlock();
            }
        }
    }
}
