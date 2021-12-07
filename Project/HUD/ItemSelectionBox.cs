using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;
using Vector2 = Microsoft.Xna.Framework.Vector2;
namespace Project.HUD
{
    class ItemSelectionBox
    {
        ISprite sprite;
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
            sprite.Draw(spriteBatch, SelectionBoxPosition[game.ItemIdx]);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void InitalizePositons()
        {
            SelectionBoxPosition.Add(new Vector2(500, 180));
            SelectionBoxPosition.Add(new Vector2(600, 180));
            SelectionBoxPosition.Add(new Vector2(700, 180));
            SelectionBoxPosition.Add(new Vector2(800, 180));
            SelectionBoxPosition.Add(new Vector2(500, 250));
            SelectionBoxPosition.Add(new Vector2(600, 250));
            SelectionBoxPosition.Add(new Vector2(700, 250));
            SelectionBoxPosition.Add(new Vector2(800, 250));
        }
    }
}

