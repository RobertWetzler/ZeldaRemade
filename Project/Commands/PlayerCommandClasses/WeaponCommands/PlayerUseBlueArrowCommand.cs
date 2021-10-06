using Project.Entities;

namespace Project
{
    class PlayerUseBlueArrowCommand : ICommand
    {
        private Game1 game;

        public PlayerUseBlueArrowCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseWeapon(WeaponTypes.BlueArrow);
        }
    }
}
