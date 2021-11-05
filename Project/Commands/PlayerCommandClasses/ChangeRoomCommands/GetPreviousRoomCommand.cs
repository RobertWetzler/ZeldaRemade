namespace Project
{
    class GetPreviousRoomCommand : ICommand
    {
        private Game1 game;

        public GetPreviousRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {


            if (this.game.RoomIdx <= 0)
                this.game.RoomIdx = this.game.RoomNum;
            this.game.RoomIdx--;
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
