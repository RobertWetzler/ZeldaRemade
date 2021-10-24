using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Sprites.BlockSprites;
using Project.Sprites.ItemSprites;
using Project.Utilities;
using System;
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
        private List<IItems> items;
        private List<IBlock> blocks;
        private List<INPC> npcsList;

        private List<IEnemy> enemies;
        private List<INPC> npcs;
        private IEnemy enemy;
        public CollisionIterator collisionIterator;

        public int ItemsListLength => items.Count;
        public int BlocksListLength => blocks.Count;
        public int NPCSListLength => npcsList.Count;
        public int CurrentBlockSpriteIndex { get; set; }
        public int CurrentItemIndex { get; set; }
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

            //Load Enemy sprites
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            //Set List for blocks, items, and NPCs
            blocks = new List<IBlock>();
            Utilities.Sprint2Utilities.SetBlockList(blocks);
            CurrentBlockSpriteIndex = 0;


            CurrentItemIndex = 0;

            npcsList = new List<INPC>();
            Utilities.Sprint2Utilities.SetNPCList(npcsList);
            CurrentNPCIndex = 0;
            enemy = new Goriya(new Vector2(400, 100));
            collisionIterator = new CollisionIterator(new List<ICollidable> { player, enemy }, new List<ICollidable>(blocks));


            enemies = XMLParser.instance.GetEnemiesFromRoom("Room3");
            npcs = XMLParser.instance.GetNPCSFromRoom("Room1");
            items = XMLParser.instance.GetItemsFromRoom("Room5");
        }

        protected override void Update(GameTime gameTime)
        {
            collisionIterator.UpdateCollisions();
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            foreach (IEnemy n in enemies)
            {
                n.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            }
            foreach (INPC n in npcs)
            {
                n.Update(gameTime);
            }
            foreach (var i in items)
            {
                i.Update(gameTime);
            }
            enemy.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            npcsList[CurrentNPCIndex].Update(gameTime);
  


            player.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tan);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp); // PointClamp fixes sprite blurriness
            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch);
            player.Draw(_spriteBatch, gameTime);

            npcsList[CurrentNPCIndex].Draw(_spriteBatch);
      
            foreach (IEnemy n in enemies)
            {
                n.Draw(_spriteBatch, gameTime);
            }
            foreach (INPC n in npcs)
            {
                n.Draw(_spriteBatch);
            }
            foreach (var i in items)
            {
                i.Draw(_spriteBatch);
            }
            enemy.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
