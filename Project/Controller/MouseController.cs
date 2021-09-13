using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Project
{
    enum Quadrant
    {
        UpperLeft,
        UpperRight,
        LowerLeft,
        LowerRight,
        All
    }
    enum Button
    {
        LeftButton,
        RightButton
    }
    class ButtonPosition
    {
        public Button button { get; set; }
        public Quadrant quadrant { get; set; }
        public ButtonPosition(Button button, Quadrant quadrant)
        {
            this.button = button;
            this.quadrant = quadrant;
        }
    }
    // Custom equality comparer so ButtonPosition can be used as a dictionary key
    class ButtonPositionComparer : IEqualityComparer<ButtonPosition>
    {
        public bool Equals(ButtonPosition x, ButtonPosition y)
        {
            return x.button == y.button && x.quadrant == y.quadrant; 
        }
        public int GetHashCode(ButtonPosition x)
        {
            return x.button.GetHashCode() + x.quadrant.GetHashCode();
        }
    }
    class MouseController : IController
    {
        private Dictionary<ButtonPosition, ICommand> commandMapping;
        private Rectangle windowBounds;
        public MouseController(Rectangle windowBounds)
        {
            commandMapping = new Dictionary<ButtonPosition, ICommand>(new ButtonPositionComparer());
            this.windowBounds = windowBounds;
        }
        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Quadrant quadrant = PositionToQuadrant(mouseState.X, mouseState.Y);
                ExecuteButtonCommand(new ButtonPosition(Button.LeftButton, quadrant));
            }
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                Quadrant quadrant = PositionToQuadrant(mouseState.X, mouseState.Y);
                ExecuteButtonCommand(new ButtonPosition(Button.RightButton, quadrant));
            }

        }
        public void ExecuteButtonCommand(ButtonPosition buttonPosition)
        {

            ICommand command;
            if (commandMapping.TryGetValue(buttonPosition, out command))
            {
                command.Execute();
            }
            // If command not found for specific quadrant, see if a command is registered for entire screen
            else if (commandMapping.TryGetValue(new ButtonPosition(buttonPosition.button, Quadrant.All), out command))
            {
                command.Execute();
            }
        }
        public void RegisterCommand(ButtonPosition buttonPosition, ICommand command)
        {
            commandMapping.Add(buttonPosition, command);
        }

        private Quadrant PositionToQuadrant(int x, int y)
        {
            Quadrant quadrant;
            if (x < windowBounds.Width / 2)
            {
                if (y < windowBounds.Height / 2)
                {
                    quadrant = Quadrant.UpperLeft;
                }
                else
                {
                    quadrant = Quadrant.LowerLeft;
                }
            }
            else if (y < windowBounds.Height / 2)
            {
                quadrant = Quadrant.UpperRight;
            }
            else
            {
                quadrant = Quadrant.LowerRight;
            }
            return quadrant;
        }
    }
}
