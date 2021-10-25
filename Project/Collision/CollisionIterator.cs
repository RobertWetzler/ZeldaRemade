using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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
                        Debug.WriteLine("static-dynamic collision!");
                        CollisionSide side = CollisionDetector.GetCollisionSide(dynamic, staticObj);
                        collisionHandler.HandleCollision(dynamic, staticObj, side);
                    }
                }
                foreach (ICollidable dynamic2 in dynamics)
                {
                    if (dynamic != dynamic2 && CollisionDetector.IsColliding(dynamic, dynamic2))
                    {
                        Debug.WriteLine("dynamic-dynamic collision!");
                        CollisionSide side = CollisionDetector.GetCollisionSide(dynamic, dynamic2);
                        collisionHandler.HandleCollision(dynamic, dynamic2, side);
                    }
                }
            }
        }
    }
}
