using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class WallMasterWalkEast : IEnemyState
    {
        private WallMaster wallMaster;

        public WallMasterWalkEast(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.wallMaster.EnemySprite = EnemySpriteFactory.Instance.CreateWallMasterSprite(Entities.Facing.Right);

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.West:
                    wallMaster.SetState(new WallMasterWalkWest(wallMaster));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            wallMaster.Position = new Vector2(wallMaster.Position.X + (float)(gameTime.ElapsedGameTime.TotalSeconds * wallMaster.Velocity),
                                            wallMaster.Position.Y);
        }

        public void UseWeapon()
        {
        }
    }
}
