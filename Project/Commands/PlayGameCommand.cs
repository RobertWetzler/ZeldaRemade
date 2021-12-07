using Project.Utilities;

namespace Project.Commands
{
    class PlayGameCommand : ICommand
    {
        public void Execute()
        {
            Game1.Instance.GameStateMachine.Play();
        }
    }
}
