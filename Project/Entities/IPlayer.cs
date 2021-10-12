using Microsoft.Xna.Framework;
using Project.Entities;
using Project.Sprites.PlayerSprites;

namespace Project
{
    public interface IPlayer : IEntity
    {
        public Vector2 Position { get; set; }
        public IPlayerSprite PlayerSprite { get; }
        public LinkStateMachine StateMachine { get; }
        // used for setting an intial sprite upon Game.LoadContent()
        void SetSprite(IPlayerSprite sprite);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void UseSword(WeaponTypes weaponType);
        void UseWeapon(WeaponTypes weaponType);

    }
}
