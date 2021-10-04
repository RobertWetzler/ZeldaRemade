using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Entities;
using Project.Factory;
using Project.NPC.Bat;
using Project.NPC.Skeleton;
using Project.NPC.OldMan;
using Project.NPC.Merchant;
using Project.NPC.Trap;
using Project.NPC.BigJelly;
using Project.NPC.Goriya;
using Project.NPC.SmallJelly;
using Project.NPC.Dragon;
using Project.Sprites.BlockSprites;
using Project.Sprites.PlayerSprites;
using Project.Sprites.ItemSprites;
using System;
using System.Collections.Generic;

namespace Project
{
    public class Game1 : Game
    {
        private Facing testFacing = Facing.Down;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }
        private List<IController> controllers;

        //List of sprites to cycle thru
        private List<IItemSprite> items;
        private List<IBlockSprite> blocks;
        private List<IWeaponSprites> weapons;
        private List<INPC> npcsList;

        public int ItemsListLength => items.Count;
        public int BlocksListLength => blocks.Count;
        public int WeaponsListLength => weapons.Count;
        public int NPCSListLength => npcsList.Count;
        public int CurrentBlockSpriteIndex { get; set; }
        public int CurrentItemSpriteIndex { get; set; }
        public int CurrentNPCIndex { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controllers = new List<IController>();

            KeyboardController keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));

            keyboardController.RegisterCommand(Keys.E, new PlayerDamageCommand(this));

            //Register both WASD and Arrows
            ICommand upCommand = new PlayerMoveUpCommand(this);
            keyboardController.RegisterCommand(Keys.W, upCommand);
            keyboardController.RegisterCommand(Keys.Up, upCommand);

            ICommand leftCommand = new PlayerMoveLeftCommand(this);
            keyboardController.RegisterCommand(Keys.A, leftCommand);
            keyboardController.RegisterCommand(Keys.Left, leftCommand);

            ICommand rightCommand = new PlayerMoveRightCommand(this);
            keyboardController.RegisterCommand(Keys.D, rightCommand);
            keyboardController.RegisterCommand(Keys.Right, rightCommand);

            ICommand downCommand = new PlayerMoveDownCommand(this);
            keyboardController.RegisterCommand(Keys.S, downCommand);
            keyboardController.RegisterCommand(Keys.Down, downCommand);

            //Register idle command as default
            keyboardController.RegisterDefaultCommand(new PlayerStopMovingCommand(this));

            //Cycle thru sprites commands
            keyboardController.RegisterCommand(Keys.T, new GetPreviousBlockCommand(this));
            keyboardController.RegisterCommand(Keys.Y, new GetNextBlockCommand(this));
            keyboardController.RegisterCommand(Keys.I, new GetPreviousItemCommand(this));
            keyboardController.RegisterCommand(Keys.U, new GetNextItemCommand(this));
            keyboardController.RegisterCommand(Keys.O, new GetPreviousEnemyCommand(this));
            keyboardController.RegisterCommand(Keys.P, new GetNextEnemyCommand(this));
            controllers.Add(keyboardController);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Link Sprites
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            player = new GreenLink(this); // must be done AFTER LinkSpriteFactory load
            
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

            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            items = new List<IItemSprite>();
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 0));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 1));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 2));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 3));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 4));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 6));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 7));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 8));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 9));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 10));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 0));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 1));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 2));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 3));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 4));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 6));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 7));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 8));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 9));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 10));
            items.Add(ItemSpriteFactory.Instance.CreateFairySprite());
            items.Add(ItemSpriteFactory.Instance.CreateRupeeSprite());
            items.Add(ItemSpriteFactory.Instance.CreateHeartSprite());
            items.Add(ItemSpriteFactory.Instance.CreateTriforceSprite());

            CurrentItemSpriteIndex = 0;
            //TESTING CAN BE DELETED
            weapons = new List<IWeaponSprites>();                                                      
            weapons.Add(ItemSpriteFactory.Instance.CreateBlueArrowSprite(testFacing, player.Position));
            
            //Load NPC sprites
            NPCSpriteFactory.Instance.LoadAllTextures(Content);


            //Set NPC
            npcsList = new List<INPC>();
            npcsList.Add(new Bat());
            npcsList.Add(new Skeleton());
            npcsList.Add(new SmallJelly());
            npcsList.Add(new BigJelly());
            npcsList.Add(new Goriya());
            npcsList.Add(new Trap());
            npcsList.Add(new OldMan());
            npcsList.Add(new Merchant());
            npcsList.Add(new Dragon());
            npcsList.Add(new WallMaster());
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            npcsList[CurrentNPCIndex].Update(gameTime);
            foreach (IWeaponSprites weapon in weapons)
            {
                weapon.Update(gameTime);
            }

            foreach (IItemSprite item in items)
            {
                item.Update(gameTime);
            }

            player.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tan);

            _spriteBatch.Begin(samplerState:SamplerState.PointClamp); // PointClamp fixes sprite blurriness
            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch, new Vector2(200, 100));
            player.Draw(_spriteBatch, gameTime);

            items[CurrentItemSpriteIndex].Draw(_spriteBatch, new Vector2(200, 300));
            npcsList[CurrentNPCIndex].Draw(_spriteBatch);

            //TESTING
            if (weapons[0].isFinished() == false)
            {
                weapons[0].Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
