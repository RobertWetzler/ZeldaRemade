using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public enum MoveDir
    {
        Up,
        Down,
        Left,
        Right
    }
    interface IPlayer: IEntity
    {
        void Move(MoveDir dir);
    }
}
