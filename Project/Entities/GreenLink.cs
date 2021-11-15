using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.HUD;
using Project.Projectiles;
using Project.Sprites.ItemSprites;
using Project.Sprites.PlayerSprites;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project.Entities
{
    public class GreenLink : IPlayer, ICollidable
    {
        private LinkStateMachine stateMachine;
        private Vector2 position;
        private IPlayerSprite sprite;
        private List<IWeaponSprite> weaponSprites;
        private double velocity = 250;
        private Game1 game;
        private int health = 6;
        private PlayerInventory inventory;

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

        public int Health { get => health; set => health = value; }

        public GreenLink(Game1 game)
        {
            this.game = game;
            position = new Vector2(500, 500);
            stateMachine = new LinkStateMachine(this, Facing.Right, Move.Idle, LinkColor.Green);
            sprite = stateMachine.StopMoving();
            weaponSprites = new List<IWeaponSprite>();
            inventory = new PlayerInventory();
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

        public void UseWeapon(WeaponTypes weaponType)
        {
            IProjectile potentialWeapon = WeaponSelector.GetWeapon(weaponType, stateMachine.facing, position);
            (sprite, potentialWeapon) = stateMachine.UseWeapon(potentialWeapon); // only sets this.weaponSprite if the state machine allows it
            if (potentialWeapon != null)
            {
                RoomManager.Instance.CurrentRoom.AddProjectile(potentialWeapon);
            }
        }
        public void BecomeDamaged()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            this.game.Player = new DamagedLink(this, game);
            if (health > 0)
            {
                health -= damage;
            }
            else
            {
                //link death command
                health = 6; //reset to full health
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

            float newX = position.X + (float)(x_dir * gameTime.ElapsedGameTime.TotalSeconds * velocity);
            float newY = position.Y + (float)(y_dir * gameTime.ElapsedGameTime.TotalSeconds * velocity);

            if (x_dir == 1)
            {
                position.X = (int)(newX + BoundingBox.Width) < windowBounds.Right ? newX : windowBounds.Right - BoundingBox.Width;
            }
            else if (x_dir == -1)
            {
                position.X = (int)newX > windowBounds.Left ? newX : windowBounds.Left;
            }
            else if (y_dir == 1)
            {
                position.Y = (int)(newY + BoundingBox.Height) < windowBounds.Bottom ? newY : windowBounds.Bottom - BoundingBox.Height;
            }
            else
            {
                position.Y = (int)(newY) > windowBounds.Top ? newY : windowBounds.Top;
            }

          
            sprite.Update(gameTime);
            foreach (IWeaponSprite weaponSprite in weaponSprites)
            {
                weaponSprite.Update(gameTime);
            }
            weaponSprites.RemoveAll(weaponSprite => weaponSprite.isFinished());
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, this.position, color);
            foreach (IWeaponSprite weaponSprite in weaponSprites)
            {
                weaponSprite.Draw(spriteBatch);
            }
        }
    }
}
