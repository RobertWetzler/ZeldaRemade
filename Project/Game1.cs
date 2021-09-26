using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Factory;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;

namespace Project
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISprite sprite;
        private Texture2D texture_atlas;
        private List<IController> controllers;
        private TextSprite text;

        //List of blocks to cycle thru
        private List<IBlockSprite> blocks;
        public int CurrentBlockSpriteIndex { get; set; }

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
            this.sprite.texture = texture_atlas;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            sprite = new FixedNonAnimatedSprite();
            text = new TextSprite();
            controllers = new List<IController>();

            KeyboardController keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.T, new GetPreviousBlockCommand(this));
            keyboardController.RegisterCommand(Keys.Y, new GetNextBlockCommand(this));
            controllers.Add(keyboardController);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            texture_atlas = Content.Load<Texture2D>("mario");
            sprite.texture = texture_atlas;
            text.font = Content.Load<SpriteFont>("Caption");

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

            //Set initial block sprite to show
            CurrentBlockSpriteIndex = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            sprite.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch, new Vector2(200, 100));

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
