using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Factory;
using Project.HUD;
using Project.Utilities;

namespace Project.GameState
{
    class ItemSelectionState : IGameState
    {
        private Game1 game;
        private KeyboardController keyboardController;
        private IHUD smallHud, bigHUD;

        public ItemSelectionState(Game1 game)
        {
            this.game = game;
            bigHUD = new BigHUD(game); 

            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.F, new ItemSelectionCommand(this.game));
            keyboardController.RegisterCommand(Keys.Escape, new PlayGameCommand(this.game));
            keyboardController.RegisterCommand(Keys.B, new GetAItemCommand(this.game));
            keyboardController.RegisterCommand(Keys.G, new GetBItemCommand(game));
            smallHud = new SmallHUD(true);
        }
        public void Update(GameTime gameTime, Rectangle gameRect)
        {
            keyboardController.Update();

            bigHUD.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            bigHUD.Draw(spriteBatch);
    
            smallHud.Draw(spriteBatch);
           /*
            * Display orange map
            *
            foreach (var room in game.PassedRoom)
            {
                switch (room)
                {
                    case 1:
                        mapTile1.Draw(spriteBatch, new Vector2(468, 464 + heightOffset), Color.White);
                        break;
                    case 2:
                        mapTile2.Draw(spriteBatch, new Vector2(500, 400 + heightOffset), Color.White);
                        break;
                    case 3:
                        mapTile3.Draw(spriteBatch, new Vector2(500, 464 + heightOffset), Color.White);
                        break;
                    case 4:
                        mapTile4.Draw(spriteBatch, new Vector2(500, 496 + heightOffset), Color.White);
                        break;
                    case 5:
                        mapTile5.Draw(spriteBatch, new Vector2(500, 560 + heightOffset), Color.White);
                        break;
                    case 6:
                        mapTile6.Draw(spriteBatch, new Vector2(532, 400 + heightOffset), Color.White);
                        break;
                    case 7:
                        mapTile7.Draw(spriteBatch, new Vector2(532, 432 + heightOffset), Color.White);
                        break;
                    case 8:
                        mapTile8.Draw(spriteBatch, new Vector2(532, 464 + heightOffset), Color.White);
                        break;
                    case 9:
                        mapTile9.Draw(spriteBatch, new Vector2(532, 496 + heightOffset), Color.White);
                        break;
                    case 10:
                        mapTile10.Draw(spriteBatch, new Vector2(532, 528 + heightOffset), Color.White);
                        break;
                    case 11:
                        mapTile11.Draw(spriteBatch, new Vector2(532, 560 + heightOffset), Color.White);
                        break;
                    case 12:
                        mapTile12.Draw(spriteBatch, new Vector2(564, 464 + heightOffset), Color.White);
                        break;
                    case 13:
                        mapTile13.Draw(spriteBatch, new Vector2(564, 496 + heightOffset), Color.White);
                        break;
                    case 14:
                        mapTile14.Draw(spriteBatch, new Vector2(564, 560 + heightOffset), Color.White);
                        break;
                    case 15:
                        mapTile15.Draw(spriteBatch, new Vector2(596, 432 + heightOffset), Color.White);
                        break;
                    case 16:
                        mapTile16.Draw(spriteBatch, new Vector2(596, 464 + heightOffset), Color.White);
                        break;
                    case 17:
                        mapTile17.Draw(spriteBatch, new Vector2(628, 432 + heightOffset), Color.White);
                        break;
                }
            }
                posDot.Draw(spriteBatch, dotPos, Color.White);*/
        }
    }
}
