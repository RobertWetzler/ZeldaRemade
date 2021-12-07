using Project.Utilities;

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
