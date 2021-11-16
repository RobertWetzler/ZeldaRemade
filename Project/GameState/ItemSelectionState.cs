using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;
using Project.Factory;
using Project.HUD;

namespace Project.GameState
{
    class ItemSelectionState : IGameState
    {
        private Game1 game;
        private KeyboardController keyboardController;
        private ItemSelectionScreen itemSelectionScreen;
        private ItemSelectionBox itemSelector;
        private ISprite mapTile1, mapTile2, mapTile3, mapTile4, mapTile5, mapTile6, mapTile7, mapTile8, mapTile9, mapTile10, mapTile11, mapTile12, mapTile13, mapTile14, mapTile15, mapTile16, mapTile17;
        private ISprite bomb, boomerang, sword, bow, blueCandle, map, compass;
        private IPlayer player;
        private const int heightOffset = 223;
        private Vector2 itemSelectedPosition;
        public ItemSelectionState(Game1 game)
        {
            itemSelectedPosition = new Vector2(245, 400);
            this.player = game.Player;
            this.game = game;
            this.itemSelectionScreen = new ItemSelectionScreen(game.Graphics);
            itemSelector = new ItemSelectionBox(game);
            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.B, new PlayGameCommand(this.game));
            keyboardController.RegisterCommand(Keys.F, new ItemSelectionCommand(this.game));
            mapTile1 = MapTileSpriteFactory.Instance.CreateRDoorTileSprite();
            mapTile2 = MapTileSpriteFactory.Instance.CreateRDoorTileSprite();
            mapTile3 = MapTileSpriteFactory.Instance.CreateBRDoorTileSprite();
            mapTile4 = MapTileSpriteFactory.Instance.CreateUpDoorTileSprite();
            mapTile5 = MapTileSpriteFactory.Instance.CreateRDoorTileSprite();
            mapTile6 = MapTileSpriteFactory.Instance.CreateBLDoorTileSprite();
            mapTile7 = MapTileSpriteFactory.Instance.CreateUBDoorTileSprite();
            mapTile8 = MapTileSpriteFactory.Instance.CreateULRDoorTileSprite();
            mapTile9 = MapTileSpriteFactory.Instance.CreateBLRDoorTileSprite();
            mapTile10 = MapTileSpriteFactory.Instance.CreateUBDoorTileSprite();
            mapTile11 = MapTileSpriteFactory.Instance.CreateUBLRDoorTileSprite();
            mapTile12 = MapTileSpriteFactory.Instance.CreateLRDoorTileSprite();
            mapTile13 = MapTileSpriteFactory.Instance.CreateLDoorTileSprite();
            mapTile14 = MapTileSpriteFactory.Instance.CreateLDoorTileSprite();
            mapTile15 = MapTileSpriteFactory.Instance.CreateBRDoorTileSprite();
            mapTile16 = MapTileSpriteFactory.Instance.CreateULDoorTileSprite();
            mapTile17 = MapTileSpriteFactory.Instance.CreateLDoorTileSprite();

