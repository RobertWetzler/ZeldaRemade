using System;
using System.Diagnostics;

namespace Project.Utilities
{
    public static class GameOptions
    {

        public static bool IsHarderVersion { get; set; }
        private static String normal = @"Content/XML/Map_Building.xml";
        private static String hard = @"Content/XML/Hard_Map.xml";

        public static string XML { get; set; }
        
        

        public static void LoadXMLVersion()
        {
            
            if (IsHarderVersion)
            {
                XML = normal;

            }
            else
            {
                XML = hard;
            }

        }

    }
}
