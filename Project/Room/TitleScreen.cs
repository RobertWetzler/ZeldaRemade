using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites;

namespace Project
{
    class TitleScreen
    {
        private IBackgroundSprite sprite;
        private Rectangle bounds;

        public TitleScreen(GraphicsDeviceManager graphics)
        {
            sprite = BackgroundSpriteFactory.Instance.CreateTitleScreen();
            bounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, bounds);
        }
    }
}
