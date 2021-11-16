using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.HUD;
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
        private IHUD smallHud;

        public PlayingState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>();
            controllers.Add(ControllerUtilities.GetKeyboardController(this.game));
            controllers.Add(ControllerUtilities.GetMouseController(this.game));
            smallHud = new SmallHUD(game.Player);
        }
        public void Update(GameTime gameTime, Rectangle bounds)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            game.CollisionIterator.UpdateCollisions(RoomManager.Instance.CurrentRoom.Dynamics.Append(game.Player).ToList(), RoomManager.Instance.CurrentRoom.Statics);

            RoomManager.Instance.CurrentRoom.Update(game.PlayerBounds, gameTime);
            smallHud.Update();
            game.Player.Update(game.PlayerBounds, gameTime);

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
            game.Player.Draw(spriteBatch, gameTime);
        }

        
    }
}
