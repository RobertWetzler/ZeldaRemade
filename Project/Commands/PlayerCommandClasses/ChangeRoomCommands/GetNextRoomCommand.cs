namespace Project
{
    class GetNextRoomCommand : ICommand
    {
        private Game1 game;

        public GetNextRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.RoomIdx++;
            if (this.game.RoomIdx >= this.game.RoomNum)
                this.game.RoomIdx = 1;
            if (this.game.RoomIdx == this.game.RoomNum - 1)
            {
                game.Player.Position = new Microsoft.Xna.Framework.Vector2(500, 400);
            }
            else
            {
                game.Player.Position = new Microsoft.Xna.Framework.Vector2(500, 500);
            }
        }
    }
}
