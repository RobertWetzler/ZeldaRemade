using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System.Collections.Generic;

namespace Project.Factory
{
    public class NPCSpriteFactory
    {
        private Texture2D oldManSpriteSheet;
        private Texture2D merchantSpriteSheet;
        private Texture2D flameSpriteSheet;

        private static NPCSpriteFactory instance = new NPCSpriteFactory();

        public static NPCSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private NPCSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            oldManSpriteSheet = content.Load<Texture2D>("EnemySprites/oldman"); ;
            merchantSpriteSheet = content.Load<Texture2D>("EnemySprites/merchant");
            flameSpriteSheet = content.Load<Texture2D>("EnemySprites/flame");
        }
        public ISprite CreateOldManSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));

            return new StillNPCSprite(oldManSpriteSheet);
        }

        public ISprite CreateMerchantSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));

            return new StillNPCSprite(merchantSpriteSheet);
        }

        public ISprite CreateEnemyFlameSprite()
        {
            List<Rectangle> sourceFrames = new List<Rectangle>();
            sourceFrames.Add(new Rectangle(0, 0, 16, 16));

            return new FlameEnemySprite(flameSpriteSheet, sourceFrames);
        }
       
    }
}