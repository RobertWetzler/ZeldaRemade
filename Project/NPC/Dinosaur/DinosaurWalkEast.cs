using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.Dinosaur
{
    class DinosaurWalkEast : INPCState
    {

        private int delay_frame_index;
        private Dinosaur dinosaur;
        private IEnemySprite sprite;
        private static int delay_frames = 15;


        public DinosaurWalkEast(Dinosaur dinosaur)
        {
            this.dinosaur = dinosaur;
            sprite = NPCSpriteFactory.Instance.CreateDinosaurSprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (dinosaur.xPos == 448)
            {
                dinosaur.currentState = new DinosaurWalkWest(dinosaur);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                dinosaur.xPos += 3;
                sprite.Update();
            }
        }
    }
}