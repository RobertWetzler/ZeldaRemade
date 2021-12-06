using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Text
{
    class StringText : IText
    {
        private List<ISprite> textSprite = new List<ISprite>();
        private const int SHIFT = 30;
        private Vector2 position;
        public StringText(string text, Vector2 position)
        {
            this.position = position;
            textSprite = new List<ISprite>();
            foreach (char c in text.ToCharArray())
            {
                textSprite.Add(CharToSprite(c));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawPos = position;
            foreach (ISprite sprite in textSprite)
            {
                sprite.Draw(spriteBatch, drawPos);
                drawPos.X += SHIFT;
            }
        }

        public void Update(GameTime gameTime)
        {
        }

        private static ISprite CharToSprite(char c)
        {
            switch (Char.ToLower(c))
            {
                case 'a':
                    return TextSpriteFactory.Instance.CreateASprite();
                case 'b':
                    return TextSpriteFactory.Instance.CreateBSprite();
                case 'c':
                    return TextSpriteFactory.Instance.CreateCSprite();
                case 'd':
                    return TextSpriteFactory.Instance.CreateDSprite();
                case 'e':
                    return TextSpriteFactory.Instance.CreateESprite();
                case 'f':
                    return TextSpriteFactory.Instance.CreateFSprite();
                case 'g':
                    return TextSpriteFactory.Instance.CreateGSprite();
                case 'h':
                    return TextSpriteFactory.Instance.CreateHSprite();
                case 'i':
                    return TextSpriteFactory.Instance.CreateISprite();
                case 'j':
                    return TextSpriteFactory.Instance.CreateJSprite();
                case 'k':
                    return TextSpriteFactory.Instance.CreateKSprite();
                case 'l':
                    return TextSpriteFactory.Instance.CreateLSprite();
                case 'm':
                    return TextSpriteFactory.Instance.CreateMSprite();
                case 'n':
                    return TextSpriteFactory.Instance.CreateNSprite();
                case 'o':
                    return TextSpriteFactory.Instance.CreateOSprite();
                case 'p':
                    return TextSpriteFactory.Instance.CreatePSprite();
                case 'q':
                    return TextSpriteFactory.Instance.CreateQSprite();
                case 'r':
                    return TextSpriteFactory.Instance.CreateRSprite();
                case 's':
                    return TextSpriteFactory.Instance.CreateSSprite();
                case 't':
                    return TextSpriteFactory.Instance.CreateTSprite();
                case 'u':
                    return TextSpriteFactory.Instance.CreateUSprite();
                case 'v':
                    return TextSpriteFactory.Instance.CreateVSprite();
                case 'w':
                    return TextSpriteFactory.Instance.CreateWSprite();
                case 'x':
                    return TextSpriteFactory.Instance.CreateXSprite();
                case 'y':
                    return TextSpriteFactory.Instance.CreateYSprite();
                case 'z':
                    return TextSpriteFactory.Instance.CreateZSprite();
                case ' ':
                    return TextSpriteFactory.Instance.CreateBlankSprite();
                case '!':
                    return TextSpriteFactory.Instance.CreateExclamationSprite();
            }
            return null;
        }
    }
    
}
