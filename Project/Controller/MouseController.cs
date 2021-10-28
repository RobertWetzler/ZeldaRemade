using Microsoft.Xna.Framework.Input;


namespace Project
{
    class MouseController : IController
    {
        private MouseState oldMouseState = Mouse.GetState();
        private GetNextRoomCommand nextRoomCommand;
        private GetPreviousRoomCommand previousRoomCommand;

        public MouseController(Game1 game)
        {
            nextRoomCommand = new GetNextRoomCommand(game);
            previousRoomCommand = new GetPreviousRoomCommand(game);
        }


        public void Update()
        {
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState.X > 900 && currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                nextRoomCommand.Execute();
            }
            else if (currentMouseState.X < 124 && currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                previousRoomCommand.Execute();
            }
            oldMouseState = currentMouseState;
        }

    }
}
