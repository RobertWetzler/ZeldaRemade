using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;

namespace Project
{
    public interface IDoor : ICollidable
    {
        bool IsClosed { get; }
        bool CanBeBombed { get; set; }
        DoorType DoorType { get; }
        void Draw(SpriteBatch spriteBatch);
        void DrawForeground(SpriteBatch spriteBatch);
        void Unlock();
    }
}
