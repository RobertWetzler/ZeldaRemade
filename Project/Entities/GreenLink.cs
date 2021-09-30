using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Project
{
    class GreenLink: IPlayer
    {
        private LinkStateMachine stateMachine;
        private Vector2 position;
        public GreenLink()
        {
           // stateMachine = new LinkStateMachine(Facing.Right, Move.Idle, LinkColor.Green);
        }
        public void MoveUp()
        {
            stateMachine.MoveUp();
        }
        public void MoveDown()
        {
            stateMachine.MoveDown();
        }
        public void MoveLeft()
        {
            stateMachine.MoveLeft();
        }
        public void MoveRight()
        {
            stateMachine.MoveRight();
        }
        public void UseSword()
        {
            throw new NotImplementedException();
        }
        public void UseItem()
        {
            throw new NotImplementedException();
        }
        public void BecomeDamaged() 
        { 
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public void Move(MoveDir dir)
        {
            throw new NotImplementedException();
        }
    }
}
