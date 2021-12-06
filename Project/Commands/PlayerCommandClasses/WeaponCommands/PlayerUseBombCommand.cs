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
            if (this.game.Player.Inventory.GetItemCount(ItemType.Bomb) > 0)
            {
                this.game.Player.UseWeapon(WeaponTypes.Bomb);
            }
        }
    }
}
