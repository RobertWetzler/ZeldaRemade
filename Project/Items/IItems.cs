using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project
{
    public interface IItems: ICollidable
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);

    }
}
