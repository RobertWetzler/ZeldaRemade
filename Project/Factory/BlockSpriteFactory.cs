using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.BlockSprites;

namespace Project.Factory
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;
        private Texture2D rectangle1SpriteSheet;
        private Texture2D rectangle2SpriteSheet;


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
            rectangle1SpriteSheet = content.Load<Texture2D>("Blocks/Rectangle1");
            rectangle2SpriteSheet = content.Load<Texture2D>("Blocks/Rectangle2");
        }

        //Plain green block
        public ISprite CreatePlainBlockSprite()
        {
            //Parameters - Texture2D for spritesheet, number of rows in spritesheet, number of columns in spritesheet
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 0);
        }

        //Plain black block
        public ISprite CreateBlackBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 0);
        }
        //White brick block
        public ISprite CreateBrickBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 2, 0);
        }

        //Horizontal layered white block
        public ISprite CreateLayeredBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 2, 1);
        }

        //Green block with little dots
        public ISprite CreateDottedBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 1);
        }
        //Block with square with 4 diagonals
        public ISprite CreatePyramidBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 1);
        }
        //Plain dark blue block
        public ISprite CreateDarkBlueBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 2);
        }
        //staircase block
        public ISprite CreateStairBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 1, 3);
        }
        //Block with face facing right
        public ISprite CreateRightFacingDragonBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 2);
        }
        //Block with face facing left
        public ISprite CreateLeftFacingDragonBlockSprite()
        {
            return new BlockSprite(blockSpriteSheet, 3, 4, 0, 3);
        }

        public ISprite CreateRectangle1Sprite()
        {
            return new Rectangle1Sprite(rectangle1SpriteSheet);
        }

        public ISprite CreateRectangle2Sprite()
        {
            return new Rectangle2Sprite(rectangle2SpriteSheet);
        }
    }
}