            bomb = ItemSpriteFactory.Instance.CreateItemSprite(1, 4);
            boomerang = ItemSpriteFactory.Instance.CreateItemSprite(1, 0);
            sword = ItemSpriteFactory.Instance.CreateItemSprite(0, 10);
            bow = ItemSpriteFactory.Instance.CreateItemSprite(0, 7);
            blueCandle = ItemSpriteFactory.Instance.CreateItemSprite(0, 3);
            map = ItemSpriteFactory.Instance.CreateItemSprite(1, 8);
            compass = ItemSpriteFactory.Instance.CreateItemSprite(1, 9);


        }
        public void Update(GameTime gameTime, Rectangle gameRect)
        {
            keyboardController.Update();
            itemSelectionScreen.Update(gameTime);
            itemSelector.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            itemSelectionScreen.Draw(spriteBatch);

            itemSelector.Draw(spriteBatch);

            /*
             * Displays Items in the Selected box 
             */
            if (game.ItemIdx == 0 && player.Inventory.GetItemCount(ItemType.Bomb) > 0)
                bomb.Draw(spriteBatch, itemSelectedPosition);

            if (game.ItemIdx == 1 && player.Inventory.GetItemCount(ItemType.Blue_Candle) > 0)
                blueCandle.Draw(spriteBatch, itemSelectedPosition);

            if (game.ItemIdx == 2 && player.Inventory.GetItemCount(ItemType.Bow) > 0)
                bow.Draw(spriteBatch, itemSelectedPosition);

            if (game.ItemIdx == 3 && player.Inventory.GetItemCount(ItemType.Boomerang) > 0)
                boomerang.Draw(spriteBatch, itemSelectedPosition);

            if (game.ItemIdx == 4 && player.Inventory.GetItemCount(ItemType.Sword) > 0)
                sword.Draw(spriteBatch, itemSelectedPosition);


            /*
             * Displays Items in the inventory box          
             */
            if (player.Inventory.GetItemCount(ItemType.Bomb) > 0)
                bomb.Draw(spriteBatch, new Vector2(500, 400));

            if (player.Inventory.GetItemCount(ItemType.Blue_Candle) > 0)
                blueCandle.Draw(spriteBatch, new Vector2(600, 400));

            if (player.Inventory.GetItemCount(ItemType.Bow)> 0)
                bow.Draw(spriteBatch, new Vector2(700, 400));
            
            if (player.Inventory.GetItemCount(ItemType.Boomerang) > 0)
                boomerang.Draw(spriteBatch, new Vector2(800, 400));

            if (player.Inventory.GetItemCount(ItemType.Sword) > 0)
                sword.Draw(spriteBatch, new Vector2(500, 470));


            if (player.Inventory.GetItemCount(ItemType.Compass) > 0)
                compass.Draw(spriteBatch, new Vector2(165, 800));
            

            if (player.Inventory.GetItemCount(ItemType.Map) > 0)
            {
                map.Draw(spriteBatch, new Vector2(165, 650));
                foreach (var room in game.PassedRoom)
                {
                    switch (room)
                    {
                        case 0:
                            mapTile1.Draw(spriteBatch, new Vector2(400, 464 + heightOffset), Color.White);
                            break;
                        case 1:
                            mapTile2.Draw(spriteBatch, new Vector2(500, 400 + heightOffset), Color.White);
                            break;
                        case 2:
                            mapTile3.Draw(spriteBatch, new Vector2(500, 464 + heightOffset), Color.White);
                            break;
                        case 3:
                            mapTile4.Draw(spriteBatch, new Vector2(500, 496 + heightOffset), Color.White);
                            break;
                        case 4:
                            mapTile5.Draw(spriteBatch, new Vector2(500, 560 + heightOffset), Color.White);
                            break;
                        case 5:
                            mapTile6.Draw(spriteBatch, new Vector2(532, 400 + heightOffset), Color.White);
                            break;
                        case 6:
                            mapTile7.Draw(spriteBatch, new Vector2(532, 432 + heightOffset), Color.White);
                            break;
                        case 7:
                            mapTile8.Draw(spriteBatch, new Vector2(532, 464 + heightOffset), Color.White);
                            break;
                        case 8:
                            mapTile9.Draw(spriteBatch, new Vector2(532, 496 + heightOffset), Color.White);
                            break;
                        case 9:
                            mapTile10.Draw(spriteBatch, new Vector2(532, 528 + heightOffset), Color.White);
                            break;
                        case 10:
                            mapTile11.Draw(spriteBatch, new Vector2(532, 560 + heightOffset), Color.White);
                            break;
                        case 11:
                            mapTile12.Draw(spriteBatch, new Vector2(564, 464 + heightOffset), Color.White);
                            break;
                        case 12:
                            mapTile13.Draw(spriteBatch, new Vector2(564, 496 + heightOffset), Color.White);
                            break;
                        case 13:
                            mapTile14.Draw(spriteBatch, new Vector2(564, 560 + heightOffset), Color.White);
                            break;
                        case 14:
                            mapTile15.Draw(spriteBatch, new Vector2(596, 432 + heightOffset), Color.White);
                            break;
                        case 15:
                            mapTile16.Draw(spriteBatch, new Vector2(596, 464 + heightOffset), Color.White);
                            break;
                        case 16:
                            mapTile17.Draw(spriteBatch, new Vector2(628, 432 + heightOffset), Color.White);
                            break;
                    }

                }
            }
        }
    }
}
