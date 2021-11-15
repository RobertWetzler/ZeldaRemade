using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Project.HUD
{
    class ItemSelectionBox
    {
        ISprite sprite;
        private KeyboardController keyboardController;
        public List<Vector2> SelectionBoxPosition = new List<Vector2>();
        private Game1 game;
        public ItemSelectionBox(Game1 game)
        {
            this.game = game;
            sprite = HUDSpriteFactory.Instance.CreateItemSelectionBoxSprite();
            this.InitalizePositons();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Debug.WriteLine(game.ItemIdx);
            sprite.Draw(spriteBatch, SelectionBoxPosition[game.ItemIdx]);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void InitalizePositons()
        {
            SelectionBoxPosition.Add(new Vector2(500, 400));
            SelectionBoxPosition.Add(new Vector2(600, 400));
            SelectionBoxPosition.Add(new Vector2(700, 400));
            SelectionBoxPosition.Add(new Vector2(800, 400));
            SelectionBoxPosition.Add(new Vector2(500, 470));
            SelectionBoxPosition.Add(new Vector2(600, 470));
            SelectionBoxPosition.Add(new Vector2(700, 470));
            SelectionBoxPosition.Add(new Vector2(800, 470));

        }
    }
}
