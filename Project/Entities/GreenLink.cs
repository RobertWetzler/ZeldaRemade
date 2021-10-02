using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;
using Project.Sprites.PlayerSprites;

namespace Project.Entities
{
    public class GreenLink: IPlayer
    {
        private LinkStateMachine stateMachine;

        private Vector2 position;
        private IPlayerSprite sprite;
        private double velocity = 100;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public GreenLink()
        {
            stateMachine = new LinkStateMachine(Facing.Right, Move.Idle, LinkColor.Green);
            sprite = stateMachine.StopMoving();
        }

        public void SetSprite(IPlayerSprite sprite)
        {
            this.sprite = sprite;
        }
        public void MoveUp()
        {
            sprite = stateMachine.MoveUp();
        }
        public void MoveDown()
        {
            sprite = stateMachine.MoveDown();
        }
        public void MoveLeft()
        {
            sprite = stateMachine.MoveLeft();
        }
        public void MoveRight()
        {
            sprite = stateMachine.MoveRight();
        }
        public void StopMoving()
        {
            sprite = stateMachine.StopMoving();
        }
        public void UseSword()
        {
            throw new NotImplementedException();
        }
        public void UseItem()
        {
            throw new NotImplementedException();
        }
        public void BecomeDamaged() 
        { 
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            int x_dir = 0;
            int y_dir = 0;
            if (stateMachine.move == Move.Moving)
            {
                switch (stateMachine.facing)
                {
                    case Facing.Up:
                        y_dir = -1;
                        break;
                    case Facing.Down:
                        y_dir = 1;
                        break;
                    case Facing.Left:
                        x_dir = -1;
                        break;
                    case Facing.Right:
                        x_dir = 1;
                        break;
                }
            }
            position.X += (float)(x_dir * gameTime.ElapsedGameTime.TotalSeconds * velocity);
            position.Y += (float)(y_dir * gameTime.ElapsedGameTime.TotalSeconds * velocity);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color = default)
        {
            sprite.Draw(spriteBatch, this.position);
        }
    }
}
