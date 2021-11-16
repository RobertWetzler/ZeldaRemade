using Microsoft.Xna.Framework;
using Project.Projectiles;
using System;

namespace Project.Entities
{
    /* Class to return an IProjectile of a given type, with a specific direction and position. */
    public static class WeaponSelector
    {
        public static IProjectile GetWeapon(WeaponTypes weaponType, Facing facing, Vector2 position)
        {
            float offset = 20f;
            Vector2 offsetDir = facing switch
            {
                Facing.Right => new Vector2(1, 0),
                Facing.Left => new Vector2(-1.5f, 0),
                Facing.Up => new Vector2(0, -1.5f),
                Facing.Down => new Vector2(0, 1),
                _ => throw new NotImplementedException()
            };
            Vector2 newPosition = position + offset * offsetDir;
            IProjectile weapon = weaponType switch
            {
                WeaponTypes.Arrow => new Arrow(facing, newPosition),
                WeaponTypes.BlueArrow => new BlueArrow(facing, newPosition),
                WeaponTypes.Boomerang => new Boomerang(facing, newPosition),
                WeaponTypes.BlueBoomerang => new BlueBoomerang(facing, newPosition),
                WeaponTypes.Bomb => new Bomb(facing, newPosition),
                WeaponTypes.Flame => new Flame(facing, newPosition),
                WeaponTypes.Sword => new SwordBeam(facing, newPosition),
                _ => throw new NotImplementedException()
            };
            return weapon;
        }
    }
}
