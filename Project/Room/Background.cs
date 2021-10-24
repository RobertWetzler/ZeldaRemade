using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Background
    {
        private BackgroundSprite backgroundSprite;
        public Background(string room)
        {
            switch (room)
            {
                case "Room1":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateOldManRoomBackgroundSprite();
                    break;
                case "Room2":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateStairRoomBackgroundSprite();
                    break;
                case "Room3":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateOneBlockRoomBackgroundSprite();
                    break;
                case "Room4":
                case "Room10":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateSixBlockRoomBackgroundSprite();
                    break;
                case "Room5":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateEmptyRoomBackgroundSprite();
                    break;
                case "Room6":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateWaterRoomBackgroundSprite();
                    break;
                case "Room7":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateLotsWaterRoomBackgroundSprite();
                    break;
                case "Room8":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateXRoomBackgroundSprite();
                    break;
                case "Room9":
                case "Room12":
                    backgroundSprite = BackgroundSpriteFactory.Instance.Create4BlockRoomBackgroundSprite();
                    break;
                case "Room11":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateStartRoomBackgroundSprite();
                    break;
                case "Room13":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateBig4BlockRoomBackgroundSprite();
                    break;
                case "Room14":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateTwo6BlockRoomBackgroundSprite();
                    break;
                case "Room15":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateDragonBackgroundSprite();
                    break;
                case "Room16":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateWallMasterRoomBackgroundSprite();
                    break;
                case "Room17":
                    backgroundSprite = BackgroundSpriteFactory.Instance.CreateFinalRoomBackgroundSprite();
                    break;
            }
        }


        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            backgroundSprite.Draw(spriteBatch, graphics);
        }

       
        

            
    }
}
