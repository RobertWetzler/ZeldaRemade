using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Sprites;
using Project.Utilities;

namespace Project
{
    class Torch : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => eastDoorSprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Door;
        public DoorType DoorType => doorType;

        public bool CanBeBombed { get => canBeBombed; set => canBeBombed = value; }
        private DoorSprite eastDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private bool canBeBombed;
        private DoorType doorType;

        public Torch(DoorType doorType)
        {
            position = new Vector2(896, 509);
            eastDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateEastDoorSprite(doorType, position);
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
                    isClosed = false;
                    break;
                case DoorType.WALL:
                    isClosed = true;
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            eastDoorSprite.Draw(spriteBatch, position, Color.White);
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
        }
    }
}

