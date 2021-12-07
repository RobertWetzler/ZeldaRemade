using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
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
            smallHud = new SmallHUD(true);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Right, new ItemSelectionCommandCycleRight(this.game));
            keyboardController.RegisterCommand(Keys.Left, new ItemSelectionCommandCycleLeft(this.game));
            keyboardController.RegisterCommand(Keys.D, new ItemSelectionCommandCycleRight(this.game));
            keyboardController.RegisterCommand(Keys.A, new ItemSelectionCommandCycleLeft(this.game));
            keyboardController.RegisterCommand(Keys.Escape, new PlayGameCommand());
            keyboardController.RegisterCommand(Keys.Enter, new GetBItemCommand(this.game));
        }
        public void Update(GameTime gameTime, Rectangle gameRect)
        {
           
            keyboardController.Update();
            smallHud.Update(gameTime);
            bigHUD.Update(gameTime);
            ItemSelectionUtilities.UpdateAllInventoryItems();
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            bigHUD.Draw(spriteBatch);   
            smallHud.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
