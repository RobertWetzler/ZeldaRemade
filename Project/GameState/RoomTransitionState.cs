using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GameState
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    class RoomTransitionState : IGameState
    {
        private Game1 game;
        private Room nextRoom;
        private Direction dir;
        private Vector2 dir_vect;
        private Vector2 offset;
        private float transitionSpeed = 700f;
        private IHUD smallHUD;
        //difference between offset and desired to be considered done
        private const float transitionEpsilon = 2f; 
        public RoomTransitionState(Game1 game, Room nextRoom, Direction dir)
        {
            this.game = game;
            this.nextRoom = nextRoom;
            this.dir = dir;
            this.dir_vect = dir switch
            {
                Direction.Up => new Vector2(0, -1),
                Direction.Down => new Vector2(0, 1),
                Direction.Left => new Vector2(-1, 0),
                Direction.Right => new Vector2(1, 0),
                _ => throw new NotImplementedException()
            };
            smallHUD = new SmallHUD();
        }
        private bool IsTransitionDone()
        {
            Rectangle roomBounds = RoomManager.Instance.CurrentRoom.Background.Bounds;
            bool done = false;
            switch (dir)
            {
                case Direction.Left:
                case Direction.Right:
                    done = offset.Length() >= roomBounds.Width;
                    break;
                case Direction.Up:
                case Direction.Down:
                    done = offset.Length() >= roomBounds.Height;
                    break;
            }
            return done;
        }
        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            offset += dir_vect * (float)gameTime.ElapsedGameTime.TotalSeconds * transitionSpeed;
            if(IsTransitionDone())
            {
                this.game.GameStateMachine.Play();
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            RoomManager.Instance.CurrentRoom.Background.Draw(spriteBatch, offset);
            this.smallHUD.Draw(spriteBatch);
        }
    }
}
