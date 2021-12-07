using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;

namespace Project.Rooms.Doors
{
    class HiddenDoor : IDoor
    {
        public bool IsClosed => isClosed;
        public Rectangle boundingBox;
        public Rectangle BoundingBox => boundingBox;
        public CollisionType CollisionType => CollisionType.Door;
        public DoorType DoorType => doorType;

        private Vector2 position;
        private bool isClosed = false;
        private DoorType doorType;

        public HiddenDoor()
        {
            doorType = DoorType.HIDDEN;
            position = new Vector2(Game1.Instance.PlayerBounds.Width / 4, Game1.Instance.PlayerBounds.Y);
            int doorWidth = 65;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, doorWidth, doorWidth);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
        }

        public void DrawForeground(SpriteBatch spriteBatch)
        {
        }
        public void Unlock()
        {
        }
        public void OpenWithBomb(bool isAdjacent = false)
        {
            
        }
    }
}