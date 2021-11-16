using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.MapTileSprites
{
    class MapTileSprite : ISprite
    {
        private Texture2D mapTileSpriteSheet;
        private int sourceX;
        private int sourceY;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;


        public MapTileSprite(Texture2D mapTileSpriteSheet, int sourceX, int sourceY)
        {
            this.mapTileSpriteSheet = mapTileSpriteSheet;
            this.sourceX = sourceX;
            this.sourceY = sourceY;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            int width = 10;
            int height = 8;
            int scale = 4;

            Rectangle source = new Rectangle(sourceX,sourceY,width,height);
            destRectangle = new Rectangle((int)position.X, (int)position.Y, width * scale, height * scale);
            spriteBatch.Draw(mapTileSpriteSheet, destRectangle, source, Color.White);
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
