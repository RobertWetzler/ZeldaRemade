using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.GameState;
using Project.Rooms;
using Project.Sound;
using Project.Utilities;
using System.Collections.Generic;


namespace Project
{
    public class Game1 : Game
    {
        public bool DEBUG = true;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IPlayer player;
        private List<Room> roomList;
        private GameStateMachine gameStateMachine;
        private CollisionIterator collisionIterator;
        private int roomIdx = 0;
        private Rectangle playerBounds; //Bounding window for player/enemy movement
        private List<int> passedRoom;

        public Rectangle PlayerBounds => playerBounds;

        public int ItemIdx = 0;

        public ItemType getItem;
        public IPlayer Player { get => player; set => player = value; }
        public int RoomIdx { get => roomIdx; set => roomIdx = value; }
        public int RoomNum { get => RoomManager.IdToRoom.Count; }
        public CollisionIterator CollisionIterator { get => collisionIterator; }
        public GameStateMachine GameStateMachine { get => gameStateMachine; }
        public GraphicsDeviceManager Graphics { get => _graphics; }

        private static Game1 instance = new Game1();
        public static Game1 Instance => instance;
        public List<int> PassedRoom { get => passedRoom; set => passedRoom = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            const int heightOffset = 224;
            const int playerBoundOffset = 128;
            roomList = new List<Room>();
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 924;
            _graphics.ApplyChanges();
            playerBounds = new Rectangle(playerBoundOffset, playerBoundOffset + heightOffset,
                    _graphics.PreferredBackBufferWidth - 2 * playerBoundOffset, _graphics.PreferredBackBufferHeight - heightOffset - 2 * playerBoundOffset);
            passedRoom = new List<int>();

            PauseController.RegisterPause();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            HUDSpriteFactory.Instance.LoadAllTextures(Content, GraphicsDevice);
            BackgroundSpriteFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            NPCSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            TextSpriteFactory.Instance.LoadAllTextures(Content);
            SoundManager.Instance.LoadAllSounds(Content);
            HUDSpriteFactory.Instance.LoadAllTextures(Content, _graphics.GraphicsDevice);
            DoorSpriteFactory.Instance.LoadAllTextures(Content);
            MapTileSpriteFactory.Instance.LoadAllTextures(Content); 
            ItemSelectionUtilities.LoadAllEquipableItems();

            gameStateMachine = new GameStateMachine(this);
            player = new GreenLink(this);

            RoomManager.LoadAllRooms(player, _graphics);

            RoomManager.Instance.SetCurrentRoom(RoomManager.IdToRoom[11]);
            collisionIterator = new CollisionIterator();

        }

        protected override void Update(GameTime gameTime)
        {
            passedRoom.Add(RoomManager.Instance.CurrentRoom.RoomID);
            gameStateMachine.CurrentState.Update(gameTime, playerBounds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            gameStateMachine.CurrentState.Draw(_spriteBatch, gameTime);
            base.Draw(gameTime);
        }
    }
}
