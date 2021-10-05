using Project.Entities;

namespace Project
{
    class PlayerUseBoomerangCommand : ICommand
    {
        private Game1 game;

        public PlayerUseBoomerangCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseWeapon(WeaponTypes.Boomerang);
        }
    }
}
