using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.GameState
{
    class PlayingState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;
        public PlayingState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>();
            controllers.Add(ControllerUtilities.GetKeyboardController(this.game));
            controllers.Add(ControllerUtilities.GetMouseController(this.game));
            SoundManager.Instance.CreateBackgroundMusic();
        }
        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            game.CollisionIterator.UpdateCollisions(RoomManager.Instance.CurrentRoom.Dynamics.Append(game.Player).ToList(), RoomManager.Instance.CurrentRoom.Statics);
            RoomManager.Instance.CurrentRoom.Update(new Rectangle(128, 128, graphics.PreferredBackBufferWidth - 256, graphics.PreferredBackBufferHeight - 256), gameTime);
            game.Player.Update(new Rectangle(128, 128, graphics.PreferredBackBufferWidth - 256, graphics.PreferredBackBufferHeight - 256), gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime, graphics);
            game.Player.Draw(spriteBatch, gameTime);
        }

        
    }
}
