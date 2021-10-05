using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Sprites.BlockSprites;
using Project.Sprites.ItemSprites;
using System.Collections.Generic;

namespace Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }
        private List<IController> controllers;

        //List of sprites to cycle thru
        private List<IItemSprite> items;
        private List<IBlockSprite> blocks;
        private List<INPC> npcsList;

        public int ItemsListLength => items.Count;
        public int BlocksListLength => blocks.Count;
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
            controllers = new List<IController>();
            Utilities.Sprint2Utilities.SetKeyboardControllers(controllers, this);

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

            //Load item sprites
            ItemSpriteFactory.Instance.LoadAllTextures(Content);

            //Load NPC sprites
            NPCSpriteFactory.Instance.LoadAllTextures(Content);

            //Set List for blocks, items, and NPCs
            blocks = new List<IBlockSprite>();
            Utilities.Sprint2Utilities.SetBlockList(blocks);
            CurrentBlockSpriteIndex = 0;

            items = new List<IItemSprite>();
            Utilities.Sprint2Utilities.SetItemList(items);
            CurrentItemSpriteIndex = 0;

            npcsList = new List<INPC>();
            Utilities.Sprint2Utilities.SetNPCList(npcsList);
            CurrentNPCIndex = 0;
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (IController controller in controllers)
            {
                controller.Update();
            }

            npcsList[CurrentNPCIndex].Update(gameTime);

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

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
