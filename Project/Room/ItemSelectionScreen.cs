using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites;

namespace Project
{
    class ItemSelectionScreen
    {
        private IBackgroundSprite sprite;

        public ItemSelectionScreen()
        {
            sprite = BackgroundSpriteFactory.Instance.CreateItemSelectionScreen();
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
