using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.HUD;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GameState
{
    class PausedState : IGameState
    {
        private Game1 game;
        private KeyboardController keyboardController;
        private IHUD smallHUD;
        public PausedState(Game1 game)
        {
            this.game = game;
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Escape, new PlayGameCommand(this.game));
            smallHUD = new SmallHUD(false);
        }
        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            keyboardController.Update();
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
            smallHUD.Draw(spriteBatch);
            game.Player.Draw(spriteBatch, gameTime);
            RoomManager.Instance.CurrentRoom.DrawForeground(spriteBatch, gameTime);
        }


    }
}
