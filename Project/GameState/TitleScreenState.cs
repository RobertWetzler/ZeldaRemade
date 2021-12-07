using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.HUD;
using Project.Items;
using Project.Sound;

namespace Project.GameState
{
    public class TitleScreenState : IGameState
    {
        private TitleScreen titleScreen;
        private KeyboardController keyboardController;
        private EasyButton easyButton;
        private HardButton hardButton;


        public TitleScreenState(Game1 game)
        {
            SoundManager.Instance.CreateTitleSound();
            this.titleScreen = new TitleScreen(game.Graphics);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.S, new SelectHardModeCommand(game));
            keyboardController.RegisterCommand(Keys.W, new SelectEasyModeCommand(game));
            keyboardController.RegisterCommand(Keys.Down, new SelectHardModeCommand(game));
            keyboardController.RegisterCommand(Keys.Up, new SelectEasyModeCommand(game));
            keyboardController.RegisterCommand(Keys.Enter, new PlayGameCommand(game));
            

            easyButton = new EasyButton();
            hardButton = new HardButton();
        }
        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            keyboardController.Update();
            titleScreen.Update(gameTime);
            easyButton.Update(gameTime);
            hardButton.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            titleScreen.Draw(spriteBatch);
            easyButton.Draw(spriteBatch);
            hardButton.Draw(spriteBatch);
            spriteBatch.End();
        }


    }
}
