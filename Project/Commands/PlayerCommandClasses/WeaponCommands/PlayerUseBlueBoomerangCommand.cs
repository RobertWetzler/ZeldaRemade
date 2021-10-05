using Project.Entities;

namespace Project
{
    class PlayerUseBlueBoomerangCommand : ICommand
    {
        private Game1 game;

        public PlayerUseBlueBoomerangCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseWeapon(WeaponTypes.BlueBoomerang);
        }
    }
}
