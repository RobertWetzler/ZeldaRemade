using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Utilities;


namespace Project
{
    class Snake : IEnemy
    {
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private Facing facingDirection;
        private Vector2 pos;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;

        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => pos; set => pos = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;

        public Snake(Vector2 pos)
        {
            this.pos = pos;
            this.velocity = 50f;
            this.facingDirection = Facing.Down;
            startTime = 0;
            timeToSpawn = 600;
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            facingDirection = EnemyUtilities.GetFacingFromEnemyDirection(direction);
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
            throw new System.NotImplementedException();
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (currentState is EnemySpawning)
            {
                startTime += gameTime.ElapsedGameTime.Milliseconds;
                if (startTime > timeToSpawn)
                {
                    switch (this.facingDirection)
                    {
                        case Facing.Down:
                            currentState = new SnakeWalkSouth(this);
                            break;
                        case Facing.Left:
                            currentState = new SnakeWalkWest(this);
                            break;
                        case Facing.Right:
                            currentState = new SnakeWalkEast(this);
                            break;
                        case Facing.Up:
                            currentState = new SnakeWalkNorth(this);
                            break;
                    }
                }
            }

            movement.MoveWASDOnly(windowBounds, gameTime);
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, pos);
        }
    }

}