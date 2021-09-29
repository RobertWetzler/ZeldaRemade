using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Factory
{
    public class NPCSpriteFactory
    {
        private Texture2D bossDragonSpriteSheet;
        private Texture2D dinosaurLeftRightSpriteSheet;
        private Texture2D dinosaurUpDownSpriteSheet;
        private Texture2D batSpriteSheet;
        private Texture2D gelSpriteSheet;
        private Texture2D skeletonSpriteSheet;
        private Texture2D goriyaSpriteSheet;
        private Texture2D snakeSpriteSheet;
        private Texture2D wallmasterSpriteSheet;
        private Texture2D zolSpriteSheet;


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
            bossDragonSpriteSheet = content.Load<Texture2D>("EnemySprites/boss-dragon");
            dinosaurLeftRightSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-front-back");
            dinosaurUpDownSpriteSheet = content.Load<Texture2D>("EnemySprites/dinosaur-left-right");
            batSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-bat");
            gelSpriteSheet= content.Load<Texture2D>("EnemySprites/enemy-gel");
            skeletonSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-skeleton");
            goriyaSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-goriya-walking");
            snakeSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-snake");
            wallmasterSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-wallmaster");
            zolSpriteSheet = content.Load<Texture2D>("EnemySprites/enemy-zol");


        }


    }
}