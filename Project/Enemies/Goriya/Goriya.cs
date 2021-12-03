using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Projectiles;
using Project.Sound;
using Project.Utilities;

namespace Project
{
    class Goriya : IEnemy
    {
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private ISprite sprite;
        private float velocity;
        private IProjectile boomerang;
        private EnemyMovement movement;
        private Facing facingDirection;
        private Vector2 position;
        private Health health;

        public Facing FacingDirection { get => facingDirection; set => facingDirection = value; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public IProjectile Weapon { get => this.boomerang; set => this.boomerang = value; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;
        public Health Health { get => health; }
        public Goriya(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            this.facingDirection = Facing.Right;
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
            currentState.UseWeapon();
            SoundManager.Instance.CreateArrowBoomerangSound();
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
                            currentState = new GoriyaWalkSouth(this);
                            break;
                        case Facing.Left:
                            currentState = new GoriyaWalkWest(this);
                            break;
                        case Facing.Right:
                            currentState = new GoriyaWalkEast(this);
                            break;
                        case Facing.Up:
                            currentState = new GoriyaWalkNorth(this);
                            break;
                    }
                }
            }
            if (!(currentState is GoriyaUseItem))
            {
                movement.MoveWASDOrAttack(windowBounds, gameTime);
            }

            currentState.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
        }


    }

}