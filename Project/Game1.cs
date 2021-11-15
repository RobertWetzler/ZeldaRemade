using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.GameState;
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
        private List<Room> roomList;
        private GameStateMachine gameStateMachine;
        private CollisionIterator collisionIterator;
        private int roomIdx = 0;
        private List<int> passedRoom;

        public IPlayer Player { get => player; set => player = value; }
        public int RoomIdx { get => roomIdx; set => roomIdx = value; }
        public int RoomNum { get => roomList.Count; }
        public CollisionIterator CollisionIterator { get => collisionIterator; }
        public GameStateMachine GameStateMachine { get => gameStateMachine; }
        public List<int> PassedRoom { get => passedRoom; }

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
            //test
            passedRoom = new List<int>();

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
            TextSpriteFactory.Instance.LoadAllTextures(Content);
            MapTileSpriteFactory.Instance.LoadAllTextures(Content); //Testing

            gameStateMachine = new GameStateMachine(this);
            player = new GreenLink(this);
            for (int i = 1; i <= 18; i++)
            {
                string currentRoom = "Room" + i;
                List<IEnemy> enemies = XMLParser.instance.GetEnemiesFromRoom(currentRoom, player);
                List<INPC> npcs = XMLParser.instance.GetNPCSFromRoom(currentRoom);
                List<IItems> items = XMLParser.instance.GetItemsFromRoom(currentRoom);
                List<IBlock> blocks = XMLParser.instance.GetBlocksFromRoom(currentRoom);
                Room room = new Room(i, XMLParser.instance.GetBackgroundFromRoom(currentRoom),
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
            RoomManager.Instance.SetCurrentRoom(roomList[RoomIdx]);
            passedRoom.Add(roomIdx);
            gameStateMachine.CurrentState.Update(gameTime, _graphics);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameStateMachine.CurrentState.Draw(_spriteBatch, gameTime, _graphics);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
