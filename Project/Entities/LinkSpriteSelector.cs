using Microsoft.Xna.Framework;
using Project.Factory;
using Project.Sprites.PlayerSprites;

namespace Project.Entities
{
    public class LinkSpriteSelector
    {
        public LinkSpriteSelector()
        {
        }
        public IPlayerSprite UpdateSprite(Facing facing, Move move, LinkColor color, Vector2 position)
        {
            IPlayerSprite sprite;
            switch (move)
            {
                case Move.Moving:
                    sprite = LinkSpriteFactory.Instance.CreateLinkWalkingSprite(facing);
                    break;
                case Move.UsingSword:
                    sprite = LinkSpriteFactory.Instance.CreateLinkUseSwordSprite(facing);
                    break;
                case Move.UsingItem:
                    sprite = LinkSpriteFactory.Instance.CreateLinkUseItemSprite(facing);
                    break;
                default:
                    sprite = LinkSpriteFactory.Instance.CreateLinkIdleSprite(facing, position);
                    break;
            }
            return sprite;
        }
    }
}
