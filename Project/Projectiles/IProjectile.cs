using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Projectiles
{
    public interface IProjectile: ICollidable
    {
        public bool IsFriendly { get; }
        public bool IsFinished { get; }
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
        public void Despawn()
        {
            RoomManager.Instance.CurrentRoom.RemoveProjectile(this);
        }
    }
}
