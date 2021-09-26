using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public enum Facing
    {
        Up,
        Down,
        Left,
        Right
    }
    public enum Move
    {
        Moving,
        Idle
    }
    class NPCStateMachine
    {
        private Facing facing;
        private Move move;

        public NPCStateMachine(Facing facing, Move move)
        {
            this.facing = facing;
            this.move = move;
            
        }
        public void MoveUp()
        {
            this.facing = Facing.Up;
            this.move = Move.Moving;
        }
        public void MoveDown()
        {
            this.facing = Facing.Down;
            this.move = Move.Moving;
        }
        public void MoveLeft()
        {
            this.facing = Facing.Left;
            this.move = Move.Moving;
        }
        public void MoveRight()
        {
            this.facing = Facing.Right;
            this.move = Move.Moving;
        }
        public void StopMoving()
        {
            this.move = Move.Idle;
        }
    }

}
