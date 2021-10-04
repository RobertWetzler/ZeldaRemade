using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Utilities
{
    public static class ColorUtils
    {
        /* 
         * Converts given HSV values to RGB colorspace.
         * h: Hue, 0 - 360
         * s: Saturation, 0 - 1 (S = 1 is purest color)
         * v: Brightness, 0 - 1 (0 is black)
         */
        public static Color HSVToRGB(float h, float s, float v)
        {
            //Algorithm take from https://www.cs.rit.edu/~ncs/color/t_convert.html
            int i;
            float f, p, q, t;
            if (s == 0)
            {
                // achromatic
                return new Color(v, v, v);
            }
            h /= 60;
            i = (int)Math.Floor(h);
            f = h - i; //factorial part of h
            p = v * (1 - s);
            q = v * (1 - s * f);
            t = v * (1 - s * (1 - f));

            switch (i) 
            {
                case 0:
                    return new Color(v, t, p);
                case 1:
                    return new Color(q, v, p);
                case 2:
                    return new Color(p, v, t);
                case 3:
                    return new Color(p, q, v);
                case 4:
                    return new Color(t, p, v);
                default:
                    return new Color(v, p, q);
            }
        }
    }
}
