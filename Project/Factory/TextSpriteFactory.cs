using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites.TextSprites;

namespace Project.Factory
{
    public class TextSpriteFactory
    {
        private Texture2D fontSpriteSheet;


        private static TextSpriteFactory instance = new TextSpriteFactory();

        public static TextSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private TextSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            fontSpriteSheet = content.Load<Texture2D>("FontSprites/Fonts");
        }

        // Create sprites for alphabets
        public ISprite CreateASprite()
        {
            return new TextSprite(fontSpriteSheet, 163, 3);
        }

        public ISprite CreateBSprite()
        {
            return new TextSprite(fontSpriteSheet, 179, 3);
        }

        public ISprite CreateCSprite()
        {
            return new TextSprite(fontSpriteSheet, 195, 3);
        }

        public ISprite CreateDSprite()
        {
            return new TextSprite(fontSpriteSheet, 211, 3);
        }

        public ISprite CreateESprite()
        {
            return new TextSprite(fontSpriteSheet, 227, 3);
        }

        public ISprite CreateFSprite()
        {
            return new TextSprite(fontSpriteSheet, 243, 3);
        }

        public ISprite CreateGSprite()
        {
            return new TextSprite(fontSpriteSheet, 3, 19);
        }

        public ISprite CreateHSprite()
        {
            return new TextSprite(fontSpriteSheet, 19, 19);
        }

        public ISprite CreateISprite()
        {
            return new TextSprite(fontSpriteSheet, 35, 19);
        }

        public ISprite CreateJSprite()
        {
            return new TextSprite(fontSpriteSheet, 51, 19);
        }

        public ISprite CreateKSprite()
        {
            return new TextSprite(fontSpriteSheet, 67, 19);
        }

        public ISprite CreateLSprite()
        {
            return new TextSprite(fontSpriteSheet, 83, 19);
        }

        public ISprite CreateMSprite()
        {
            return new TextSprite(fontSpriteSheet, 99, 19);
        }

        public ISprite CreateNSprite()
        {
            return new TextSprite(fontSpriteSheet, 115, 19);
        }

        public ISprite CreateOSprite()
        {
            return new TextSprite(fontSpriteSheet, 131, 19);
        }

        public ISprite CreatePSprite()
        {
            return new TextSprite(fontSpriteSheet, 147, 19);
        }

        public ISprite CreateQSprite()
        {
            return new TextSprite(fontSpriteSheet, 163, 19);
        }

        public ISprite CreateRSprite()
        {
            return new TextSprite(fontSpriteSheet, 179, 19);
        }

        public ISprite CreateSSprite()
        {
            return new TextSprite(fontSpriteSheet, 195, 19);
        }

        public ISprite CreateTSprite()
        {
            return new TextSprite(fontSpriteSheet, 211, 19);
        }

        public ISprite CreateUSprite()
        {

            return new TextSprite(fontSpriteSheet, 227, 19);
        }

        public ISprite CreateVSprite()
        {
            return new TextSprite(fontSpriteSheet, 243, 19);
        }

        public ISprite CreateWSprite()
        {
            return new TextSprite(fontSpriteSheet, 3, 35);
        }

        public ISprite CreateXSprite()
        {
            return new TextSprite(fontSpriteSheet, 19, 35);
        }

        public ISprite CreateYSprite()
        {
            return new TextSprite(fontSpriteSheet, 35, 35);
        }

        public ISprite CreateZSprite()
        {
            return new TextSprite(fontSpriteSheet, 51, 35);
        }

        public ISprite CreateBlankSprite()
        {
            return new TextSprite(fontSpriteSheet, 10, 19);
        }

        public ISprite Create0Sprite()
        {
            return new TextSprite(fontSpriteSheet, 3, 3);
        }

        public ISprite Create1Sprite()
        {
            return new TextSprite(fontSpriteSheet, 19, 3);
        }

        public ISprite Create2Sprite()
        {
            return new TextSprite(fontSpriteSheet, 35, 3);
        }
        public ISprite Create3Sprite()
        {
            return new TextSprite(fontSpriteSheet, 51, 3);
        }
        public ISprite Create4Sprite()
        {
            return new TextSprite(fontSpriteSheet, 67, 3);
        }
        public ISprite Create5Sprite()
        {
            return new TextSprite(fontSpriteSheet, 83, 3);
        }
        public ISprite Create6Sprite()
        {
            return new TextSprite(fontSpriteSheet, 99, 3);
        }
        public ISprite Create7Sprite()
        {
            return new TextSprite(fontSpriteSheet, 115, 3);
        }
        public ISprite Create8Sprite()
        {
            return new TextSprite(fontSpriteSheet, 131, 3);
        }
        public ISprite Create9Sprite()
        {
            return new TextSprite(fontSpriteSheet, 147, 3);
        }
    }
}
