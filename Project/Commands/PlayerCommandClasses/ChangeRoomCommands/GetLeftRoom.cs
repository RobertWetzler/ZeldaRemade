using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class GetLeftRoom : ICommand
    {
        private Room room;

        public GetLeftRoom(Room room)
        {
            this.room = room;

        }
        public void Execute()
        {

        }
}
