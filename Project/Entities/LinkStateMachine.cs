using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class LinkStateMachine
    {
        public Facing facing;
        public Move move;
        private LinkColor color;

        private LinkSpriteSelector spriteSelector;

        public LinkStateMachine(Facing facing, Move move, LinkColor color)
        {
            this.facing = facing;
            this.move = move;
            this.color = color;

            this.spriteSelector = new LinkSpriteSelector();
        }

        public ISprite MoveUp()
        {
            this.facing = Facing.Up;
            this.move = Move.Moving;

            return this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
        }
        public ISprite MoveDown()
        {
            this.facing = Facing.Down;
            this.move = Move.Moving;

            return this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);

        }
        public ISprite MoveLeft()
        {
            this.facing = Facing.Left;
            this.move = Move.Moving;
            return this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);

        }
        public ISprite MoveRight()
        {
            this.facing = Facing.Right;
            this.move = Move.Moving;
            return this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
        }
        public ISprite StopMoving()
        {
            this.move = Move.Idle;
            return this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
        }

        public void UseSword()
        {

        }

    }
}
