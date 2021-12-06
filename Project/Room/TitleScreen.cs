using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.HUD;
using Project.Sprites.BackgroundSprites;

namespace Project
{
    class TitleScreen
    {
        private IBackgroundSprite sprite;
        private Rectangle bounds;
        private HardButton hardButton;
        private EasyButton easyButton;


        public TitleScreen(GraphicsDeviceManager graphics)
        {
            sprite = BackgroundSpriteFactory.Instance.CreateTitleScreen();
            bounds = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            hardButton = new HardButton();
            easyButton = new EasyButton();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, bounds);
            easyButton.Draw(spriteBatch);

        }
    }
}
