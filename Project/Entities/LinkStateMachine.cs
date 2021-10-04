using Project.Sprites.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class LinkStateMachine
    {
        public Facing facing;
        public Move move;
        private LinkColor color;

        private LinkSpriteSelector spriteSelector;
        private IPlayer link;

        public LinkStateMachine(IPlayer link, Facing facing, Move move, LinkColor color)
        {
            this.link = link;
            this.facing = facing;
            this.move = move;
            this.color = color;

            this.spriteSelector = new LinkSpriteSelector();
        }

        public IPlayerSprite MoveUp()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.facing = Facing.Up;
                this.move = Move.Moving;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            return sprite;
        }
        public IPlayerSprite MoveDown()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.facing = Facing.Down;
                this.move = Move.Moving;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            return sprite;

        }
        public IPlayerSprite MoveLeft()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.facing = Facing.Left;
                this.move = Move.Moving;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            return sprite;
        }
        public IPlayerSprite MoveRight()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if(!IsPerformingAction())
            {
                this.facing = Facing.Right;
                this.move = Move.Moving;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            return sprite;
            
        }
        public IPlayerSprite StopMoving()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.move = Move.Idle;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            return sprite;
        }

        public IPlayerSprite UseSword()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.move = Move.UsingSword;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            return sprite;
        }

        public IPlayerSprite UseItem()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.move = Move.UsingSword;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            return sprite;
        }
        private bool IsPerformingAction()
        {
            return (this.move == Move.UsingItem || this.move == Move.UsingSword) && !this.link.PlayerSprite.IsFinished;
        }
    }
}
