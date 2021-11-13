using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IPlayer player;
        private List<IController> controllers;
        private List<Room> roomList;
        public CollisionIterator collisionIterator;
        private int roomIdx = 0;
        private TitleScreen titleScreen;
        private bool showTitleScreen;

        public IPlayer Player { get => player; set => player = value; }
        public int RoomIdx { get => roomIdx; set => roomIdx = value; }
        public int RoomNum { get => roomList.Count; }
        public bool ShowTitleScreen { get => showTitleScreen; set => showTitleScreen = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            roomList = new List<Room>();
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();
            showTitleScreen = true;
            controllers = new List<IController>();
            ControllerUtilities.SetKeyboardControllers(controllers, this);
            ControllerUtilities.SetMouseControllers(controllers, this);
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
            SoundFactory.Instance.LoadAllTextures(Content);

            titleScreen = new TitleScreen();
            player = new GreenLink(this);
            for (int i = 1; i <= 18; i++)
            {
                string currentRoom = "Room" + i;
                List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
                List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
                List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
                List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
                Room room = new Room(XMLParser.instance.GetBackgroundFromRoom(currentRoom),
                                items,
                                blocks,
                                npcs,
                                enemies);
                roomList.Add(room);
            }
            RoomManager.Instance.SetCurrentRoom(roomList[RoomIdx]);
            collisionIterator = new CollisionIterator();
        }

        protected override void Update(GameTime gameTime)
        {
            
            foreach (IController controller in controllers)
            {
                controller.Update();
            }

            if (showTitleScreen)
            {
                titleScreen.Update(gameTime);
            }
            else
            {
                collisionIterator.UpdateCollisions(RoomManager.Instance.CurrentRoom.Dynamics.Append(player).ToList(), RoomManager.Instance.CurrentRoom.Statics);
                RoomManager.Instance.SetCurrentRoom(roomList[RoomIdx]);
                RoomManager.Instance.CurrentRoom.Update(new Rectangle(128, 128, _graphics.PreferredBackBufferWidth - 256, _graphics.PreferredBackBufferHeight - 256), gameTime);
                player.Update(new Rectangle(128, 128, _graphics.PreferredBackBufferWidth - 256, _graphics.PreferredBackBufferHeight - 256), gameTime);
            }
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            if (showTitleScreen)
            {
                titleScreen.Draw(_spriteBatch, _graphics);
            }
            else
            {
                RoomManager.Instance.CurrentRoom.Draw(_spriteBatch, gameTime, _graphics);
                player.Draw(_spriteBatch, gameTime);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
