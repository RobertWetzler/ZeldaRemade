using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GameState
{
    class GameStateMachine
    {
        public IGameState currentState;
        private Game1 game;
        public GameStateMachine(Game1 game)
        {
            this.currentState = new PlayingState(game);
            this.game = game;
        }
        public void Play()
        {
            this.currentState = new PlayingState(game);
        }
        public void Pause()
        {
            throw new NotImplementedException();
            //this.currentState = new PausedState(game);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            currentState.Draw(spriteBatch, gameTime, graphics);
        }
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            currentState.Update(gameTime, graphics);
        }
    }
}
