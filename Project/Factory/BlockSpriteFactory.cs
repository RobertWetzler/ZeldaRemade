using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.BlockSprites;

namespace Project.Factory
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("Blocks/blocks_spritesheet");
        }

        //Plain green block
        public IBlock CreatePlainBlockSprite()
        {
            //Parameters - Texture2D for spritesheet, number of rows in spritesheet, number of columns in spritesheet
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 0);
        }

        //Plain black block
        public IBlock CreateBlackBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 0);
        }
        //White brick block
        public IBlock CreateBrickBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 2, 0);
        }

        //Horizontal layered white block
        public IBlock CreateLayeredBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 2, 1);
        }

        //Green block with little dots
        public IBlock CreateDottedBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 1);
        }
        //Block with square with 4 diagonals
        public IBlock CreatePyramidBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 1);
        }
        //Plain dark blue block
        public IBlock CreateDarkBlueBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 2);
        }
        //staircase block
        public IBlock CreateStairBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 3);
        }
        //Block with face facing right
        public IBlock CreateRightFacingDragonBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 2);
        }
        //Block with face facing left
        public IBlock CreateLeftFacingDragonBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 3);
        }
    }
}
