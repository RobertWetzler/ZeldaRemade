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
        private int timeToChangeDirection = 100; 
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
            }
            else
            {
                this.decoratedPlayer.Update(windowBounds, gameTime);
            }
            if (remainingFlashTime <= 0)
            {
                RemoveDecorator();
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.decoratedPlayer.Draw(spriteBatch, gameTime, color);
        }
    }
}
