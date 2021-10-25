using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Blocks.MovableBlock
{
    enum MovingDir
    {
        Up,
        Down,
        Left,
        Right
    }
    class MovingBlockState
    {
        private MovableBlock block;
        private Vector2 dir;
        private Vector2 start;
        private float velocity = 200;

        public MovingBlockState(MovableBlock block, MovingDir dir)
        {
            this.block = block;
            this.start = block.Position;
            switch (dir)
            {
                case MovingDir.Up:
                    this.dir = new Vector2(0, -1);
                    break;
                case MovingDir.Down:
                    this.dir = new Vector2(0, 1);
                    break;
                case MovingDir.Left:
                    this.dir = new Vector2(-1, 0);
                    break;
                case MovingDir.Right:
                    this.dir = new Vector2(1, 0);
                    break;
            }
        }

        public void Update(GameTime gametime)
        {
            if (Vector2.Distance(start, block.Position) < block.BoundingBox.Width)
            {
                block.Position += (float)gametime.ElapsedGameTime.TotalSeconds * velocity * dir;
            }
            else
            {
                block.Position = start + dir * block.BoundingBox.Width;
            }
        }
    }
}
