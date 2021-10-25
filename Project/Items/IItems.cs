using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;

namespace Project
{
    public interface IItems: ICollidable
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        public void Despawn()
        {
            RoomManager.Instance.CurrentRoom.RemoveItem(this);
        }

    }
}
