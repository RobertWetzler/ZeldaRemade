using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project.Blocks.Walls
{
    class WallCreator
    {
        public static List<Wall> CreateWalls(Rectangle roomBounds, List<IDoor> doors)
        {
            List<Wall> walls = new List<Wall>();
            Rectangle playerBounds = Game1.Instance.PlayerBounds;
            walls.AddRange(CreateNorthWalls(roomBounds, playerBounds, (NorthDoor)doors.Find(x => x is NorthDoor)));
            walls.AddRange(CreateSouthWalls(roomBounds, playerBounds, (SouthDoor)doors.Find(x => x is SouthDoor)));
            walls.AddRange(CreateWestWalls(roomBounds, playerBounds, (WestDoor)doors.Find(x => x is WestDoor)));
            walls.AddRange(CreateEastWalls(roomBounds, playerBounds, (EastDoor)doors.Find(x => x is EastDoor)));
            return walls;
        }
        private static List<Wall> CreateNorthWalls(Rectangle roomBounds, Rectangle playerBounds, NorthDoor northDoor)
        {
            List<Wall> northWalls = new List<Wall>();
            int wallThickness = playerBounds.Y - roomBounds.Y;
            if (northDoor is null)
            {
                Rectangle wallRect = new Rectangle(roomBounds.X, roomBounds.Y, roomBounds.Width, wallThickness);
                northWalls.Add(new Wall(wallRect));
            }
            else
            {
                Rectangle doorBounds = northDoor.BoundingBox;
                Rectangle wallRectLeft = new Rectangle(roomBounds.X, roomBounds.Y, doorBounds.Left - roomBounds.Left, wallThickness);
                Rectangle wallRectRight = new Rectangle(doorBounds.Right, roomBounds.Y, roomBounds.Right - doorBounds.Right, wallThickness);
                northWalls.Add(new Wall(wallRectLeft));
                northWalls.Add(new Wall(wallRectRight));
            }
            return northWalls;
        }
        private static List<Wall> CreateSouthWalls(Rectangle roomBounds, Rectangle playerBounds, SouthDoor southDoor)
        {
            List<Wall> southWalls = new List<Wall>();
            int wallThickness = roomBounds.Bottom - playerBounds.Bottom;
            if (southDoor is null)
            {
                Rectangle wallRect = new Rectangle(roomBounds.X, roomBounds.Bottom - wallThickness, roomBounds.Width, wallThickness);
                southWalls.Add(new Wall(wallRect));
            }
            else
            {
                Rectangle doorBounds = southDoor.BoundingBox;
                Rectangle wallRectLeft = new Rectangle(roomBounds.X, roomBounds.Bottom - wallThickness, doorBounds.Left - roomBounds.Left, wallThickness);
                Rectangle wallRectRight = new Rectangle(doorBounds.Right, roomBounds.Bottom - wallThickness, roomBounds.Right - doorBounds.Right, wallThickness);
                southWalls.Add(new Wall(wallRectLeft));
                southWalls.Add(new Wall(wallRectRight));
            }
            return southWalls;
        }
        private static List<Wall> CreateWestWalls(Rectangle roomBounds, Rectangle playerBounds, WestDoor westDoor)
        {
            List<Wall> westWalls = new List<Wall>();
            int wallThickness = playerBounds.Left - roomBounds.Left;
            if (westDoor is null)
            {
                Rectangle wallRect = new Rectangle(roomBounds.X, roomBounds.Y, wallThickness, roomBounds.Height);
                westWalls.Add(new Wall(wallRect));
            }
            else
            {
                Rectangle doorBounds = westDoor.BoundingBox;
                Rectangle wallRectLeft = new Rectangle(roomBounds.X, roomBounds.Y, wallThickness, doorBounds.Top - roomBounds.Top);
                Rectangle wallRectRight = new Rectangle(roomBounds.X, doorBounds.Bottom, wallThickness, roomBounds.Bottom - doorBounds.Bottom);
                westWalls.Add(new Wall(wallRectLeft));
                westWalls.Add(new Wall(wallRectRight));
            }
            return westWalls;
        }
        private static List<Wall> CreateEastWalls(Rectangle roomBounds, Rectangle playerBounds, EastDoor eastDoor)
        {
            List<Wall> eastWalls = new List<Wall>();
            int wallThickness = roomBounds.Right - playerBounds.Right;
            if (eastDoor is null)
            {
                Rectangle wallRect = new Rectangle(playerBounds.Right, roomBounds.Y, wallThickness, roomBounds.Height);
                eastWalls.Add(new Wall(wallRect));
            }
            else
            {
                Rectangle doorBounds = eastDoor.BoundingBox;
                Rectangle wallRectLeft = new Rectangle(playerBounds.Right, roomBounds.Y, wallThickness, doorBounds.Top - roomBounds.Top);
                Rectangle wallRectRight = new Rectangle(playerBounds.Right, doorBounds.Bottom, wallThickness, roomBounds.Bottom - doorBounds.Bottom);
                eastWalls.Add(new Wall(wallRectLeft));
                eastWalls.Add(new Wall(wallRectRight));
            }
            return eastWalls;
        }
    }
}
