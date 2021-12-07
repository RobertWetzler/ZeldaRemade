using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Sound;
using Project.Utilities;

namespace Project.GameState
{
    public class TitleScreenState : IGameState
    {
        private TitleScreen titleScreen;
        private KeyboardController keyboardController;

        public TitleScreenState(Game1 game)
        {
            SoundManager.Instance.CreateTitleSound();
            this.titleScreen = new TitleScreen(game.Graphics);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Enter, new PlayGameCommand(game));
        }
        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            keyboardController.Update();
            titleScreen.Update(gameTime);


        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            titleScreen.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
