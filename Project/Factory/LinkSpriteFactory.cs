using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Sprites.PlayerSprites;
using System;

namespace Project.Factory
{
    public class LinkSpriteFactory
    {
        private Texture2D linkWalkingSpriteSheet;
        private Texture2D linkPickupItemSpriteSheet;
        private Texture2D linkUseItemSpriteSheet;
        private Texture2D linkUseSwordDownwardsSpriteSheet;
        private Texture2D linkUseSwordSidewaysSpriteSheet;
        private Texture2D linkUseSwordUpwardsSpriteSheet;

        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkWalkingSpriteSheet = content.Load<Texture2D>("PlayerSprites/link-walking");
            linkPickupItemSpriteSheet = content.Load<Texture2D>("PlayerSprites/link-pickup-item");
            linkUseItemSpriteSheet = content.Load<Texture2D>("PlayerSprites/link-use-item");
            linkUseSwordDownwardsSpriteSheet = content.Load<Texture2D>("PlayerSprites/link-use-sword-downwards");
            linkUseSwordSidewaysSpriteSheet = content.Load<Texture2D>("PlayerSprites/link-use-sword-sideways");
            linkUseSwordUpwardsSpriteSheet = content.Load<Texture2D>("PlayerSprites/link-use-sword-upwards");
        }

        public IPlayerSprite CreateLinkIdleSprite(Facing facing)
        {
            return new LinkIdleSprite(linkWalkingSpriteSheet, facing);
        }

        public IPlayerSprite CreateLinkWalkingSprite(Facing facing)
        {
            return new LinkWalkingSprite(linkWalkingSpriteSheet, facing);
        }
        public IPlayerSprite CreateLinkPickupItemSprite()
        {
            return new LinkPickupItemSprite(linkPickupItemSpriteSheet);
        }
        public IPlayerSprite CreateLinkUseItemSprite(Facing facing)
        {
            //TODO: Implement
            return new LinkUseItemSprite(linkUseItemSpriteSheet, linkWalkingSpriteSheet, facing);
        }
        public IPlayerSprite CreateLinkUseSwordSprite(Facing facing)
        {
            IPlayerSprite swordSprite = facing switch
            {
                Facing.Right => new LinkUseSwordSidewaysSprite(linkUseSwordSidewaysSpriteSheet, true),
                Facing.Left => new LinkUseSwordSidewaysSprite(linkUseSwordSidewaysSpriteSheet, false),
                Facing.Up => new LinkUseSwordUpwardsSprite(linkUseSwordUpwardsSpriteSheet),
                Facing.Down => new LinkUseSwordDownwardsSprite(linkUseSwordDownwardsSpriteSheet),
                _ => throw new NotImplementedException(),
            };
            return swordSprite;
        }
    }
}
