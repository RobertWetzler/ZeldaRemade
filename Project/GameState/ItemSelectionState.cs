using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.HUD;

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
            smallHud = new SmallHUD(true);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.F, new ItemSelectionCommand(this.game));
            keyboardController.RegisterCommand(Keys.Escape, new PlayGameCommand(this.game));
            keyboardController.RegisterCommand(Keys.B, new GetAItemCommand(this.game));
            keyboardController.RegisterCommand(Keys.G, new GetBItemCommand(game));
        }
        public void Update(GameTime gameTime, Rectangle gameRect)
        {
            keyboardController.Update();
            smallHud.Update(gameTime);
            bigHUD.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            bigHUD.Draw(spriteBatch);
            smallHud.Draw(spriteBatch);
        }
    }
}
