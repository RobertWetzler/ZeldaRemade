using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class TrapMovement
    {

        private IPlayer player;
        private Trap trap;
        private Vector2 startPos;

        public TrapMovement(Trap trap, IPlayer player)
        {
            this.trap = trap;
            this.player = player;
            startPos = trap.Position;
        }



        public bool ShouldTrapMoveRight(Rectangle bounds, Vector2 playerPos)
        {
            int upperBound = bounds.Width / 2 + 100;
    
            if (bounds.Left < (int)playerPos.X && (int)playerPos.X < upperBound
                && ((Math.Abs((int)playerPos.Y - startPos.Y) < 5)))
            {
                return true;
            }
            return false;

        }

    }
}
