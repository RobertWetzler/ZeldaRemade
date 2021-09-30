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
                    break;
            }
        }

        private void ChooseUpFacingSprite(Move move, LinkColor color)
        {

        }
    }
}
