using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;

namespace Project.Rooms.Doors
{
    public interface IDoor : ICollidable
    {
        bool IsClosed { get; }
        DoorType DoorType { get; }
        void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Vector2.Zero);
        }
        void Draw(SpriteBatch spriteBatch, Vector2 offset);
        void DrawForeground(SpriteBatch spriteBatch);
        void Unlock();
        void OpenWithBomb(bool isAdjacent = false);
    }
}
