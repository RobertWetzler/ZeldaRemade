using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project.GameState
{
    public class GameStateMachine
    {
        public IGameState currentState;
        private Game1 game;
        public IGameState CurrentState { get => currentState; }

        public GameStateMachine(Game1 game)
        {
            this.currentState = new TitleScreenState(game);
            this.game = game;
        }
        public void Play()
        {
            this.currentState = new PlayingState(game);
        }
        public void Pause()
        {
            if (this.currentState is PlayingState)
            {
                this.currentState = new PausedState(game);
            }
        }
        public void TitleScreen()
        {
            this.currentState = new TitleScreenState(game);
        }
    }
}
