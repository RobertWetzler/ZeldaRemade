using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Utilities;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GameState
{
    class PausedState : IGameState
    {
        private Game1 game;
        private KeyboardController keyboardController;
        public PausedState(Game1 game)
        {
            this.game = game;
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Escape, new PlayGameCommand(this.game));
            
        }
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            keyboardController.Update();
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime, graphics);
            game.Player.Draw(spriteBatch, gameTime);
        }

        
    }
}
