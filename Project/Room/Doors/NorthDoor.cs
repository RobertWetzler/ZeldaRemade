using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Sprites;
using Project.Utilities;

namespace Project
{
    class NorthDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => northDoorSprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Door;

        public DoorType DoorType => doorType;

        public bool CanBeBombed { get => canBeBombed; set => canBeBombed = value; }

        private DoorSprite northDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private bool canBeBombed;
        private DoorType doorType;

        public NorthDoor(DoorType doorType, Vector2 doorPos)
        {
            position = doorPos;
            northDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateNorthDoorSprite(doorType, position);
            canBeBombed = false;
            this.doorType = doorType;

            switch (doorType)
            {
                case DoorType.OPEN:
                    isClosed = false;
                    break;
                case DoorType.CLOSED:
                    isClosed = true;
                    break;
                case DoorType.KEY_CLOSED:
                    isClosed = true;
                    break;
                case DoorType.BOMB_OPEN:
                    isClosed = true;
                    break;
                case DoorType.WALL:
                    isClosed = true;
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            northDoorSprite.Draw(spriteBatch, position, Color.White);
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
        }
    }
}
