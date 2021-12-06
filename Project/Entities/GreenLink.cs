using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Projectiles;
using Project.Shading;
using Project.Sprites.ItemSprites;
using Project.Sprites.PlayerSprites;
using Project.Utilities;
using System.Collections.Generic;

namespace Project.Entities
{
    public class GreenLink : TorchLight, IPlayer, ICollidable
    {
        private const int START_HEALTH = 6;
        private LinkStateMachine stateMachine;
        private Vector2 position;
        private IPlayerSprite sprite;
        private List<IProjectile> projectiles;
        private double velocity = 250;
        private Game1 game;
        private PlayerInventory inventory;
        private Health health;
        public Health Health { get => health; }
        private IItems pickUpItem;

        private bool isApproachBat;

        /**
        * Shrinks the bounding box for link
        * 16x16 -> 14x14 bounding box before scaling
        * Leave some space at top of link head. Decrease width of link by a bit
        * for easier movement between blocks
        */
        private Rectangle SetBoundingBox()
        {
            const float BOUNDINGBOX_OFFSET = 0.125f;
            if (!(sprite is LinkUseSwordUpwardsSprite) && !(sprite is LinkUseSwordSidewaysSprite)
                && !(sprite is LinkUseSwordDownwardsSprite))
            {
                float width = sprite.DestRectangle.Width * (1 - BOUNDINGBOX_OFFSET);
                float height = sprite.DestRectangle.Height * (1 - BOUNDINGBOX_OFFSET);
                int x = sprite.DestRectangle.X + ((sprite.DestRectangle.Width - (int)width) / 2);
                int y = sprite.DestRectangle.Y + (sprite.DestRectangle.Height - (int)height);
                return new Rectangle(x, y, (int)width, (int)height);
            }
            return sprite.DestRectangle;

        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public IPlayerSprite PlayerSprite
        {
            get => this.sprite;
        }
        public LinkStateMachine StateMachine
        {
            get => this.stateMachine;
        }
        public Rectangle BoundingBox => SetBoundingBox();
        public CollisionType CollisionType => CollisionType.Player;
        public PlayerInventory Inventory => inventory;

        public bool IsApproachBat { get => isApproachBat; set => isApproachBat = value; }

        public GreenLink(Game1 game)
        {
            this.game = game;
            position = new Vector2(500, 500);
            stateMachine = new LinkStateMachine(this, Facing.Right, Move.Idle, LinkColor.Green);
            sprite = stateMachine.StopMoving();
            inventory = new PlayerInventory();
            projectiles = new List<IProjectile>();
            health = new Health(START_HEALTH);
            isApproachBat = false;
        }

        public void SetSprite(IPlayerSprite sprite)
        {
            this.sprite = sprite;
        }
        public void MoveUp()
        {
            pickUpItem = null;
            sprite = stateMachine.MoveUp();
        }
        public void MoveDown()
        {
            pickUpItem = null;
            sprite = stateMachine.MoveDown();
        }
        public void MoveLeft()
        {
            pickUpItem = null;
            sprite = stateMachine.MoveLeft();
        }
        public void MoveRight()
        {
            pickUpItem = null;
            sprite = stateMachine.MoveRight();
        }
        public void StopMoving()
        {
            pickUpItem = null;
            sprite = stateMachine.StopMoving();
        }

        public void UseWeapon(WeaponTypes weaponType)
        {
            pickUpItem = null;
            IProjectile potentialWeapon = WeaponSelector.GetWeapon(weaponType, stateMachine.facing, position);
            (sprite, potentialWeapon) = stateMachine.UseWeapon(potentialWeapon); // only sets this.weaponSprite if the state machine allows it

            if (potentialWeapon != null)
            {
                RoomManager.Instance.CurrentRoom.AddProjectile(potentialWeapon);
                if (weaponType == WeaponTypes.Bomb)
                {
                    inventory.RemoveItem(ItemType.Bomb);
                }
            }
        }

        public void TakeDamage(int damage)
        {
            pickUpItem = null;
            this.game.Player = new DamagedLink(this, game);
            health.DecreaseHealth(damage);
            inventory.RemoveNItems(ItemType.Heart, damage);
            if (health.CurrentHealth <= 0)
            {
                game.GameStateMachine.TitleScreen();
                health.MaxHealth = START_HEALTH;
                inventory.RemoveNItems(ItemType.HeartContainer, inventory.GetItemCount(ItemType.HeartContainer));
                inventory.AddNItems(ItemType.HeartContainer, START_HEALTH / 2);
                health.CurrentHealth = health.MaxHealth;
                inventory.RemoveNItems(ItemType.Heart, inventory.GetItemCount(ItemType.Heart));
                inventory.AddNItems(ItemType.Heart, health.CurrentHealth);
                RoomManager.LoadAllRooms(this, Game1.Instance.Graphics);
                RoomManager.Instance.SetCurrentRoom(RoomManager.GetRoom(11));
            }

        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            this.sprite = this.stateMachine.Update();
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
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Update(gameTime);
            }
            projectiles.RemoveAll(projectile => !projectile.IsActive);
            if (pickUpItem != null)
            {
                pickUpItem.Update(gameTime);
            }


        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, this.position, color);

            foreach (IProjectileSprite projectile in projectiles)
            {
                projectile.Update(gameTime);
            }

            projectiles.RemoveAll(projectile => projectile.IsFinished);
            if (pickUpItem != null)
            {
                pickUpItem.Draw(spriteBatch);
            }

        }

        public void PickUpItem(IItems item)
        {
            sprite = stateMachine.PickUpItem();
            pickUpItem = item;
        }
    }
}
