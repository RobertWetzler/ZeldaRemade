using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites;
using Project.Sprites.BackgroundSprites;

namespace Project
{
    class ItemSelectionScreen
    {
        private IBackgroundSprite sprite;
        private Rectangle bounds;

        public ItemSelectionScreen(GraphicsDeviceManager graphics)
        {
            const int heightOffset = 223;
            sprite = BackgroundSpriteFactory.Instance.CreateItemSelectionScreen();
            bounds = new Rectangle(0, heightOffset, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight-heightOffset);
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
