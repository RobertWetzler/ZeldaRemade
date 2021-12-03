using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Utilities;

namespace Project.HUD
{
    class PositionDot
    {
        private ISprite posDot;
        private Vector2 dotPos;

        public PositionDot()
        {
            posDot = HUDSpriteFactory.Instance.CreateWhiteSquare();
            dotPos = new Vector2(544, 569);
        }


        public void Update()
        {
            switch (RoomManager.Instance.CurrentRoom.RoomID)
            {
                case 1:
                    dotPos = dotPos = new Vector2(482, 472);
                    break;
                case 2:
                    dotPos = new Vector2(513, 408);
                    break;
                case 3:
                    dotPos = new Vector2(513, 472);
                    break;
                case 4:
                    dotPos = new Vector2(513, 504);
                    break;
                case 5:
                    dotPos = new Vector2(513, 569);
                    break;
                case 6:
                    dotPos = new Vector2(544, 408);
                    break;
                case 7:
                    dotPos = new Vector2(544, 441);
                    break;
                case 8:
                    dotPos = new Vector2(544, 472);
                    break;
                case 9:
                    dotPos = new Vector2(544, 504);
                    break;
                case 10:
                    dotPos = new Vector2(544, 536);
                    break;
                case 11:
                    dotPos = new Vector2(544, 569);
                    break;
                case 12:
                    dotPos = new Vector2(575, 472);
                    break;
                case 13:
                    dotPos = new Vector2(575, 504);
                    break;
                case 14:
                    dotPos = new Vector2(575, 569);
                    break;
                case 15:
                    dotPos = new Vector2(606, 441);
                    break;
                case 16:
                    dotPos = new Vector2(606, 472);
                    break;
                case 17:
                    dotPos = new Vector2(640, 441);
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            posDot.Draw(spriteBatch, dotPos, Color.White);
        }
    }
}
