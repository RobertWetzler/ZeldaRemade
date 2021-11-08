using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Projectiles;
using System.Collections.Generic;

namespace Project
{
    class Dragon : IEnemy
    {
        private int timeToAttack;
        private int attackCounter;
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;

        public List<IProjectile> fireballs { get; private set; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }

        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;

        public Dragon(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            this.fireballs = new List<IProjectile>();
            timeToAttack = 3000;
            attackCounter = 0;
            startTime = 0;
            timeToSpawn = 600;
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            SoundFactory.Instance.CreateBossScream();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            currentState.ChangeDirection(direction);
        }

        public void UseWeapon()
        {
            currentState.UseWeapon();
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
                    currentState = new DragonWalkLeft(this);
            }
            movement.CheckIfAtEdge(windowBounds);
            attackCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (attackCounter > timeToAttack)
            {
                attackCounter -= (3 * timeToAttack);
                currentState = new DragonAttack(this);
                UseWeapon();
            }
            sprite.Update(gameTime);
            currentState.Update(gameTime);

            foreach (IProjectile fireball in fireballs)
            {
                fireball.Update(gameTime);
            }
            this.fireballs.RemoveAll(fireball => fireball.IsFinished);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
            foreach (IProjectile fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
        }

    }

}