using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.MapTileSprites;

namespace Project.Factory
{
    public class MapTileSpriteFactory
    {
        private Texture2D tileSpriteSheet;

        private static MapTileSpriteFactory instance = new MapTileSpriteFactory();

        public static MapTileSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MapTileSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            tileSpriteSheet = content.Load<Texture2D>("HUD/orange-map-tiles");
        }

        //Tile with no door
        public ISprite CreateNoDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 0, 0);
        }
        //Tile with right door
        public ISprite CreateRDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 8, 0);
        }
        //Tile with left door
        public ISprite CreateLDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 17, 0);
        }
        //Tile with left, right door
        public ISprite CreateLRDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 26, 0);
        }
        //Tile with bottom door
        public ISprite CreateBDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 35, 0);
        }
        //Tile with bottom, right door
        public ISprite CreateBRDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 44, 0);
        }
        //Tile with bottom, left door
        public ISprite CreateBLDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 53, 0);//
        }
        //Tile with bottom, left, right door
        public ISprite CreateBLRDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 62, 0);
        }
        //Tile with up door
        public ISprite CreateUpDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 71, 0);
        }
        //Tile with up, right door
        public ISprite CreateURDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 79, 0);
        }
        //Tile with up, left door
        public ISprite CreateULDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 89, 0);
        }
        //Tile with up, left, right door
        public ISprite CreateULRDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 98, 0);
        }
        //Tile with up, bottom door
        public ISprite CreateUBDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 107, 0);
        }
        //Tile with up, bottom, right door
        public ISprite CreateUBRDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 115, 0);
        }
        //Tile with up, bottom, left door
        public ISprite CreateUBLDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 125, 0);
        }
        //Tile with up, bottom, left, right door
        public ISprite CreateUBLRDoorTileSprite()
        {
            return new MapTileSprite(tileSpriteSheet, 134, 0);
        }

    }
}
