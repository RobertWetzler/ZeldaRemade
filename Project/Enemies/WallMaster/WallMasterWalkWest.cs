using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class WallMasterWalkWest : IEnemyState
    {
        private WallMaster wallMaster;

        public WallMasterWalkWest(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.wallMaster.EnemySprite = EnemySpriteFactory.Instance.CreateWallMasterSprite(Entities.Facing.Left);

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    wallMaster.SetState(new WallMasterWalkEast(wallMaster));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            wallMaster.Position = new Vector2(wallMaster.Position.X + (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * wallMaster.Velocity),
                                          wallMaster.Position.Y);
        }

        public void UseWeapon()
        {
        }
    }
}
