using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision
{
    public class CollisionIterator
    {
        private List<ICollidable> dynamics;
        private List<ICollidable> statics;
        private AllCollisionHandler collisionHandler;
        public CollisionIterator(List<ICollidable> dynamics, List<ICollidable> statics)
        {
            this.dynamics = dynamics;
            this.statics = statics;
            collisionHandler = new AllCollisionHandler();
        }

        public void UpdateCollisions()
        {
            foreach (ICollidable dynamic in dynamics)
            {
                foreach (ICollidable staticObj in statics)
                {
                    if (CollisionDetector.IsColliding(dynamic, staticObj))
                    {
                        Console.WriteLine("static-dynamic collision!");
                        CollisionSide side = CollisionDetector.GetCollisionSide(dynamic, staticObj);
                        collisionHandler.HandleCollision(dynamic, staticObj, side);
                    }
                }
                foreach (ICollidable dynamic2 in dynamics)
                {
                    if (dynamic != dynamic2 && CollisionDetector.IsColliding(dynamic, dynamic2))
                    {
                        Console.WriteLine("dynamic-dynamic collision!");
                        CollisionSide side = CollisionDetector.GetCollisionSide(dynamic, dynamic2);
                        collisionHandler.HandleCollision(dynamic, dynamic2, side);
                    }
                }
            }
        }
    }
}
