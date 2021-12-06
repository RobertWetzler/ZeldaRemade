using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Commands
{
    class ToggleShaderCommand : ICommand
    {
        public void Execute()
        {
            GameOptions.IsShaderOn = !GameOptions.IsShaderOn;
        }
    }
}
