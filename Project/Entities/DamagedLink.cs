using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class DamagedLink : PlayerDecorator
    {
        private int effectTimer = 1000;
        private int knockbackTimer = 750;

        public DamagedLink(IPlayer decoratedPlayer, Game1 game)
        {
            // inherited from PlayerDecorator
            this.decoratedPlayer = decoratedPlayer;
            this.game = game;
        }
        public new void TakeDamage(int damage)
        {
            // No damage is taken
        }

        public new void Update(Rectangle windowBounds, GameTime gameTime)
        {
            effectTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            knockbackTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (knockbackTimer > 0)
            {
                    
            }
            if (effectTimer <= 0)
            {
                RemoveDecorator();
            }
        }

        public new void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.decoratedPlayer.Draw(spriteBatch, gameTime);
        }


    }
}
