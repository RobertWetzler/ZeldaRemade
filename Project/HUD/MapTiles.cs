using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Text;
using Project.HUD;
using Project.Utilities;

namespace Project.HUD
{
    class MapTiles
    {
        private Game1 game;
        private const int heightOffset = 0;
        private ISprite mapTile1, mapTile2, mapTile3, mapTile4, mapTile5, mapTile6, mapTile7, mapTile8, mapTile9, mapTile10, mapTile11, mapTile12, mapTile13, mapTile14, mapTile15, mapTile16, mapTile17;
        public MapTiles(Game1 game)
        {
            this.game = game;
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
        public void Draw(SpriteBatch spriteBatch)
        {
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
            }
        }
    }
}
