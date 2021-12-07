using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Utilities;
using System.Collections.Generic;


namespace Project.Entities
{
    public class DeadLink : PlayerDecorator
    {
        private double totalFlashTime = 1000;
        private double remainingFlashTime;
        private Color color = Color.White;
        public DeadLink(IPlayer decoratedPlayer, Game1 game)
        {
            this.decoratedPlayer = decoratedPlayer;
            this.game = game;
            remainingFlashTime = totalFlashTime;
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
                UpdateColor();
            }
            this.decoratedPlayer.Update(windowBounds, gameTime);

            // remove decorator
            if (remainingFlashTime <= 0)
            {
                RemoveDecorator();
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
    }
}
