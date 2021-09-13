using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Project
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> commandMapping;
        public KeyboardController()
        {
            commandMapping = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            commandMapping.Add(key, command);
        }
        public void Update()
        {
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in keys)
            {
                ICommand command;
                if (commandMapping.TryGetValue(key, out command))
                {

                    command.Execute();
                }
            }
        }
    }
}
