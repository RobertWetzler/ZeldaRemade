using Project.Entities;
namespace Project
{
    class PlayerUseSwordCommand : ICommand
    {
        private Game1 game;

        public PlayerUseSwordCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseWeapon(WeaponTypes.Sword);

        }
    }
}
