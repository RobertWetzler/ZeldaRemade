using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites;
using Project.Sprites.BackgroundSprites;

namespace Project
{
    class TitleScreen
    {
        private IBackgroundSprite sprite;

        public TitleScreen()
        {
            sprite = BackgroundSpriteFactory.Instance.CreateTitleScreen();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            sprite.Draw(spriteBatch, graphics);
        }
    }
}
