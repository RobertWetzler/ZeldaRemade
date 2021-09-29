using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;

namespace Project.Entities
{
    public class GreenLink: IPlayer
    {
        private LinkStateMachine stateMachine;

        private Vector2 position;
        private ISprite sprite;
        private IBlockSprite placeholderBlock;
        private double velocity = 100;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public GreenLink()
        {
            stateMachine = new LinkStateMachine(Facing.Right, Move.Idle, LinkColor.Green);
        }

        public void SetSprite(IBlockSprite sprite)
        {
            this.placeholderBlock = sprite;
        }
        public void MoveUp()
        {
            ISprite newSprite = stateMachine.MoveUp();
        }
        public void MoveDown()
        {
            this.sprite = stateMachine.MoveDown();
        }
        public void MoveLeft()
        {
            this.sprite = stateMachine.MoveLeft();
        }
        public void MoveRight()
        {
            this.sprite = stateMachine.MoveRight();
        }
        public void StopMoving()
        {
            this.sprite = stateMachine.StopMoving();
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
            if (this.stateMachine.move == Move.Moving)
            {
                switch (this.stateMachine.facing)
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
            this.position.X += (float)(x_dir * gameTime.ElapsedGameTime.TotalSeconds * velocity);
            this.position.Y += (float)(y_dir * gameTime.ElapsedGameTime.TotalSeconds * velocity);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.placeholderBlock.Draw(spriteBatch, this.position);
        }
    }
}
