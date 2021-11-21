using Microsoft.Xna.Framework;
using System;

namespace Project
{
    static class TrapMovementUtilities
    {
        private static int X_DIFF = 10;
        private static int Y_DIFF = 10;

        public static bool ShouldTrapMoveRight(Vector2 trapPos, int bound, Vector2 playerPos)
        {
            if ((int)trapPos.X < (int)playerPos.X && (int)playerPos.X < bound
                && ((Math.Abs((int)playerPos.Y - (int)trapPos.Y) < Y_DIFF)))
            {
                return true;
            }
            return false;
        }

        public static bool ShouldTrapMoveLeft(Vector2 trapPos, int bound, Vector2 playerPos)
        {
            if ((int)playerPos.X < (int)trapPos.X && (int)playerPos.X > bound
                    && (int)(Math.Abs(playerPos.Y - trapPos.Y)) < Y_DIFF)
            {
                return true;
            }
            return false;
        }
        public static bool ShouldTrapMoveDown(Vector2 trapPos, int bound, Vector2 playerPos)
        {
            if ((int)trapPos.Y < (int)playerPos.Y && (int)playerPos.Y < bound
                    && (int)(Math.Abs(playerPos.X - trapPos.X)) < X_DIFF)
            {
                return true;
            }
            return false;
        }
        public static bool ShouldTrapMoveUp(Vector2 trapPos, int bound, Vector2 playerPos)
        {
            if ((int)playerPos.Y < (int)trapPos.Y && (int)playerPos.Y > bound
                    && (int)(Math.Abs(playerPos.X - trapPos.X)) < X_DIFF)
            {
                return true;
            }
            return false;
        }

    }
}
