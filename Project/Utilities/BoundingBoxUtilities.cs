using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Utilities
{
    static class BoundingBoxUtilities
    {
        /**
         * Shrinks the bounding box for link
         * 
         * Use for IPlayer
         */
        public static Rectangle ShrinkLinkBoundingBox(Rectangle rectangle)
        {
            const float HEIGHT_OFFSET = 0.25f;
            const float WIDTH_OFFSET = 0.1f;
            float width = rectangle.Width * (1 - WIDTH_OFFSET);
            float height = rectangle.Height * (1 - HEIGHT_OFFSET);
            int x = rectangle.X + ((rectangle.Width - (int)width) / 2) ;
            int y = rectangle.Y + (rectangle.Height - (int)height);
            return new Rectangle(x, y, (int)width, (int)height);
        }


    }
}
