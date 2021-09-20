using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Project
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISprite sprite;
        private Texture2D texture_atlas;
        private List<IController> controllers;
        private TextSprite text;

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        public void SetSprite(ISprite sprite)
        {
            this.sprite = sprite;
            this.sprite.texture = texture_atlas;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            sprite = new FixedNonAnimatedSprite();
            text = new TextSprite();
            controllers = new List<IController>();

            KeyboardController keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.D0, new ExitCommand(this));
            keyboardController.RegisterCommand(Keys.D1, new SetFixedNonAnimatedSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.D2, new SetFixedAnimatedSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.D3, new SetMovingNonAnimatedSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.D4, new SetMovingAnimatedSpriteCommand(this));
            controllers.Add(keyboardController);

            MouseController mouseController = new MouseController(_graphics.GraphicsDevice.Viewport.Bounds);
            mouseController.RegisterCommand(new ButtonPosition(Button.LeftButton, Quadrant.UpperLeft), new SetFixedNonAnimatedSpriteCommand(this));
            mouseController.RegisterCommand(new ButtonPosition(Button.LeftButton, Quadrant.UpperRight), new SetFixedAnimatedSpriteCommand(this));
            mouseController.RegisterCommand(new ButtonPosition(Button.LeftButton, Quadrant.LowerLeft), new SetMovingNonAnimatedSpriteCommand(this));
            mouseController.RegisterCommand(new ButtonPosition(Button.LeftButton, Quadrant.LowerRight), new SetMovingAnimatedSpriteCommand(this));
            mouseController.RegisterCommand(new ButtonPosition(Button.RightButton, Quadrant.All), new ExitCommand(this));
            controllers.Add(mouseController);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            texture_atlas = Content.Load<Texture2D>("mario");
            sprite.texture = texture_atlas;
            text.font = Content.Load<SpriteFont>("Caption");
            //Use static class to load all textures
            Texture2DStorage.LoadTextures(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            sprite.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            sprite.Draw(_spriteBatch, gameTime);
            text.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
