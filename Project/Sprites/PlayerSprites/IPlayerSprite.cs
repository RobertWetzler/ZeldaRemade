using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.PlayerSprites
{
    public interface IPlayerSprite : ISprite
    {
        bool IsFinished
        {
            get;
        }
    }
}