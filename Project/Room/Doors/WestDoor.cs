using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Sprites;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class WestDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle BoundingBox => westDoorSprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Door;
        public DoorType DoorType => doorType;

        public bool CanBeBombed { get => canBeBombed; set => canBeBombed = value; }
        private DoorSprite westDoorSprite;
        private Vector2 position;
        private bool isClosed;
        private bool canBeBombed;
        private DoorType doorType;
        public WestDoor(DoorType doorType)
        {
            westDoorSprite = (DoorSprite)DoorSpriteFactory.Instance.CreateWestDoorSprite(doorType, new Vector2(0, 509));
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
            westDoorSprite.Draw(spriteBatch, position, Color.White);
        }

        public void DrawForeground(SpriteBatch spriteBatch)
        {
            westDoorSprite.DrawForeground(spriteBatch, position, Color.White);
        }
    }
}

