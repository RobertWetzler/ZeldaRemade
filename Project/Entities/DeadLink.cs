using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Utilities;
using System;
using System.Collections.Generic;
using Project.Sound;


namespace Project.Entities
{
    public class DeadLink : PlayerDecorator
    {
        private int timeToSpin;//test
        private int spinTimeCounter;
        private LinkStateMachine stateMachine;
        private bool isFinished = false;

        private double totalFlashTime = 1000;
        private double totalKnockbackTime = 500;
        private double remainingFlashTime;
        private double remainingKnockbackTime;
        private double knockbackVelocity = 300;
        private Color color;
        public DeadLink(IPlayer decoratedPlayer, Game1 game)
        {
            timeToSpin = 1000;
            spinTimeCounter = 0;
            // inherited from PlayerDecorator
            this.decoratedPlayer = decoratedPlayer;
            this.game = game;
            remainingFlashTime = totalFlashTime;
            remainingKnockbackTime = totalKnockbackTime;
            SoundManager.Instance.CreateLinkHurtSound();// need to change
        }
        public override void TakeDamage(int damage)
        {
            // No damage is taken
        }
        public override void Update(Rectangle windowBounds, GameTime gameTime)
        {
            spinTimeCounter += gameTime.ElapsedGameTime.Milliseconds;

            remainingFlashTime -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            remainingKnockbackTime -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Update color if timer is still running
            if (remainingFlashTime > 0)
            {
                UpdateColor();
            }
            // Update knockback position if timer is still runnning, else do normal update

                this.decoratedPlayer.Update(windowBounds, gameTime);
            
            // If both timers depleted, remove decorator
            if (Math.Max(remainingFlashTime, remainingKnockbackTime) <= 0)
            {
                RemoveDecorator();
                isFinished = true;
            }
        }
        private void UpdateColor()
        {
            List<float> hues = new List<float>() { 360f, 260f, 0f };
            double t = totalFlashTime - remainingFlashTime;
            int i = (int)(t / totalFlashTime * hues.Count * 10) % hues.Count; // cycle through list
            color = ColorUtils.HSVToRGB(hues[i], 1, 1);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.decoratedPlayer.Draw(spriteBatch, gameTime, color);
        }
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
        }
    }
}
