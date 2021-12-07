using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Sprites;
using Project.Utilities;
using System.Collections.Generic;

namespace Project.Rooms.Doors
{
    class WestDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => westDoorSprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Door;
        public DoorType DoorType => doorType;

        private DoorSprite westDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private DoorType doorType;
        public WestDoor(DoorType doorType)
        {
            position = new Vector2(0, 509);
            westDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateWestDoorSprite(doorType, position);
            this.doorType = doorType;
            switch (doorType)
            {
                case DoorType.OPEN:
                case DoorType.BOMB_OPEN:
                    isClosed = false;
                    break;
                case DoorType.CLOSED:
                case DoorType.KEY_CLOSED:
                case DoorType.BOMB_CLOSED:
                case DoorType.WALL:
                    isClosed = true;
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            westDoorSprite.Draw(spriteBatch, position, Color.White);
        }

        public void DrawForeground(SpriteBatch spriteBatch)
        {
            westDoorSprite.DrawForeground(spriteBatch, position, Color.White);
        }

        public void Unlock()
        {
            doorType = DoorType.OPEN;
            isClosed = false;
            westDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateWestDoorSprite(doorType, position);
        }
        public void OpenWithBomb(bool isAdjacent = false)
        {
            doorType = DoorType.BOMB_OPEN;
            isClosed = false;
            westDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateWestDoorSprite(doorType, position);
            // try opening door in adjacent room
            if (!isAdjacent)
            {
                try
                {
                    List<IDoor> doors = RoomManager.Instance.CurrentRoom.WestRoom.Doors;
                    IDoor adjDoor = doors.Find(x => x is EastDoor && x.DoorType == DoorType.BOMB_CLOSED);
                    adjDoor.OpenWithBomb(isAdjacent: true);
                }
                catch
                {
                    //ignore these errors, although they should never happen
                }
            }
        }
    }
}

