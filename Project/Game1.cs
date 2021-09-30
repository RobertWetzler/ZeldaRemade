using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Factory;
using Project.Sprites.BlockSprites;
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
            items.Add(ItemSpriteFactory.Instance.CreateFairySprite());
            items.Add(ItemSpriteFactory.Instance.CreateBombSprite());
            items.Add(ItemSpriteFactory.Instance.CreateArrowSprite());      
            items.Add(ItemSpriteFactory.Instance.CreateRupeesSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBlueRupeesSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBoomerangSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBlueCandleSprite());
            items.Add(ItemSpriteFactory.Instance.CreateCandleSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBlueRingSprite());
            items.Add(ItemSpriteFactory.Instance.CreateRingSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBlueSwordSprite());
            items.Add(ItemSpriteFactory.Instance.CreateSwordSprite());      
            items.Add(ItemSpriteFactory.Instance.CreateTriforceSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBottleSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBlueBottleSprite());
            items.Add(ItemSpriteFactory.Instance.CreateClockSprite());
            items.Add(ItemSpriteFactory.Instance.CreateHealthSprite());
            items.Add(ItemSpriteFactory.Instance.CreateHeartContSprite());
            items.Add(ItemSpriteFactory.Instance.CreateCompassSprite());
            items.Add(ItemSpriteFactory.Instance.CreateBowSprite());
            items.Add(ItemSpriteFactory.Instance.CreateMapSprite());
            items.Add(ItemSpriteFactory.Instance.CreateHeartSprite());
            items.Add(ItemSpriteFactory.Instance.CreateFluteSprite());
            items.Add(ItemSpriteFactory.Instance.CreateKeySprite());

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

            foreach (IItemSprite item in items)
            {
                item.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState:SamplerState.PointClamp); // PointClamp fixes sprite blurriness

            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch, new Vector2(200, 100));
            items[CurrentItemSpriteIndex].Draw(_spriteBatch, new Vector2(400, 100));

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
