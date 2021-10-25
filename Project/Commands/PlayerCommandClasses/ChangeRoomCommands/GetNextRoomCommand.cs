using System;
using System.Collections.Generic;
using System.Text;

namespace Project { 
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
                this.game.RoomIdx = 0;
         
        }
    }
}
