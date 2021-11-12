using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;

namespace Project.GameState
{
    public class TitleScreenState : IGameState
    {
        private TitleScreen titleScreen;
        private KeyboardController keyboardController;
        public TitleScreenState(Game1 game)
        {
            this.titleScreen = new TitleScreen();
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Enter, new PlayGameCommand(game));
        }
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            keyboardController.Update();
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            titleScreen.Draw(spriteBatch, graphics);
        }
    }
}
