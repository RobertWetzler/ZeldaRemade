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
        private INPC NPC;

        private List<IItemSprite> items;        //List of items to cycle thru
        private List<IBlockSprite> blocks;      //List of blocks to cycle thru
        private List<IWeaponSprites> weapons;  

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
            // TODO: Add your initialization logic here
            controllers = new List<IController>();
            Utilities.Sprint2Utilities.GetControllers(controllers, this);

            /*NPC = new Bat();
            NPC = new Skeleton();
            NPC = new OldMan();
            NPC = new Merchant();
            NPC = new Trap();*/


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
            Utilities.Sprint2Utilities.SetBlockList(blocks);

            //Load item sprites
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            items = new List<IItemSprite>();
            Utilities.Sprint2Utilities.SetItemList(items);


            //TESTING CAN BE DELETED
            weapons = new List<IWeaponSprites>();                                                      
            weapons.Add(ItemSpriteFactory.Instance.CreateBlueArrowSprite(testFacing, player.Position));
           

            //Set initial block sprite to show
            CurrentBlockSpriteIndex = 0;

            //Load NPC sprites
            NPCSpriteFactory.Instance.LoadAllTextures(Content);
            //Set NPC
            NPC = new Goriya();
            CurrentItemSpriteIndex = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            NPC.Update(gameTime);
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            NPC.Update(gameTime);
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

            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch, new Vector2(200, 100));
             //Test link sprite - can be eliminated
            
            items[CurrentItemSpriteIndex].Draw(_spriteBatch, new Vector2(200, 300));
            NPC.Draw(_spriteBatch);

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
