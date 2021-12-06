using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Sound;
using Project.Utilities;

namespace Project.GameState
{
    public class TitleScreenState : IGameState
    {
        private TitleScreen titleScreen;
        private KeyboardController keyboardController;
        private const int START_HEALTH = 6;  //test

        public TitleScreenState(Game1 game)
        {
            SoundManager.Instance.CreateTitleSound();
            this.titleScreen = new TitleScreen(game.Graphics);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Enter, new PlayGameCommand(game));
            /*
            game.Player.Health.MaxHealth = START_HEALTH;
            game.Player.Inventory.RemoveNItems(ItemType.HeartContainer, game.Player.Inventory.GetItemCount(ItemType.HeartContainer));
            game.Player.Inventory.AddNItems(ItemType.HeartContainer, START_HEALTH / 2);
            game.Player.Health.CurrentHealth = game.Player.Health.MaxHealth;
            game.Player.Inventory.RemoveNItems(ItemType.Heart, game.Player.Inventory.GetItemCount(ItemType.Heart));
            game.Player.Inventory.AddNItems(ItemType.Heart, game.Player.Health.CurrentHealth);*/

            RoomManager.LoadAllRooms(game.Player, Game1.Instance.Graphics);
            RoomManager.Instance.SetCurrentRoom(RoomManager.GetRoom(11));
        }
        public void Update(GameTime gameTime, Rectangle playerBounds)
        {
            keyboardController.Update();
            titleScreen.Update(gameTime);


        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            titleScreen.Draw(spriteBatch);
            spriteBatch.End();
        }


    }
}
