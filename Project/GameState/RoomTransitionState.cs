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
        private Vector2 nextRoomOffset;
        private float transitionSpeed = 700f;
        private IHUD smallHUD;
        public RoomTransitionState(Game1 game, Direction dir)
        {
            this.game = game;
            this.dir = dir;
            smallHUD = new SmallHUD();
            Room curRoom = RoomManager.Instance.CurrentRoom;
            switch (dir)
            {
                case Direction.Up:
                    this.dir_vect = new Vector2(0, 1);
                    this.nextRoom = curRoom.NorthRoom;
                    break;
                case Direction.Down:
                    this.dir_vect = new Vector2(0, -1);
                    this.nextRoom = curRoom.SouthRoom;
                    break;
                case Direction.Left:
                    this.dir_vect = new Vector2(1, 0);
                    this.nextRoom = curRoom.WestRoom;
                    break;
                case Direction.Right:
                    this.dir_vect = new Vector2(-1, 0);
                    this.nextRoom = curRoom.EastRoom;
                    break;
                default:
                    throw new NotImplementedException();
            }
            if(this.nextRoom is null)
            {
                this.game.GameStateMachine.Play();
            }
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
            if (this.nextRoom is null)
            {
                this.game.GameStateMachine.Play();
                return;
            }
            Rectangle roomBounds = RoomManager.Instance.CurrentRoom.Background.Bounds;
            offset += dir_vect * (float)gameTime.ElapsedGameTime.TotalSeconds * transitionSpeed;
            nextRoomOffset = offset - (new Vector2(roomBounds.Width, roomBounds.Height)) * dir_vect;
            if(IsTransitionDone())
            {
                RoomManager.Instance.SetCurrentRoom(nextRoom);
                this.game.GameStateMachine.Play();
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (this.nextRoom is null)
            {
                this.game.GameStateMachine.Play();
                return;
            }
            nextRoom.Background.Draw(spriteBatch, nextRoomOffset);
            RoomManager.Instance.CurrentRoom.Background.Draw(spriteBatch, offset);
            this.smallHUD.Draw(spriteBatch);
        }
    }
}
