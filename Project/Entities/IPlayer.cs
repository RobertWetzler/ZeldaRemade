using Microsoft.Xna.Framework;
using Project.Collision;
using Project.Entities;
using Project.Sprites.PlayerSprites;

namespace Project
{
    public interface IPlayer : IEntity, ICollidable
    {
        public Vector2 Position { get; set; }
        public IPlayerSprite PlayerSprite { get; }
        public LinkStateMachine StateMachine { get; }
        public PlayerInventory Inventory { get; }
        // used for setting an intial sprite upon Game.LoadContent()
        void SetSprite(IPlayerSprite sprite);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void UseWeapon(WeaponTypes weaponType);
        void AddHealth(int value);
        void UpdateMaxHealth(int value);

    }
}
