using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.ItemSprites
{
    public interface IWeaponSprites
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        bool isFinished();


    }
}
