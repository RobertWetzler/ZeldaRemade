using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;

namespace Project.Rooms.Doors
{
    public interface IDoor : ICollidable
    {
        bool IsClosed { get; }
        DoorType DoorType { get; }
        void Draw(SpriteBatch spriteBatch);
        void DrawForeground(SpriteBatch spriteBatch);
        void Unlock();
        void OpenWithBomb(bool isAdjacent = false);
    }
}
