using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Blocks;
using Project.Blocks.MovableBlock;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    public class Game1 : Game
    {
        private SpriteFont font;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }
        private List<IController> controllers;

        public CollisionIterator collisionIterator;

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
            FontFactory.Instance.LoadContent(Content);

            player = new GreenLink(this);
            string currentRoom = "Room1";
            List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom);
            List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
            List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
            List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
            Room room = new Room(XMLParser.instance.GetBackgroundFromRoom(currentRoom),
                                items,
                                blocks,
                                npcs,
                                enemies);
            RoomManager.Instance.SetCurrentRoom(room);
            collisionIterator = new CollisionIterator();       
        }

        protected override void Update(GameTime gameTime)
        {
            collisionIterator.UpdateCollisions(RoomManager.Instance.CurrentRoom.Dynamics.Append(player).ToList(), RoomManager.Instance.CurrentRoom.Statics);
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            RoomManager.Instance.CurrentRoom.Update(new Rectangle(128, 128, _graphics.PreferredBackBufferWidth - 256, _graphics.PreferredBackBufferHeight - 256), gameTime);
            player.Update(new Rectangle(128, 128, _graphics.PreferredBackBufferWidth - 256, _graphics.PreferredBackBufferHeight - 256), gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            RoomManager.Instance.CurrentRoom.Draw(_spriteBatch, gameTime, _graphics);
            player.Draw(_spriteBatch, gameTime);
           _spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
