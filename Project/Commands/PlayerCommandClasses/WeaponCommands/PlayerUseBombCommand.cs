using Project.Entities;

namespace Project
{
    class PlayerUseBombCommand : ICommand
    {
        private Game1 game;

        public PlayerUseBombCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseWeapon(WeaponTypes.Bomb);
        }
    }
}
