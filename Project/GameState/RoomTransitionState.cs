using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
using Project.Rooms;
using Project.Rooms.Doors;
using Project.Shading;
using Project.Utilities;
using System;
using System.Collections.Generic;

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
        private Room nextRoom;
        private Direction dir;
        private Vector2 dir_vect;
        private Vector2 offset;
        private Vector2 nextRoomOffset;
        private float transitionSpeed = 700f;
        private IHUD smallHUD;

        public RoomTransitionState(Room nextRoom, Direction dir = Direction.Down)
        {
            this.dir = dir;
            smallHUD = new SmallHUD(false);
            this.dir_vect = dir switch
            {
                Direction.Up => new Vector2(0, 1),
                Direction.Down => new Vector2(0, -1),
                Direction.Left => new Vector2(1, 0),
                Direction.Right => new Vector2(-1, 0),
                _ => throw new NotImplementedException(),
            };
            this.nextRoom = nextRoom;
        }
        public RoomTransitionState(Game1 game, Direction dir)
        {
            this.dir = dir;
            smallHUD = new SmallHUD(false);
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
            if (this.nextRoom is null)
            {
                Game1.Instance.GameStateMachine.Play();
            }
            else
            {
                Game1.Instance.Player.ResetWeapon();
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
            smallHUD.Update(gameTime);
            if (this.nextRoom is null)
            {
                Game1.Instance.GameStateMachine.Play();
                return;
            }
            Rectangle roomBounds = RoomManager.Instance.CurrentRoom.Background.Bounds;
            offset += dir_vect * (float)gameTime.ElapsedGameTime.TotalSeconds * transitionSpeed;
            nextRoomOffset = offset - (new Vector2(roomBounds.Width, roomBounds.Height)) * dir_vect;
            if (IsTransitionDone())
            {
                RoomManager.Instance.SetCurrentRoom(nextRoom);
                Game1.Instance.PassedRoom.Add(RoomManager.Instance.CurrentRoom.RoomID);
                UpdateLinkPosition();
                Game1.Instance.GameStateMachine.Play();
            }
        }
        private void UpdateLinkPosition()
        {
            List<IDoor> doors = RoomManager.Instance.CurrentRoom.Doors;
            IDoor door = dir switch
            {
                Direction.Up => doors.Find(x => x is SouthDoor),
                Direction.Down => doors.Find(x => x is NorthDoor),
                Direction.Left => doors.Find(x => x is EastDoor),
                Direction.Right => doors.Find(x => x is WestDoor),
                _ => throw new NotImplementedException()
            };
            if (door is null)
            {
                Rectangle playerBounds = Game1.Instance.PlayerBounds;
                Game1.Instance.Player.Position = new Vector2(playerBounds.Center.X - 200, playerBounds.Center.Y + 100);
            }
            else
            {
                Vector2 doorCenter = new Vector2(door.BoundingBox.Center.X, door.BoundingBox.Center.Y);
                IPlayer player = Game1.Instance.Player;
                if (door.IsClosed)
                {
                    Vector2 doorOffset = doorCenter - dir_vect * new Vector2(door.BoundingBox.Width, door.BoundingBox.Height);
                    player.Position = doorOffset - dir_vect * new Vector2(player.BoundingBox.Width, player.BoundingBox.Height);
                }
                else
                {
                    player.Position = new Vector2(doorCenter.X - player.BoundingBox.Width / 2, doorCenter.Y - player.BoundingBox.Height / 2);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Game1.Instance.GraphicsDevice.SetRenderTarget(Game1.Instance.LightTarget);
            Game1.Instance.GraphicsDevice.Clear(Color.Black);
            Game1.Instance.GraphicsDevice.SetRenderTarget(null);
            if (GameOptions.IsShaderOn)
            {
                spriteBatch.Begin(samplerState: SamplerState.PointClamp, blendState: BlendState.AlphaBlend, effect: LightShaderFactory.Instance.LightShader);
            }
            else
            {
                spriteBatch.Begin(samplerState: SamplerState.PointClamp, blendState: BlendState.AlphaBlend);
            }
            if (this.nextRoom is null)
            {
                Game1.Instance.GameStateMachine.Play();
                return;
            }
            nextRoom.Background.Draw(spriteBatch, nextRoomOffset);
            foreach (IDoor door in nextRoom.Doors)
            {
                door.Draw(spriteBatch, nextRoomOffset);
            }
            RoomManager.Instance.CurrentRoom.Background.Draw(spriteBatch, offset);
            foreach (IDoor door in RoomManager.Instance.CurrentRoom.Doors)
            {
                door.Draw(spriteBatch, offset);
            }
            spriteBatch.End();
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            this.smallHUD.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
