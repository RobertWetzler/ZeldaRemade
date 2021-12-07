using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Projectiles;
using Project.Sound;
using Project.Utilities;
using System.Collections.Generic;

namespace Project
{
    class Goriya : IEnemy
    {
        private const int timeToSpawn = 600;
        private const int timeToDespawn = 300;
        private int startTime;
        private int startTimeTwo;
        private IEnemyState currentState;
        private ISprite sprite;
        private float velocity;
        private IProjectile boomerang;
        private EnemyMovement movement;
        private Facing facingDirection;
        private Vector2 position;
        private Health health;
        private double totalFlashTime = 750;
        private double remainingFlashTime;
        private Color colorTint;
        public Facing FacingDirection { get => facingDirection; set => facingDirection = value; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public IProjectile Weapon { get => this.boomerang; set => this.boomerang = value; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;
        public Health Health { get => health; }
        public IEnemyState CurrentState { get => currentState; }

        public Goriya(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            this.facingDirection = Facing.Right;
            startTime = 0;
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            health = new Health(3);
            remainingFlashTime = 0;
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            if (remainingFlashTime <= 0)
            {
                facingDirection = EnemyUtilities.GetFacingFromEnemyDirection(direction);
                currentState.ChangeDirection(direction);
            }

        }

        public void UseWeapon()
        {
            if (remainingFlashTime <= 0)
            {
                currentState.UseWeapon();
                SoundManager.Instance.CreateArrowBoomerangSound();
            }
        }

        public void SetState(IEnemyState state)
        {
            if (remainingFlashTime <= 0)
            {
                currentState = state;
            }
        }

        public void TakeDamage(int damage)
        {
            health.DecreaseHealth(damage);
            if (health.CurrentHealth > 0)
            {
                remainingFlashTime = totalFlashTime;
            }
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (remainingFlashTime <= 0)
            {
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
            else
            {
                remainingFlashTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
                if (remainingFlashTime > 0)
                {
                    UpdateColor();
                }
            }
            if (currentState is EnemyDespawning)
            {
                startTimeTwo += gameTime.ElapsedGameTime.Milliseconds;
                if (startTimeTwo > timeToDespawn)
                {
                    ((IEnemy)this).Despawn();
                }
            }



        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            if (remainingFlashTime <= 0)
            {
                sprite.Draw(spriteBatch, position, Color.White);
            }
            else
            {
                sprite.Draw(spriteBatch, position, this.colorTint);
            }
        }

        private void UpdateColor()
        {
            List<float> hues = new List<float>() { 140f, 180f, 260f, 340f };
            double t = totalFlashTime - remainingFlashTime;
            int i = (int)(t / totalFlashTime * hues.Count * 10) % hues.Count; // cycle through list
            colorTint = ColorUtils.HSVToRGB(hues[i], 1, 1);
        }
    }

}