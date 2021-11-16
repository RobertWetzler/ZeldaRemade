using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Utilities
{
    class HUDUtilities
    {
        private HUDUtilities() { }

        private static HUDUtilities instance = new HUDUtilities();
        public static HUDUtilities Instance => instance;

        public Vector2 GetPlayerRectLocationSmallHUD(Vector2 topLeftOrigin)
        {
            Room currentRoom = RoomManager.Instance.CurrentRoom;
            Vector2 playerRectPos = Vector2.Zero;
            switch (currentRoom.RoomID)
            {
                case 1:
                    playerRectPos = new Vector2(topLeftOrigin.X + 90, topLeftOrigin.Y + 115);
                    break;
                case 2:
                    playerRectPos = new Vector2(topLeftOrigin.X + 125, topLeftOrigin.Y + 85);
                    break;
                case 3:
                    playerRectPos = new Vector2(topLeftOrigin.X + 125, topLeftOrigin.Y + 115);
                    break;
                case 4:
                    playerRectPos = new Vector2(topLeftOrigin.X + 125, topLeftOrigin.Y + 130);
                    break;
                case 5:
                    playerRectPos = new Vector2(topLeftOrigin.X + 125, topLeftOrigin.Y + 165);
                    break;
                case 6:
                    playerRectPos = new Vector2(topLeftOrigin.X + 160, topLeftOrigin.Y + 85);
                    break;
                case 7:
                    playerRectPos = new Vector2(topLeftOrigin.X + 160, topLeftOrigin.Y + 100);
                    break;
                case 8:
                    playerRectPos = new Vector2(topLeftOrigin.X + 160, topLeftOrigin.Y + 115);
                    break;
                case 9:
                    playerRectPos = new Vector2(topLeftOrigin.X + 155, topLeftOrigin.Y + 130);
                    break;
                case 10:
                    playerRectPos = new Vector2(topLeftOrigin.X + 155, topLeftOrigin.Y + 150);
                    break;
                case 11:
                    playerRectPos = new Vector2(topLeftOrigin.X + 155, topLeftOrigin.Y + 165);
                    break;
                case 12:
                    playerRectPos = new Vector2(topLeftOrigin.X + 185, topLeftOrigin.Y + 115);
                    break;
                case 13:
                    playerRectPos = new Vector2(topLeftOrigin.X + 185, topLeftOrigin.Y + 130);
                    break;
                case 14:
                    playerRectPos = new Vector2(topLeftOrigin.X + 185, topLeftOrigin.Y + 165);
                    break;
                case 15:
                    playerRectPos = new Vector2(topLeftOrigin.X + 220, topLeftOrigin.Y + 100);
                    break;
                case 16:
                    playerRectPos = new Vector2(topLeftOrigin.X + 220, topLeftOrigin.Y + 115);
                    break;
                case 17:
                    playerRectPos = new Vector2(topLeftOrigin.X + 250, topLeftOrigin.Y + 100);
                    break;
                case 18:
                    playerRectPos = new Vector2(topLeftOrigin.X + 125, topLeftOrigin.Y + 85);
                    break;
            }
            return playerRectPos;
        }

        public Vector2 GetTriforceRoomPos(Vector2 topLeftOrigin)
        {           
            return new Vector2(topLeftOrigin.X + 250, topLeftOrigin.Y + 100);
        }
    }
}
