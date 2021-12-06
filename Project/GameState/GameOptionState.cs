using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.HUD;
using Project.Sound;
using Project.Utilities;
using System.Diagnostics;

namespace Project.GameState
{
    public class GameOptionState : IGameState
    {
        private TitleScreen titleScreen;
        private KeyboardController keyboardController;
        private EasyButton easyButton;
        private HardButton hardButton;


        public GameOptionState(Game1 game)
        {
            SoundManager.Instance.CreateTitleSound();
            this.titleScreen = new TitleScreen(game.Graphics);
            keyboardController = new KeyboardController();
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
