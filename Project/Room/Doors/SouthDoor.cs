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
    class SouthDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => southDoorSprite.DestRectangle;
        public CollisionType CollisionType => throw new NotImplementedException();
        public DoorType DoorType => doorType;

        public bool CanBeBombed { get => canBeBombed; set => canBeBombed = value; }
        private ISprite southDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private bool canBeBombed;
        private DoorType doorType;
        public SouthDoor(DoorType doorType)
        {
            southDoorSprite = DoorSpriteFactory.Instance.CreateSouthDoorSprite(doorType);
            position = new Vector2(448, 797);
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
            southDoorSprite.Draw(spriteBatch, position);
        }
    }
}
