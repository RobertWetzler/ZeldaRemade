using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.HUD;
using Project.Utilities;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Project.GameState
{
    class PausedState : IGameState
    {
        private Game1 game;
        private KeyboardController keyboardController;
        private IHUD smallHUD;
        private ISprite spriteBlank, spriteA, spriteD, spriteE, spriteP, spriteS, spriteU;
        private List<ISprite> textList = new List<ISprite>();
        private int textLinePosX = 420;
        private int textLinePosY = 500;
        
        int shift = 30;
        public PausedState(Game1 game)
        {
            this.game = game;
            smallHUD = new SmallHUD(false);
            SoundManager.Instance.music.Pause();
            spriteBlank = TextSpriteFactory.Instance.CreateBlankSprite();
            spriteA = TextSpriteFactory.Instance.CreateASprite();
            spriteD = TextSpriteFactory.Instance.CreateDSprite();
            spriteE = TextSpriteFactory.Instance.CreateESprite();
            spriteP = TextSpriteFactory.Instance.CreatePSprite();
            spriteS = TextSpriteFactory.Instance.CreateSSprite();
            spriteU = TextSpriteFactory.Instance.CreateUSprite();

            textList.Add(spriteP);
            textList.Add(spriteA);
            textList.Add(spriteU);
            textList.Add(spriteS);
            textList.Add(spriteE);
            textList.Add(spriteD);
        }

        public void Update(GameTime gameTime, Rectangle bounds)
        {
            PauseController.controller.Update();
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            int i = 0;
            RoomManager.Instance.CurrentRoom.Draw(spriteBatch, gameTime);
            game.Player.Draw(spriteBatch, gameTime);
            foreach(var text in textList)
            {
                text.Draw(spriteBatch, new Vector2(textLinePosX + i, textLinePosY));
                i += shift;
            }

            RoomManager.Instance.CurrentRoom.DrawForeground(spriteBatch, gameTime);
            smallHUD.Draw(spriteBatch);
        }


    }
}
