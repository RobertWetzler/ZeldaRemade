using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.GameState;
using Project.HUD;
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

        private GameStateMachine gameStateMachine;
        private CollisionIterator collisionIterator;

        private int roomIdx = 0;
        private Rectangle playerBounds; //Bounding window for player/enemy movement


        public IPlayer Player { get => player; set => player = value; }
        public int RoomIdx { get => roomIdx; set => roomIdx = value; }
        public int RoomNum { get => RoomUtilities.IdToRoom.Count; }
        public CollisionIterator CollisionIterator { get => collisionIterator; }
        public GameStateMachine GameStateMachine { get => gameStateMachine; }
        public GraphicsDeviceManager Graphics { get => _graphics; }

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

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 924;
            _graphics.ApplyChanges();
            playerBounds = new Rectangle(playerBoundOffset, playerBoundOffset + heightOffset,
                    _graphics.PreferredBackBufferWidth - 2 * playerBoundOffset, _graphics.PreferredBackBufferHeight - heightOffset - 2 * playerBoundOffset);
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

            gameStateMachine = new GameStateMachine(this);
            player = new GreenLink(this);

            RoomManager.GetRoom(player);

            RoomManager.Instance.SetCurrentRoom(RoomUtilities.IdToRoom[RoomIdx]);
            collisionIterator = new CollisionIterator();
            
        }
            
        protected override void Update(GameTime gameTime)
        {
        
            RoomManager.Instance.SetCurrentRoom(RoomUtilities.IdToRoom[RoomIdx]);
            gameStateMachine.CurrentState.Update(gameTime, _graphics);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameStateMachine.CurrentState.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
