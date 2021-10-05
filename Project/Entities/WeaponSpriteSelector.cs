using Microsoft.Xna.Framework;
using Project.Factory;
using Project.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    /* Class to return an IWeaponSprite of a given type, with a specific direction and position. */
    public static class WeaponSpriteSelector
    {
        public static IWeaponSprite GetWeaponSprite(WeaponTypes weaponType, Facing facing, Vector2 position)
        {
            IWeaponSprite weaponSprite = weaponType switch
            {
                WeaponTypes.Arrow => ItemSpriteFactory.Instance.CreateArrowSprite(facing, position),
                WeaponTypes.BlueArrow => ItemSpriteFactory.Instance.CreateBlueArrowSprite(facing, position),
                WeaponTypes.Boomerang => ItemSpriteFactory.Instance.CreateBoomerangSprite(facing, position),
                WeaponTypes.BlueBoomerang => ItemSpriteFactory.Instance.CreateBlueBoomerangSprite(facing, position),
                WeaponTypes.Bomb => ItemSpriteFactory.Instance.CreateBombSprite(facing, position),
                WeaponTypes.Flame => ItemSpriteFactory.Instance.CreateFlameSprite(facing, position),
                _ => throw new NotImplementedException(), //default
            };
            return weaponSprite;
        }
    }
}
