

using Microsoft.Xna.Framework;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.CollisionHandler
{
    class CollisionDetector
    {
        private static CollisionResponse responder;
        private List<ICollider> colliders;
        private GreenLink myPlayer;

        public CollisionDetector(GreenLink player)
        {
      
    
            myPlayer = player;
           
        }
        public void AddColliders(ICollider collider)
        {
            colliders.Add(collider);
        }

        public Boolean CheckCollision(Rectangle subject, Rectangle target)
        {
            return subject.Intersects(target);
        }

        public CollisionSides GetOrientation(Rectangle subject, Rectangle target)
        {
            float dx = subject.Center.X - target.Center.X;
            float dy = subject.Center.Y - target.Center.Y;
            CollisionSides xSide = dx > 0 ? CollisionSides.Left : CollisionSides.Right;
            CollisionSides ySide = dy > 0 ? CollisionSides.Up : CollisionSides.Down;
            float xGap = Math.Abs(dx) - (subject.Width / 2) - (target.Width / 2);
            float yGap = Math.Abs(dy) - (subject.Height / 2) - (target.Height / 2);
            float xOverlap = Math.Max(0, -xGap);
            float yOverlap = Math.Max(0, -yGap);
            // Choose the direction of the smaller overlap.
            return yOverlap > xOverlap ? xSide : ySide;
        }

        public void Update()
        {
            

            
            Rectangle subjectRectangle, targetRectangle;
            foreach (ICollider subject in colliders)
            {
                foreach (ICollider target in colliders)
                {
                    if (subject == target) { continue; }

                    subjectRectangle = subject.GetRectangle();
                    targetRectangle = target.GetRectangle();

                    if (CheckCollision(subjectRectangle, targetRectangle))
                    {
                        CollisionSides orientation = GetOrientation(subjectRectangle, targetRectangle);
                        
                        responder.HandleCollision(subject, target, orientation);
                    }
                }
            }
        }
    }
}