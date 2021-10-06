using Project.Entities;

namespace Project
{
    class PlayerUseArrowCommand : ICommand
    {
        private Game1 game;

        public PlayerUseArrowCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseWeapon(WeaponTypes.Arrow);
        }
    }
}
