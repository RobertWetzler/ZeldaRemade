using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public static class Texture2DStorage
    {
        private static Texture2D blockSpriteSheet;

        public static void LoadTextures(ContentManager content) 
        {
            blockSpriteSheet = content.Load<Texture2D>("Blocks/blocks_sheet");
        }

        public static Texture2D GetBlockSpriteSheet()
        {
            return blockSpriteSheet;
        }
    }
}
