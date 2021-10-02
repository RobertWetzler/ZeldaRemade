using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Factory;
using Project.Sprites.BlockSprites;
using Project.Sprites.PlayerSprites;
using Project.Sprites.ItemSprites;
using System;
using System.Collections.Generic;

namespace Project
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllers;

        private List<IItemSprite> items;
        //List of blocks to cycle thru
        private List<IBlockSprite> blocks;
        
        private IPlayerSprite link;     //Test link sprite - can be eliminated
        public int CurrentBlockSpriteIndex { get; set; }
        public int CurrentItemSpriteIndex { get; set; }

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            controllers = new List<IController>();

            KeyboardController keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.T, new GetPreviousBlockCommand(this));
            keyboardController.RegisterCommand(Keys.Y, new GetNextBlockCommand(this));
            keyboardController.RegisterCommand(Keys.I, new GetPreviousItemCommand(this));
            keyboardController.RegisterCommand(Keys.U, new GetNextItemCommand(this));
            controllers.Add(keyboardController);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Link Sprites
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            link = LinkSpriteFactory.Instance.CreateLinkUseSwordSidewaysSprite(false);//Test link sprite - can be eliminated

            //Load block sprites
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            blocks = new List<IBlockSprite>();
            blocks.Add(BlockSpriteFactory.Instance.CreatePlainBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreatePyramidBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateRightFacingDragonBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateLeftFacingDragonBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBlackBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateDottedBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateDarkBlueBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateStairBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBrickBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateLayeredBlockSprite());

            
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            items = new List<IItemSprite>();
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 0));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 3));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 4));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 7));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 8));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 9));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 1));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 2));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 6));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 7));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 9));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(2, 3));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(2, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(2, 6));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(2, 9));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 1));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 2));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 3));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 4));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 7));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 8));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(3, 9));

            //Set initial block sprite to show
            CurrentBlockSpriteIndex = 0;
            CurrentItemSpriteIndex = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }

            link.Update(gameTime);  //Test link sprite - can be eliminated

            foreach (IItemSprite item in items)
            {
                item.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tan);

            _spriteBatch.Begin(samplerState:SamplerState.PointClamp); // PointClamp fixes sprite blurriness

            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch, new Vector2(200, 100));
            link.Draw(_spriteBatch, new Vector2(200, 200));     //Test link sprite - can be eliminated
            items[CurrentItemSpriteIndex].Draw(_spriteBatch, new Vector2(400, 100));

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
