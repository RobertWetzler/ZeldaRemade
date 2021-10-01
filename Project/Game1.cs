using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Factory;
using Project.NPC.Bat;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;

namespace Project
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllers;
        private INPC NPC;

        //List of blocks to cycle thru
        private List<IBlockSprite> blocks;
        public int CurrentBlockSpriteIndex { get; set; }

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
            controllers.Add(keyboardController);

            NPC = new Bat();
            NPC = new Skeleton();


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

            //Load NPC sprites
            NPCSpriteFactory.Instance.LoadAllTextures(Content);

            //Set initial block sprite to show
            CurrentBlockSpriteIndex = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            NPC.Update();
            foreach (IController controller in controllers)
            {
                controller.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState:SamplerState.PointClamp); // PointClamp fixes sprite blurriness

            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch, new Vector2(200, 100));

            NPC.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
