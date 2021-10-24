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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            controllers = new List<IController>();
            Sprint2Utilities.SetKeyboardControllers(controllers, this);

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

            enemies = XMLParser.instance.GetEnemiesFromRoom("Room14");
            npcs = XMLParser.instance.GetNPCSFromRoom("Room1");
            items = XMLParser.instance.GetItemsFromRoom("Room5");
            blocks = XMLParser.instance.GetBlocksFromRoom("Room1");
 
            List<ICollidable> dynamics = new List<ICollidable>(enemies);
            dynamics.Insert(0, player);
            collisionIterator = new CollisionIterator(dynamics, new List<ICollidable>(blocks));
         
        }

        protected override void Update(GameTime gameTime)
        {
            collisionIterator.UpdateCollisions();
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            foreach (var i in blocks)
            {
                i.Update(gameTime);
            }
            foreach (var i in items)
            {
                i.Update(gameTime);
            }
            foreach (IEnemy n in enemies)
            {
                n.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            }
            foreach (INPC n in npcs)
            {
                n.Update(gameTime);
            }

            player.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tan);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var i in blocks)
            {
                i.Draw(_spriteBatch);
            }
            foreach (var i in items)
            {
                i.Draw(_spriteBatch);
            }
            foreach (IEnemy n in enemies)
            {
                n.Draw(_spriteBatch, gameTime);
            }
            foreach (INPC n in npcs)
            {
                n.Draw(_spriteBatch);
            }
            player.Draw(_spriteBatch, gameTime);

           _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
