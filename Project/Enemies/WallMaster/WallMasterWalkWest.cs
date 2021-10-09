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
            this.wallMaster.EnemySprite = NPCEnemySpriteFactory.Instance.CreateWallMasterSprite(Entities.Facing.Left);

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
            wallMaster.XPos += (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * wallMaster.Velocity);
        }

        public void UseWeapon()
        {
        }
    }
}
