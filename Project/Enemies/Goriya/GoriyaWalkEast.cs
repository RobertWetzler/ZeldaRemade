using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class GoriyaWalkEast : IEnemyState
    {
        private Goriya goriya;

        public GoriyaWalkEast(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.EnemySprite = NPCEnemySpriteFactory.Instance.CreateGoriyaWalkEastSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    goriya.SetState(new GoriyaWalkNorth(goriya));
                    break;
                case EnemyDirections.South:
                    goriya.SetState(new GoriyaWalkSouth(goriya));
                    break;
                case EnemyDirections.West:
                    goriya.SetState(new GoriyaWalkWest(goriya));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            goriya.XPos += (float)(gameTime.ElapsedGameTime.TotalSeconds * goriya.Velocity);
        }

        public void UseWeapon()
        {
            goriya.SetState(new GoriyaUseItem(goriya));
        }
    }
}
