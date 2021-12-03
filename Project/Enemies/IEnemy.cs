using Microsoft.Xna.Framework;
using Project.Collision;
using Project.Sound;
using Project.Utilities;

namespace Project
{
    /*
     * Represent an enemy. 
     * Enemy can move and take damage (extends IEntity),
     * has a sprite and position, and can use a weapon
     */
    public interface IEnemy : IEntity, ICollidable
    {
        public Vector2 Position { get; set; }
        public ISprite EnemySprite { get; set; }
        public float Velocity { get; }
        void ChangeDirection(EnemyDirections direction);
        void SetState(IEnemyState state);
        void UseWeapon();
        public void Despawn()
        {
            RoomManager.Instance.CurrentRoom.RemoveEnemy(this);
            SoundManager.Instance.CreateEnemyDeathSound();
        }

        public void DropItem(IItems item)
        {
            RoomManager.Instance.CurrentRoom.AddRandomItem(item);
        }

        public void RemoveHealth()
        {
            Health.DecreaseHealth(1);
        }
    }
}
