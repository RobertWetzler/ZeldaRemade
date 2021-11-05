using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;

namespace Project
{
    class Trap : IEnemy
    {
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private TrapMovement movement;
        private IPlayer player;
        private Vector2 startPos;
        private EnemyDirections movingDirection;

        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public Trap(Vector2 pos, IPlayer player)
        {
            this.position = pos;
            this.startPos = pos;
            this.velocity = 350f;
            this.player = player;
            startTime = 0;
            timeToSpawn = 600;
            movement = new TrapMovement(this, player);
            movingDirection = EnemyDirections.Southwest;
            currentState = new EnemySpawning(this);


        }

        public void ChangeDirection(EnemyDirections direction)
        {
            currentState.ChangeDirection(direction);
        }

        public void UseWeapon()
        {
            //No weapon
        }

        public void SetState(IEnemyState state)
        {
            currentState = state;
        }

        public void TakeDamage(int damage)
        {
            //Don't think they take damage
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            sprite.Update(gameTime);
            currentState.Update(gameTime);
            if (currentState is EnemySpawning)
            {
                startTime += gameTime.ElapsedGameTime.Milliseconds;
                if (startTime > timeToSpawn)
                {
                    this.sprite = EnemySpriteFactory.Instance.CreateTrapSprite();
                    currentState = new TrapStill(this);
                }
            }
            else
            {
                int middleOfWidth = (windowBounds.Right - windowBounds.Left) / 2 + 128;
                int middleOfHeight = (windowBounds.Bottom - windowBounds.Top) / 2 + 128;
                const int Y_DIFF = 5;
                const int X_DIFF = 5;

                if ((int)startPos.X < (int)player.Position.X && (int)player.Position.X < middleOfWidth
                    && (int)(Math.Abs(player.Position.Y - startPos.Y)) < Y_DIFF)
                {
                    SetState(new TrapMoveRight(this));
                    movingDirection = EnemyDirections.East;
                    
                }else if ((int)player.Position.X < (int)startPos.X && (int)player.Position.X > middleOfWidth 
                    && (int)(Math.Abs(player.Position.Y - startPos.Y)) < Y_DIFF)
                {
                    SetState(new TrapMoveLeft(this));
                    movingDirection = EnemyDirections.West;

                }else if((int)startPos.Y < (int)player.Position.Y && (int)player.Position.Y < middleOfHeight
                    && (int)(Math.Abs(player.Position.X - startPos.X)) < X_DIFF)
                {
                    SetState(new TrapMoveDown(this));
                    movingDirection = EnemyDirections.South;
                }else if ((int)player.Position.Y < (int)startPos.Y  && (int)player.Position.Y > middleOfHeight
                    && (int)(Math.Abs(player.Position.X - startPos.X)) < X_DIFF)
                {
                    SetState(new TrapMoveUp(this));
                    movingDirection = EnemyDirections.North;
                }

                if (movingDirection == EnemyDirections.East)
                {
                    if ((int)position.X >= middleOfWidth)
                    {
                        ChangeDirection(EnemyDirections.West);
                    }
                    else if ((int)position.X < (int)startPos.X)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.Southwest;
                    }
                
                }
                if (movingDirection == EnemyDirections.West)
                {
                    if ((int)position.X < middleOfWidth)
                    {
                        ChangeDirection(EnemyDirections.East);
                    }
                    else if ((int)position.X > (int)startPos.X)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.Southwest;
                    }
                }
                if (movingDirection == EnemyDirections.South)
                {
                    if ((int)position.Y >= middleOfHeight)
                    {
                        ChangeDirection(EnemyDirections.North);
                    }
                    else if ((int)position.Y < (int)startPos.Y)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.Southwest;
                    }
                }
                if (movingDirection == EnemyDirections.North)
                {
                    if ((int)position.Y <= middleOfHeight)
                    {
                        ChangeDirection(EnemyDirections.South);
                    }
                    else if ((int)position.Y > (int)startPos.Y)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.Southwest;
                    }
                }
                


            }

            
            
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
        }
    }

}