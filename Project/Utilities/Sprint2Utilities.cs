using Microsoft.Xna.Framework.Input;
<<<<<<< HEAD
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
=======
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678
using Project.NPC.Merchant;
using Project.NPC.OldMan;
using Project.NPC.Flame;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Project.Blocks;

namespace Project.Utilities
{
    
    public static class Sprint2Utilities
    {
       
<<<<<<< HEAD
        public static void SetBlockList(List<IBlockSprite> blocks)
        {
            blocks.Add(BlockSpriteFactory.Instance.CreatePlainBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreatePyramidBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateRightFacingDragonBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateLeftFacingDragonBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBlackBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateDottedBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateDarkBlueBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateStairBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBrickBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateLayeredBlockSprite());
        }

        public static void SetItemList(List<IItem> items)
        {
            items.Add(new Arrow(new Vector2(200, 300)));
            items.Add(new BlueArrow(new Vector2(200, 300)));
            items.Add(new BlueBoomerang(new Vector2(200, 300)));
            items.Add(new Boomerang(new Vector2(200, 300)));
            items.Add(new Sword(new Vector2(200, 300)));
            items.Add(new WhiteSword(new Vector2(200, 300)));
            items.Add(new Bow(new Vector2(200, 300)));
            items.Add(new Bomb(new Vector2(200, 300)));
            items.Add(new Flute(new Vector2(200, 300)));
            items.Add(new Clock(new Vector2(200, 300)));
            items.Add(new Meat(new Vector2(200, 300)));
            items.Add(new Map(new Vector2(200, 300)));
            items.Add(new Key(new Vector2(200, 300)));
            items.Add(new Ring(new Vector2(200, 300)));
            items.Add(new BlueRing(new Vector2(200, 300)));
            items.Add(new Bottle(new Vector2(200, 300)));
            items.Add(new BlueBottle(new Vector2(200, 300)));
            items.Add(new Compass(new Vector2(200, 300)));
            items.Add(new Candle(new Vector2(200, 300)));
            items.Add(new BlueCandle(new Vector2(200, 300)));
            items.Add(new Heart(new Vector2(200, 300)));
            items.Add(new HeartContainer(new Vector2(200, 300)));
            items.Add(new Fairy(new Vector2(200, 300)));
            items.Add(new Triforce(new Vector2(200, 300)));
            items.Add(new FiveRupee(new Vector2(200, 300)));
            items.Add(new OneRupee(new Vector2(200, 300)));
        }
=======
>>>>>>> 692d792898b0b47dcf927cb0960b724b996cd678
        public static void SetKeyboardControllers(List<IController> controllers, Game1 game)
        {
            KeyboardController keyboardController = new KeyboardController();

            //Register player damage command
            keyboardController.RegisterCommand(Keys.E, new PlayerDamageCommand(game));

            //Register both WASD and Arrows
            ICommand upCommand = new PlayerMoveUpCommand(game);
            keyboardController.RegisterCommand(Keys.W, upCommand);
            keyboardController.RegisterCommand(Keys.Up, upCommand);

            ICommand leftCommand = new PlayerMoveLeftCommand(game);
            keyboardController.RegisterCommand(Keys.A, leftCommand);
            keyboardController.RegisterCommand(Keys.Left, leftCommand);

            ICommand rightCommand = new PlayerMoveRightCommand(game);
            keyboardController.RegisterCommand(Keys.D, rightCommand);
            keyboardController.RegisterCommand(Keys.Right, rightCommand);

            ICommand downCommand = new PlayerMoveDownCommand(game);
            keyboardController.RegisterCommand(Keys.S, downCommand);
            keyboardController.RegisterCommand(Keys.Down, downCommand);

            ICommand swordCommand = new PlayerUseSwordCommand(game);
            keyboardController.RegisterCommand(Keys.Z, swordCommand); //Use sword with Z
            keyboardController.RegisterCommand(Keys.N, swordCommand); //Use sword with N

            keyboardController.RegisterCommand(Keys.D1, new PlayerUseBombCommand(game)); //Use bomb with 1
            keyboardController.RegisterCommand(Keys.D2, new PlayerUseArrowCommand(game)); //Use arrow with 2
            keyboardController.RegisterCommand(Keys.D3, new PlayerUseBlueArrowCommand(game)); //Use blue arrow with 3
            keyboardController.RegisterCommand(Keys.D4, new PlayerUseBoomerangCommand(game)); //Use boomerang with 4
            keyboardController.RegisterCommand(Keys.D5, new PlayerUseBlueBoomerangCommand(game)); //Use blue boomerang with 5
            keyboardController.RegisterCommand(Keys.D6, new PlayerUseFlameCommand(game)); //Use flame with 6

            //Register reset and quit command
            ICommand resetCommand = new ResetCommand(game);
            keyboardController.RegisterCommand(Keys.R, resetCommand);
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(game));

            //Register idle command as default
            keyboardController.RegisterDefaultCommand(new PlayerStopMovingCommand(game));

            controllers.Add(keyboardController);
        }
    }
}
