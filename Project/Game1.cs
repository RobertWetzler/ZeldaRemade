using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Utilities;
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

        private List<IItems> items;
        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<INPC> npcs;
        public CollisionIterator collisionIterator;
        private Room room;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();
            controllers = new List<IController>();
            Sprint2Utilities.SetKeyboardControllers(controllers, this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            NPCSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            player = new GreenLink(this);
            enemies = XMLParser.instance.GetEnemiesFromRoom("Room15");
            npcs = XMLParser.instance.GetNPCSFromRoom("Room15");
            items = XMLParser.instance.GetItemsFromRoom("Room15");
            blocks = XMLParser.instance.GetBlocksFromRoom("Room15");
            room = new Room(XMLParser.instance.GetBackgroundFromRoom("Room15"),
                                items,
                                blocks,
                                npcs,
                                enemies);
            List<ICollidable> dynamics = new List<ICollidable>(enemies);
            dynamics.Add(player);
            collisionIterator = new CollisionIterator(dynamics, new List<ICollidable>(blocks));       
        }

        protected override void Update(GameTime gameTime)
        {
            collisionIterator.UpdateCollisions();
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            room.Update(new Rectangle(128, 128, _graphics.PreferredBackBufferWidth - 256, _graphics.PreferredBackBufferHeight - 256), gameTime);
            player.Update(new Rectangle(128, 128, _graphics.PreferredBackBufferWidth - 256, _graphics.PreferredBackBufferHeight - 256), gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            room.Draw(_spriteBatch, gameTime, _graphics);
            player.Draw(_spriteBatch, gameTime);
           _spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
