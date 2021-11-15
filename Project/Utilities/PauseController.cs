using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Project.Commands;

namespace Project.Utilities
{
    public static class PauseController
    {
        public static KeyboardController controller = new KeyboardController();

        public static void RegisterPause()
        {
            controller.RegisterCommand(Keys.Escape, new TogglePauseGameCommand());
        }
    }
}
