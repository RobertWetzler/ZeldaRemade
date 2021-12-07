using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Sound;
using Project.Sprites;
using Project.Utilities;
using System.Collections.Generic;

namespace Project.Rooms.Doors
{
    class NorthDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => northDoorSprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Door;

        public DoorType DoorType => doorType;
        private DoorSprite northDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private DoorType doorType;

        public NorthDoor(DoorType doorType)
        {
            position = new Vector2(448, 223);
            northDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateNorthDoorSprite(doorType, position);
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
        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            northDoorSprite.Draw(spriteBatch, position + offset, Color.White);
        }

        public void DrawForeground(SpriteBatch spriteBatch)
        {
            northDoorSprite.DrawForeground(spriteBatch, position, Color.White);
        }

        public void Unlock()
        {
            doorType = DoorType.OPEN;
            isClosed = false;
            northDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateNorthDoorSprite(doorType, position);
            SoundManager.Instance.CreateDoorUnlockSound();
        }
        public void OpenWithBomb(bool isAdjacent = false)
        {
            doorType = DoorType.BOMB_OPEN;
            isClosed = false;
            northDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateNorthDoorSprite(doorType, position);
            // try opening door in adjacent room
            if (!isAdjacent)
            {
                try
                {
                    List<IDoor> doors = RoomManager.Instance.CurrentRoom.NorthRoom.Doors;
                    IDoor adjDoor = doors.Find(x => x is SouthDoor && x.DoorType == DoorType.BOMB_CLOSED);
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
