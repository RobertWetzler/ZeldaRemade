using Project.Utilities;

namespace Project.Commands
{
    class StartGameCommand : ICommand
    {
        public void Execute()
        {
            RoomManager.LoadAllRooms(Game1.Instance.Player, Game1.Instance.Graphics);
            RoomManager.Instance.SetCurrentRoom(RoomManager.IdToRoom[11]);
            Game1.Instance.GameStateMachine.Play();
        }
    }
}
