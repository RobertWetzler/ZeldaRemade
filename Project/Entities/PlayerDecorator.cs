using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    // A generic PlayerDecorator class for Decorators to derive from
    public abstract class PlayerDecorator : IPlayer
    {
        protected IPlayer decoratedPlayer;
        protected Game1 game;
        public Vector2 Position { get => decoratedPlayer.Position; set => decoratedPlayer.Position = value; }

        public void RemoveDecorator()
        {
            game.Player = decoratedPlayer;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color = default)
        {
            decoratedPlayer.Draw(spriteBatch, gameTime);
        }

        public void MoveDown()
        {
            decoratedPlayer.MoveDown();
        }

        public void MoveLeft()
        {
            decoratedPlayer.MoveLeft();
        }

        public void MoveRight()
        {
            decoratedPlayer.MoveRight();
        }

        public void MoveUp()
        {
            decoratedPlayer.MoveUp();
        }

        public void SetSprite(IPlayerSprite sprite)
        {
            decoratedPlayer.SetSprite(sprite);
        }

        public void StopMoving()
        {
            decoratedPlayer.StopMoving();
        }

        public void TakeDamage(int damage)
        {
            decoratedPlayer.TakeDamage(damage);
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            decoratedPlayer.Update(windowBounds, gameTime);
        }

        public void UseItem()
        {
            decoratedPlayer.UseItem();
        }

        public void UseSword()
        {
            decoratedPlayer.UseSword();
        }
    }
}
