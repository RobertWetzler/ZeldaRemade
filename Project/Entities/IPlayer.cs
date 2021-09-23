using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    interface IPlayer: IEntity
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void UseSword();
        void UseItem();

    }
}
