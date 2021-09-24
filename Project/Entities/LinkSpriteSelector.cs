using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class LinkSpriteSelector
    {
        private LinkSpriteFactory spriteFactory;
        public LinkSpriteSelector()
        {
        }
        public void UpdateSprite(Facing facing, Move move, LinkColor color)
        {
            switch (facing)
            {
                case Facing.Up:
                    ChooseUpFacingSprite(move, color);
                    break;
                case Facing.Down:
                    ChooseDownFacingSprite(move, color);
                    break;
                case Facing.Left:
                    ChooseLeftFacingSprite(move, color);
                    break;
                case Facing.Right:
                    ChooseRightFacingSprite(move, color);
                    break;
            }
        }

        private void ChooseRightFacingSprite(Move move, LinkColor color)
        {
            throw new NotImplementedException();
        }

        private void ChooseLeftFacingSprite(Move move, LinkColor color)
        {
            throw new NotImplementedException();
        }

        private void ChooseDownFacingSprite(Move move, LinkColor color)
        {
            throw new NotImplementedException();
        }

        private void ChooseUpFacingSprite(Move move, LinkColor color)
        {
            switch (move)
            {
                case Move.Idle:
                    //ChooseUpFacingIdleSprite(color);
                    break;
                case Move.Moving:
                    //ChooseUpFacingMovingSprite(color);
                    break;
            }
        }
    }
}
