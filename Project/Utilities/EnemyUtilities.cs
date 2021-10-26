using Project.Entities;
using System.Collections.Generic;

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

        public static List<EnemyDirections> GetAllEnemyDirections()
        {
            List<EnemyDirections> list = new List<EnemyDirections>();
            list.Add(EnemyDirections.North);
            list.Add(EnemyDirections.East);
            list.Add(EnemyDirections.South);
            list.Add(EnemyDirections.West);
            list.Add(EnemyDirections.Northeast);
            list.Add(EnemyDirections.Southeast);
            list.Add(EnemyDirections.Southwest);
            list.Add(EnemyDirections.Northwest);
            return list;
        }
    }
}
