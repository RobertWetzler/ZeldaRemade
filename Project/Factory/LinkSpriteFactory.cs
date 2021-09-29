using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Sprites.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Text;

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
			//TODO: Implement
			return new LinkIdleSprite(linkWalkingSpriteSheet, facing);
			throw new NotImplementedException();
		}

		public IPlayerSprite CreateLinkWalkingSprite(Facing facing)
		{
			//TODO: Implement
			return new LinkWalkingSprite(linkWalkingSpriteSheet, facing);
			throw new NotImplementedException();
		}
		public IPlayerSprite CreateLinkPickupItemSprite()
		{
			//TODO: Implement
			return new LinkPickupItemSprite(linkPickupItemSpriteSheet);
			throw new NotImplementedException();
		}
		public IPlayerSprite CreateLinkUseItemSprite(Facing facing)
		{
			//TODO: Implement
			return new LinkUseItemSprite(linkUseItemSpriteSheet, facing);
			throw new NotImplementedException();
		}
		public IPlayerSprite CreateLinkUseSwordDownwardsSprite()
		{
			//TODO: Implement
			return new LinkUseSwordDownwardsSprite(linkUseSwordDownwardsSpriteSheet);
			throw new NotImplementedException();
		}
		public IPlayerSprite CreateLinkUseSwordSidewaysSprite(bool facingRight)
		{
			//TODO: Implement. Mirror if facingRight is false (or we can make a different sprite class)
			return new LinkUseSwordSidewaysSprite(linkUseSwordSidewaysSpriteSheet, facingRight);
			throw new NotImplementedException();
		}
		public IPlayerSprite CreateLinkUseSwordUpwardsSprite()
		{
			//TODO: Implement
			return new LinkUseSwordUpwardsSprite(linkUseSwordUpwardsSpriteSheet);
			throw new NotImplementedException();
		}
	}
}
