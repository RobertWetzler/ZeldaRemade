using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private float transitionSpeed = 500f;
        //difference between offset and desired to be considered done
        private const float transitionEpsilon = 10f; 
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
        }
        private bool IsTransitionDone()
        {
            bool doneLaterally = (dir == Direction.Left || dir == Direction.Right) &&
                Math.Abs(offset.Length() - RoomManager.Instance.CurrentRoom.Background.Width) < transitionEpsilon;
            bool doneVertically = (dir == Direction.Up || dir == Direction.Down) &&
                Math.Abs(offset.Length() - RoomManager.Instance.CurrentRoom.Background.Height) < transitionEpsilon;
            return doneLaterally || doneVertically;
        }
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            offset += dir_vect * (float)gameTime.ElapsedGameTime.TotalSeconds * transitionSpeed;
            if(IsTransitionDone())
            {
                this.game.GameStateMachine.Play();
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            RoomManager.Instance.CurrentRoom.Background.Draw(spriteBatch, graphics, offset);
        }
    }
}
