using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project
{
    public interface INPC : ICollidable
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
    }
}
