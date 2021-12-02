using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using System.Diagnostics;

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
        private IPlayer player;
        private Vector2 startPos;
        private EnemyDirections movingDirection;
        private int health = int.MaxValue;
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;
        public int Health { get => health; set => health = value; }
        public Trap(Vector2 pos, IPlayer player)
        {
            this.position = pos;
            this.startPos = pos;
            this.velocity = 350f;
            this.player = player;
            startTime = 0;
            timeToSpawn = 600;
            movingDirection = EnemyDirections.None;
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
            int XCoorWideEdge = (windowBounds.Right + 128) / 2;
            int YCoorShortEdge = ((windowBounds.Bottom + 128) / 2) + 85;

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
            else if (movingDirection == EnemyDirections.None)
            {
                if (TrapMovementUtilities.ShouldTrapMoveRight(startPos, XCoorWideEdge, player.Position))
                {
                    SetState(new TrapMoveRight(this));
                    movingDirection = EnemyDirections.East;

                }
                else if (TrapMovementUtilities.ShouldTrapMoveLeft(startPos, XCoorWideEdge, player.Position))
                {
                    SetState(new TrapMoveLeft(this));
                    movingDirection = EnemyDirections.West;

                }
                else if (TrapMovementUtilities.ShouldTrapMoveDown(startPos, YCoorShortEdge, player.Position))
                {
                    SetState(new TrapMoveDown(this));
                    movingDirection = EnemyDirections.South;
                }
                else if (TrapMovementUtilities.ShouldTrapMoveUp(startPos, YCoorShortEdge, player.Position))
                {
                    SetState(new TrapMoveUp(this));
                    movingDirection = EnemyDirections.North;
                }
            }
            else
            {
                if (movingDirection == EnemyDirections.East)
                {
                    if ((int)position.X >= XCoorWideEdge)
                    {
                        ChangeDirection(EnemyDirections.West);
                    }
                    else if ((int)position.X < (int)startPos.X)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.None;
                    }

                }
                if (movingDirection == EnemyDirections.West)
                {
                    if ((int)position.X < XCoorWideEdge)
                    {
                        ChangeDirection(EnemyDirections.East);
                    }
                    else if ((int)position.X > (int)startPos.X)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.None;
                    }
                }
                if (movingDirection == EnemyDirections.South)
                {
                    if ((int)position.Y >= YCoorShortEdge)
                    {
                        ChangeDirection(EnemyDirections.North);
                    }
                    else if ((int)position.Y < (int)startPos.Y)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.None;
                    }
                }
                if (movingDirection == EnemyDirections.North)
                {
                    if ((int)position.Y <= YCoorShortEdge)
                    {
                        ChangeDirection(EnemyDirections.South);
                    }
                    else if ((int)position.Y > (int)startPos.Y)
                    {
                        position = startPos;
                        SetState(new TrapStill(this));
                        movingDirection = EnemyDirections.None;
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