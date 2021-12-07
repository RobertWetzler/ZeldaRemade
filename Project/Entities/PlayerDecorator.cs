using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Sprites.PlayerSprites;

namespace Project.Entities
{
    // A generic PlayerDecorator class for Decorators to derive from
    public abstract class PlayerDecorator : IPlayer
    {
        protected IPlayer decoratedPlayer;
        protected Game1 game;
        public Vector2 Position { get => decoratedPlayer.Position; set => decoratedPlayer.Position = value; }
        public IPlayerSprite PlayerSprite => decoratedPlayer.PlayerSprite;
        public LinkStateMachine StateMachine => decoratedPlayer.StateMachine;
        public Rectangle BoundingBox => decoratedPlayer.BoundingBox;
        public CollisionType CollisionType => decoratedPlayer.CollisionType;

        public Health Health { get => decoratedPlayer.Health; }

        public PlayerInventory Inventory => decoratedPlayer.Inventory;
        public bool IsApproachBat { get => decoratedPlayer.IsApproachBat; set => decoratedPlayer.IsApproachBat = value; }

        public void RemoveDecorator()
        {
            game.Player = decoratedPlayer;
        }

        // mark methods as virtual so they can be overriden by derived classes
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            decoratedPlayer.Draw(spriteBatch, gameTime, color);
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            decoratedPlayer.Draw(spriteBatch, gameTime, Color.White);
        }

        public virtual void MoveDown()
        {
            decoratedPlayer.MoveDown();
        }

        public virtual void MoveLeft()
        {
            decoratedPlayer.MoveLeft();
        }

        public virtual void MoveRight()
        {
            decoratedPlayer.MoveRight();
        }

        public virtual void MoveUp()
        {
            decoratedPlayer.MoveUp();
        }

        public virtual void SetSprite(IPlayerSprite sprite)
        {
            decoratedPlayer.SetSprite(sprite);
        }

        public virtual void StopMoving()
        {
            decoratedPlayer.StopMoving();
        }

        public virtual void TakeDamage(int damage)
        {
            decoratedPlayer.TakeDamage(damage);
        }

        public virtual void Update(Rectangle windowBounds, GameTime gameTime)
        {
            decoratedPlayer.Update(windowBounds, gameTime);
        }

        public virtual void UseWeapon(WeaponTypes weaponType)
        {
            decoratedPlayer.UseWeapon(weaponType);
        }

        public virtual void ResetWeapon()
        {
            decoratedPlayer.ResetWeapon();
        }

        public void PickUpItem(IItems item)
        {
            decoratedPlayer.PickUpItem(item);
        }
    }
}
