using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Project
{ 
    class MouseController : IController
    {
        private MouseState oldMouseState;
        public MouseController()
        { 

        }
    

        public void Update()
        {
            MouseState currentMouseState = Mouse.GetState();
            if(currentMouseState.X<50&&currentMouseState)
        }

    }
}
