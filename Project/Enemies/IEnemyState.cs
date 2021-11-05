using Microsoft.Xna.Framework;

namespace Project
{
    /*
     * Represent an enemy state. 
     * States are moving in some direction,
     * using an item, spawning, and dead
     */
    public interface IEnemyState
    {

        void ChangeDirection(EnemyDirections direction);
        void UseWeapon();
        void Update(GameTime gameTime);
    }
}
