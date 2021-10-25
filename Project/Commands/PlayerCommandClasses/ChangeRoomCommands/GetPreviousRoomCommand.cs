using System;
using System.Collections.Generic;
using System.Text;

namespace Project { 
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
        }
    }
}
