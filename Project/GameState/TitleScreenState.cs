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
            this.titleScreen = new TitleScreen(game.Graphics);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Enter, new PlayGameCommand(game));
        }
        public void Update(GameTime gameTime, Rectangle gameRect)
        {
            keyboardController.Update();
            titleScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            titleScreen.Draw(spriteBatch);
        }
    }
}
