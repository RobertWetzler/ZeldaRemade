using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sound;
using Project.Utilities;
using System;
using System.Collections.Generic;


namespace Project.Entities
{
    public class SpinningLink : PlayerDecorator
    {
        private double totalFlashTime = 1000;
        private double remainingFlashTime;
        private int timeToChangeDirection = 100; //time to randomly change direction
        private int changeDirectionCounter = 0;
        private Color color;
        private Facing facing;

        public SpinningLink(IPlayer decoratedPlayer, Game1 game)
        {
            // inherited from PlayerDecorator
            this.decoratedPlayer = decoratedPlayer;
            this.game = game;
            remainingFlashTime = totalFlashTime;
            facing = Facing.Down;
        }
        public override void TakeDamage(int damage)
        {
            // No damage is taken
        }

        public override void Update(Rectangle windowBounds, GameTime gameTime)
        {
            remainingFlashTime -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                // Update color if timer is still running
                if (remainingFlashTime > 0)
            {
                changeDirectionCounter += gameTime.ElapsedGameTime.Milliseconds;
                if (changeDirectionCounter > timeToChangeDirection)
                {
                    changeDirectionCounter -= timeToChangeDirection;
                    switch (facing)
                    {
                        case Facing.Down:
                            decoratedPlayer.SetSprite(Factory.LinkSpriteFactory.Instance.CreateLinkIdleSprite(facing, decoratedPlayer.Position));
                            facing = Facing.Left;
                            break;
                        case Facing.Left:
                            decoratedPlayer.SetSprite(Factory.LinkSpriteFactory.Instance.CreateLinkIdleSprite(facing, decoratedPlayer.Position));
                            facing = Facing.Up;
                            break;
                        case Facing.Up:
                            decoratedPlayer.SetSprite(Factory.LinkSpriteFactory.Instance.CreateLinkIdleSprite(facing, decoratedPlayer.Position));
                            facing = Facing.Right;
                            break;
                        case Facing.Right:
                            decoratedPlayer.SetSprite(Factory.LinkSpriteFactory.Instance.CreateLinkIdleSprite(facing, decoratedPlayer.Position));
                            facing = Facing.Down;
                            break;
                    }
                }
                
                //UpdateColor();
            }
            else
            {
                this.decoratedPlayer.Update(windowBounds, gameTime);
            }
            // If both timers depleted, remove decorator
            if (remainingFlashTime <= 0)
            {
                RemoveDecorator();
            }
        }
        /*
        private void UpdateColor()
        {
            List<float> hues = new List<float>() { 140f, 180f, 260f, 340f };
            double t = totalFlashTime - remainingFlashTime;
            int i = (int)(t / totalFlashTime * hues.Count * 10) % hues.Count; // cycle through list
            color = ColorUtils.HSVToRGB(hues[i], 1, 1);
        }
        private void UpdateKnockback(GameTime gameTime, Rectangle windowBounds)
        {
            int x_dir = 0, y_dir = 0;
            switch (this.decoratedPlayer.StateMachine.facing)
            {
                case Facing.Left:
                    x_dir = 1;
                    break;
                case Facing.Right:
                    x_dir = -1;
                    break;
                case Facing.Up:
                    y_dir = 1;
                    break;
                case Facing.Down:
                    y_dir = -1;
                    break;
            }
            float newX = this.decoratedPlayer.Position.X + (float)(x_dir * gameTime.ElapsedGameTime.TotalSeconds * knockbackVelocity);
            float newY = this.decoratedPlayer.Position.Y + (float)(y_dir * gameTime.ElapsedGameTime.TotalSeconds * knockbackVelocity);
            if (x_dir == 1)
            {
                newX = (int)(newX + decoratedPlayer.BoundingBox.Width) < windowBounds.Right ? newX : windowBounds.Right - (decoratedPlayer.BoundingBox.Width);
            }
            else if (x_dir == -1)
            {
                newX = (int)newX > windowBounds.Left ? newX : windowBounds.Left;
            }
            else if (y_dir == 1)
            {
                newY = (int)(newY + decoratedPlayer.BoundingBox.Height) < windowBounds.Bottom ? newY : windowBounds.Bottom - (decoratedPlayer.BoundingBox.Height);
            }
            else
            {
                newY = (int)(newY) > windowBounds.Top ? newY : windowBounds.Top;
            }
            this.decoratedPlayer.Position = new Vector2(newX, newY);

        }*/
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.decoratedPlayer.Draw(spriteBatch, gameTime, color);
        }
        /*
      
        // If move during knockback, stop knockback (similar to real game)
        public override void MoveUp()
        {
            remainingKnockbackTime = 0;
            base.MoveUp();
        }
        public override void MoveDown()
        {
            remainingKnockbackTime = 0;
            base.MoveDown();
        }
        public override void MoveLeft()
        {
            remainingKnockbackTime = 0;
            base.MoveLeft();
        }
        public override void MoveRight()
        {
            remainingKnockbackTime = 0;
            base.MoveRight();
        }
        // only allow weapon after knockback (change later if not desired behavior)
        public override void UseWeapon(WeaponTypes weaponType)
        {
            if (remainingKnockbackTime <= 0)
            {
                base.UseWeapon(weaponType);
            }
        }*/
    }
}
