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
    public enum LinkColor
    {
        Green,
        Red,
        Blue
    }
    class LinkStateMachine
    {
        private Facing facing;
        private Move move;
        private LinkColor color;

        private LinkSpriteSelector spriteSelector;

        public LinkStateMachine(Facing facing, Move move, LinkColor color)
        {
            this.facing = facing;
            this.move = move;
            this.color = color;

            this.spriteSelector = new LinkSpriteSelector();
        }

        public void MoveUp()
        {
            this.facing = Facing.Up;
            this.move = Move.Moving;

            this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
        }
        public void MoveDown()
        {
            this.facing = Facing.Down;
            this.move = Move.Moving;

            this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);

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

        public void UseSword()
        {

        }

    }
}
