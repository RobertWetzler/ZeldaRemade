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
        private Texture2D Boss_Dragon;
        private Texture2D Dinosaur_Left_Right;
        private Texture2D Dinosaur_Up_Down;
        private Texture2D Bat;
        private Texture2D Gel;
        private Texture2D Skeleton;



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
            Boss_Dragon = content.Load<Texture2D>("EnemySprites/boss-dragon");
            Dinosaur_Left_Right = content.Load<Texture2D>("EnemySprites/dinosaur-front-back");
            Dinosaur_Up_Down = content.Load<Texture2D>("EnemySprites/dinosaur-left-right");
            Bat = content.Load<Texture2D>("EnemySprites/enemy-bat");
            Gel = content.Load<Texture2D>("EnemySprites/enemy-gel");


        }


    }
}
