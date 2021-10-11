using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project
{
    class StillNPCSprite : IEnemySprite
    {
        private Texture2D spriteSheet;

        public StillNPCSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height);
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                spriteSheet.Width * 3, spriteSheet.Height * 3);
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
        }
        public void Update()
        {

        }
    }
}
