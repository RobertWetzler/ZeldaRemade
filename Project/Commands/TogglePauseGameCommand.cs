namespace Project.Commands
{
    class TogglePauseGameCommand : ICommand
    {
        public void Execute()
        {
            Game1.Instance.GameStateMachine.TogglePause();
        }
    }
}
