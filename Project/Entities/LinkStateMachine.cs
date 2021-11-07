using Project.Projectiles;
using Project.Sprites.ItemSprites;
using Project.Sprites.PlayerSprites;

namespace Project.Entities
{
    public class LinkStateMachine
    {
        public Facing facing;
        public Move move;
        private LinkColor color;

        private IPlayerSprite oldSprite;
        public Move oldMove;

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
            if (!IsPerformingAction())
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

        public (IPlayerSprite, IProjectileSprite) UseSword(IProjectileSprite projectileSprite)
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.oldSprite = sprite;
                this.oldMove = move;
                this.move = Move.UsingSword;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            else
            {
                projectileSprite = null; //If weapon can't be used right now, set it to null
            }
            return (sprite, projectileSprite);
        }

        public (IPlayerSprite, IProjectile) UseWeapon(IProjectile weapon)
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (!IsPerformingAction())
            {
                this.oldSprite = sprite;
                this.oldMove = move;
                this.move = Move.UsingItem;
                sprite = this.spriteSelector.UpdateSprite(this.facing, this.move, this.color);
            }
            else
            {
                weapon = null; //If weapon can't be used right now, set it to null
            }
            return (sprite, weapon);
        }
        private bool IsInActionState()
        {
            return this.move == Move.UsingItem || this.move == Move.UsingSword;
        }
        private bool IsPerformingAction()
        {
            return IsInActionState() && !this.link.PlayerSprite.IsFinished;
        }

        public IPlayerSprite Update()
        {
            IPlayerSprite sprite = this.link.PlayerSprite;
            if (IsInActionState() && this.link.PlayerSprite.IsFinished) //If in an action state but action is done, go idle
            {
                move = oldMove;
                sprite = oldSprite;
            }
            return sprite;
        }
    }
}
