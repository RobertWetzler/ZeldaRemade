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
        private KeyboardState oldState;
        private ICommand defaultCommand = null;
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
            //Only execute 't' and 'y' command on first key press
            if (oldState.IsKeyUp(Keys.T) && newState.IsKeyDown(Keys.T))
            {
                commandMapping[Keys.T].Execute();
            }
            else if (oldState.IsKeyUp(Keys.Y) && newState.IsKeyDown(Keys.Y))
            {
                commandMapping[Keys.Y].Execute();
            }
            oldState = newState;


            //default command logic
            if (keys.Length == 0 && defaultCommand != null)
            {
                defaultCommand.Execute();
            }
            foreach (Keys key in keys)
            {
                ICommand command;
                if (commandMapping.TryGetValue(key, out command))
                {
                    switch (key)
                    {
                        case Keys.T:
                        case Keys.Y:
                            continue;
                        default:
                            command.Execute();
                            break;
                    }
                }
            }
        }
    }
}
