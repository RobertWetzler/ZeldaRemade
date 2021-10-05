using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Project
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> commandMapping;
        private KeyboardState oldState;
        private ICommand defaultCommand;
        public KeyboardController()
        {
            commandMapping = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            commandMapping.Add(key, command);
        }

        public void RegisterDefaultCommand(ICommand command)
        {
            defaultCommand = command;
        }

        public void Update()
        {
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            KeyboardState newState = Keyboard.GetState();
            foreach (Keys key in keys)
            {
                if (oldState.IsKeyUp(key) && newState.IsKeyDown(key) && commandMapping.ContainsKey(key))
                {
                    commandMapping[key].Execute();
                }
            }
            if (newState.GetPressedKeyCount() == 0)
            {
                defaultCommand.Execute();
            }
            oldState = newState;
        }
    }
}
