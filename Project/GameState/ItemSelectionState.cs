using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Utilities;
using Project.Factory;
using Project.HUD;

namespace Project.GameState
{
    class ItemSelectionState : IGameState
    {
        private Game1 game;
        private KeyboardController keyboardController;
        private ItemSelectionScreen itemSelectionScreen;
        private ISprite mapTile1, mapTile2, mapTile3, mapTile4, mapTile5, mapTile6, mapTile7, mapTile8, mapTile9, mapTile10, mapTile11, mapTile12, mapTile13, mapTile14, mapTile15, mapTile16, mapTile17;
        private const int heightOffset = 0;
        private IHUD smallHud;
        private ISprite posDot;
        private Vector2 dotPos;

        public ItemSelectionState(Game1 game)
        {
            this.game = game;
            posDot = HUDSpriteFactory.Instance.CreateWhiteSquare();
            dotPos = new Vector2(544, 569);
            this.itemSelectionScreen = new ItemSelectionScreen(game.Graphics);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.Escape, new PlayGameCommand(this.game));
            smallHud = new SmallHUD(true);
            
            mapTile1 = MapTileSpriteFactory.Instance.CreateRDoorTileSprite();
            mapTile2 = MapTileSpriteFactory.Instance.CreateRDoorTileSprite();
            mapTile3 = MapTileSpriteFactory.Instance.CreateBRDoorTileSprite();
            mapTile4 = MapTileSpriteFactory.Instance.CreateUpDoorTileSprite();
            mapTile5 = MapTileSpriteFactory.Instance.CreateRDoorTileSprite();
            mapTile6 = MapTileSpriteFactory.Instance.CreateBLDoorTileSprite();
            mapTile7 = MapTileSpriteFactory.Instance.CreateUBDoorTileSprite();
            mapTile8 = MapTileSpriteFactory.Instance.CreateULRDoorTileSprite();
            mapTile9 = MapTileSpriteFactory.Instance.CreateBLRDoorTileSprite();
            mapTile10 = MapTileSpriteFactory.Instance.CreateUBDoorTileSprite();
            mapTile11 = MapTileSpriteFactory.Instance.CreateUBLRDoorTileSprite();
            mapTile12 = MapTileSpriteFactory.Instance.CreateLRDoorTileSprite();
            mapTile13 = MapTileSpriteFactory.Instance.CreateLDoorTileSprite();
            mapTile14 = MapTileSpriteFactory.Instance.CreateLDoorTileSprite();
            mapTile15 = MapTileSpriteFactory.Instance.CreateBRDoorTileSprite();
            mapTile16 = MapTileSpriteFactory.Instance.CreateULDoorTileSprite();
            mapTile17 = MapTileSpriteFactory.Instance.CreateLDoorTileSprite();

        }
        public void Update(GameTime gameTime, Rectangle gameRect)
        {
            keyboardController.Update();
            itemSelectionScreen.Update(gameTime);
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
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            itemSelectionScreen.Draw(spriteBatch);
            smallHud.Draw(spriteBatch);
            foreach (var room in game.PassedRoom)
            {
                switch (room)
                {
                    case 1:
                        mapTile1.Draw(spriteBatch, new Vector2(468, 464 + heightOffset), Color.White);
                        break;
                    case 2:
                        mapTile2.Draw(spriteBatch, new Vector2(500, 400 + heightOffset), Color.White);
                        break;
                    case 3:
                        mapTile3.Draw(spriteBatch, new Vector2(500, 464 + heightOffset), Color.White);
                        break;
                    case 4:
                        mapTile4.Draw(spriteBatch, new Vector2(500, 496 + heightOffset), Color.White);
                        break;
                    case 5:
                        mapTile5.Draw(spriteBatch, new Vector2(500, 560 + heightOffset), Color.White);
                        break;
                    case 6:
                        mapTile6.Draw(spriteBatch, new Vector2(532, 400 + heightOffset), Color.White);
                        break;
                    case 7:
                        mapTile7.Draw(spriteBatch, new Vector2(532, 432 + heightOffset), Color.White);
                        break;
                    case 8:
                        mapTile8.Draw(spriteBatch, new Vector2(532, 464 + heightOffset), Color.White);
                        break;
                    case 9:
                        mapTile9.Draw(spriteBatch, new Vector2(532, 496 + heightOffset), Color.White);
                        break;
                    case 10:
                        mapTile10.Draw(spriteBatch, new Vector2(532, 528 + heightOffset), Color.White);
                        break;
                    case 11:
                        mapTile11.Draw(spriteBatch, new Vector2(532, 560 + heightOffset), Color.White);
                        break;
                    case 12:
                        mapTile12.Draw(spriteBatch, new Vector2(564, 464 + heightOffset), Color.White);
                        break;
                    case 13:
                        mapTile13.Draw(spriteBatch, new Vector2(564, 496 + heightOffset), Color.White);
                        break;
                    case 14:
                        mapTile14.Draw(spriteBatch, new Vector2(564, 560 + heightOffset), Color.White);
                        break;
                    case 15:
                        mapTile15.Draw(spriteBatch, new Vector2(596, 432 + heightOffset), Color.White);
                        break;
                    case 16:
                        mapTile16.Draw(spriteBatch, new Vector2(596, 464 + heightOffset), Color.White);
                        break;
                    case 17:
                        mapTile17.Draw(spriteBatch, new Vector2(628, 432 + heightOffset), Color.White);
                        break;
                }
                posDot.Draw(spriteBatch, dotPos, Color.White);
            }
        }
    }
}
