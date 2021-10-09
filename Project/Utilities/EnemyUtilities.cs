using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Utilities
{
    static class EnemyUtilities
    {
        public static EnemyDirections GetEnemyDirectionFromFacing(Facing direction)
        {
            switch (direction)
            {
                case Facing.Up:
                    return EnemyDirections.North;
                case Facing.Down:
                    return EnemyDirections.South;
                case Facing.Left:
                    return EnemyDirections.West;
                default:
                    return EnemyDirections.East;
            }
        }
        public static Facing GetFacingFromEnemyDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    return Facing.Up;
                case EnemyDirections.South:
                    return Facing.Down;
                case EnemyDirections.West:
                    return Facing.Left;
                case EnemyDirections.East:
                    return Facing.Right;
            }
            return Facing.Right;
        }
    }
}
