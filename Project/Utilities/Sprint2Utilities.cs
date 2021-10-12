using Microsoft.Xna.Framework.Input;
using Project.Factory;
using Project.NPC.Bat;
using Project.NPC.BigJelly;
using Project.NPC.Dinosaur;
using Project.NPC.Dragon;
using Project.NPC.Goriya;
using Project.NPC.Merchant;
using Project.NPC.OldMan;
using Project.NPC.Skeleton;
using Project.NPC.SmallJelly;
using Project.NPC.Trap;
using Project.NPC.Flame;
using Project.NPC.Snake;
using Project.Sprites.BlockSprites;
using Project.Sprites.ItemSprites;
using System.Collections.Generic;

namespace Project.Utilities
{
    public static class Sprint2Utilities
    {
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

        public static void SetItemList(List<IItemSprite> items)
        {
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 0));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 1));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 2));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 3));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 4));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 6));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 7));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 8));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 9));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(0, 10));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 0));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 1));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 2));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 3));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 4));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 5));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 6));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 7));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 8));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 9));
            items.Add(ItemSpriteFactory.Instance.CreateItemSprite(1, 10));
            items.Add(ItemSpriteFactory.Instance.CreateFairySprite());
            items.Add(ItemSpriteFactory.Instance.CreateRupeeSprite());
            items.Add(ItemSpriteFactory.Instance.CreateHeartSprite());
            items.Add(ItemSpriteFactory.Instance.CreateTriforceSprite());
        }
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

            //Cycle thru sprites commands
            keyboardController.RegisterCommand(Keys.T, new GetPreviousBlockCommand(game));
            keyboardController.RegisterCommand(Keys.Y, new GetNextBlockCommand(game));
            keyboardController.RegisterCommand(Keys.O, new GetPreviousEnemyCommand(game));
            keyboardController.RegisterCommand(Keys.P, new GetNextEnemyCommand(game));
            keyboardController.RegisterCommand(Keys.I, new GetPreviousItemCommand(game));
            keyboardController.RegisterCommand(Keys.U, new GetNextItemCommand(game));

            controllers.Add(keyboardController);
        }
        public static void SetNPCList(List<INPC> npcsList)
        {
            npcsList.Add(new Flame());
            npcsList.Add(new Bat());
            npcsList.Add(new Skeleton());
            npcsList.Add(new SmallJelly());
            npcsList.Add(new BigJelly());
            npcsList.Add(new Goriya());
            npcsList.Add(new Trap());
            npcsList.Add(new OldMan());
            npcsList.Add(new Merchant());
            npcsList.Add(new Dragon());
            npcsList.Add(new WallMaster());
            npcsList.Add(new Dinosaur());
            npcsList.Add(new Snake());
        }
    }
}
