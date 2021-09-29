using Project.Factory;
using Project.Sprites.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class LinkSpriteSelector
    {
        public LinkSpriteSelector()
        {
        }
        public IPlayerSprite UpdateSprite(Facing facing, Move move, LinkColor color)
        {
            IPlayerSprite sprite;
            switch (move)
            {
                case Move.Moving:
                    sprite = LinkSpriteFactory.Instance.CreateLinkWalkingSprite(facing);
                    break;
               // Default: Idle sprite
                default:
                    sprite = LinkSpriteFactory.Instance.CreateLinkIdleSprite(facing);
                    break;
            }
            return sprite;
        }
    }
}
