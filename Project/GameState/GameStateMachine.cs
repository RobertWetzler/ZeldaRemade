using Project.Rooms;

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
        public void RoomTransition(Room nextRoom, Direction dir = Direction.Down)
        {
            if (this.currentState is PlayingState)
            {
                this.currentState = new RoomTransitionState(nextRoom, dir);
            }
        }

        public void ItemSelectionScreen()
        {
            if (this.currentState is PlayingState)
            {
                this.currentState = new ItemSelectionState(game);
            }
        }
        public void WinScreen()
        {
            this.currentState = new WinScreenState();
        }

        public void GameOverScreen()
        {
            this.currentState = new GameOverScreenState();
        }

        public void PickUpItemScreen(IItems item)
        {
            this.currentState = new PickUpItemState(item);
        }
    }
}
