using Project.Sprites.ItemSprites;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class PlayerUseFlameCommand : ICommand
    {
        private Game1 game;

        public PlayerUseFlameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            this.game.Player.UseWeapon(WeaponTypes.Flame);
        }
    }
}
