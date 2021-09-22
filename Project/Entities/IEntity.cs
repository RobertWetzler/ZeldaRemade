using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    interface IEntity
    {
        public void TakeDamage(int damage);

        //TODO: add parameter: Item item
        public void UseItem();
    }
}
