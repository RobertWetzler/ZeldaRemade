using Microsoft.Xna.Framework;
using Project.Sprites.PlayerSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public interface IPlayer: IEntity
    {
        public Vector2 Position { get; set; }
        // used for setting an intial sprite upon Game.LoadContent()
        void SetSprite(IPlayerSprite sprite);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void UseSword();
        void UseItem();

    }
}
