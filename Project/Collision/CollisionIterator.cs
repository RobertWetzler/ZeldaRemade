using System.Collections.Generic;

namespace Project.Collision
{
    public class CollisionIterator
    {
        private AllCollisionHandler collisionHandler;
        public CollisionIterator()
        {
            collisionHandler = new AllCollisionHandler();
        }

        public void UpdateCollisions(List<ICollidable> dynamics, List<ICollidable> statics)
        {
            foreach (ICollidable dynamic in dynamics)
            {
                foreach (ICollidable staticObj in statics)
                {
                    if (CollisionDetector.IsColliding(dynamic, staticObj))
                    {
                        collisionHandler.HandleCollision(dynamic, staticObj, CollisionDetector.GetCollisionSide(dynamic, staticObj));
                        collisionHandler.HandleCollision(staticObj, dynamic, CollisionDetector.GetCollisionSide(staticObj, dynamic));
                    }
                }
                foreach (ICollidable dynamic2 in dynamics)
                {
                    if (dynamic != dynamic2 && CollisionDetector.IsColliding(dynamic, dynamic2))
                    {
                        collisionHandler.HandleCollision(dynamic, dynamic2, CollisionDetector.GetCollisionSide(dynamic, dynamic2));
                    }
                }
            }
        }
    }
}
