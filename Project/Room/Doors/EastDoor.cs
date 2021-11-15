using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class EastDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => eastDoorSprite.DestRectangle;
        public CollisionType CollisionType => throw new NotImplementedException();
        public DoorType DoorType => doorType;

        public bool CanBeBombed { get => canBeBombed; set => canBeBombed = value; }
        private ISprite eastDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private bool canBeBombed;
        private DoorType doorType;

        public EastDoor(DoorType doorType)
        {
            eastDoorSprite = DoorSpriteFactory.Instance.CreateEastDoorSprite(doorType);
            position = new Vector2(896, 509);
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
            eastDoorSprite.Draw(spriteBatch, position);
        }
    }
}

