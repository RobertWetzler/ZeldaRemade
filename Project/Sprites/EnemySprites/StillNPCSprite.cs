using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project
{
    class StillNPCSprite : IEnemySprite
    {
        private Texture2D spriteSheet; 
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;

        public StillNPCSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height);
            destRectangle = new Rectangle(
                (int)xPos, (int)yPos,
                spriteSheet.Width * 3, spriteSheet.Height * 3);
            spriteBatch.Draw(spriteSheet, destRectangle, source, Color.White);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
