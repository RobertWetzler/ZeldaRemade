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
    class EastDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => eastDoorSprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Door;
        public DoorType DoorType => doorType;

        private DoorSprite eastDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private DoorType doorType;

        public EastDoor(DoorType doorType)
        {
            position = new Vector2(896, 509);
            eastDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateEastDoorSprite(doorType, position);
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
            eastDoorSprite.Draw(spriteBatch, position + offset, Color.White);
        }

        public void DrawForeground(SpriteBatch spriteBatch)
        {
            eastDoorSprite.DrawForeground(spriteBatch, position, Color.White);
        }
        public void Unlock()
        {
            doorType = DoorType.OPEN;
            isClosed = false;
            eastDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateEastDoorSprite(doorType, position);
            SoundManager.Instance.CreateDoorUnlockSound();
        }
        public void OpenWithBomb(bool isAdjacent = false)
        {
            doorType = DoorType.BOMB_OPEN;
            isClosed = false;
            eastDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateEastDoorSprite(doorType, position);
            // try opening door in adjacent room
            if (!isAdjacent)
            {
                try
                {
                    List<IDoor> doors = RoomManager.Instance.CurrentRoom.EastRoom.Doors;
                    IDoor adjDoor = doors.Find(x => x is WestDoor && x.DoorType == DoorType.BOMB_CLOSED);
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

