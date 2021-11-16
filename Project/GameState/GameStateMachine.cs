using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
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

        public void TogglePause()
        {
            if (this.currentState is PlayingState)
            {
                this.currentState = new PausedState(game);
            }
            else if (this.currentState is PausedState)
            {
                this.currentState = new PlayingState(game);
            }
        }

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
        public void RoomTransition(Direction dir)
        {
            if (this.currentState is PlayingState)
            {
                this.currentState = new RoomTransitionState(game, dir);
            }
        }

        public void ItemSelectionScreen()
        {
            if (this.currentState is PlayingState)
            {
                this.currentState = new ItemSelectionState(game);
            }
        }
    }
}
