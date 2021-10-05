using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;
using Project.Sprites.ItemSprites;
using Project.Sprites.PlayerSprites;

namespace Project.Entities
{
    public class GreenLink: IPlayer
    {
        private LinkStateMachine stateMachine;

        private Vector2 position;
        private IPlayerSprite sprite;
        private List<IWeaponSprite> weaponSprites;
        private double velocity = 200;
        private Game1 game;
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

        public GreenLink(Game1 game)
        {
            this.game = game;
            stateMachine = new LinkStateMachine(this, Facing.Right, Move.Idle, LinkColor.Green);
            sprite = stateMachine.StopMoving();
            weaponSprites = new List<IWeaponSprite>();
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
            sprite = stateMachine.UseSword();
        }

        public void UseWeapon(WeaponTypes weaponType)
        {
            IWeaponSprite potentialWeapon = WeaponSpriteSelector.GetWeaponSprite(weaponType, stateMachine.facing, position);
            (sprite, potentialWeapon) = stateMachine.UseWeapon(potentialWeapon); // only sets this.weaponSprite if the state machine allows it
            if (potentialWeapon != null)
            {
                weaponSprites.Add(potentialWeapon);
            }
        }
        public void BecomeDamaged() 
        { 
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            this.game.Player = new DamagedLink(this, game);
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
