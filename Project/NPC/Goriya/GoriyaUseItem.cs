using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Sprites.ItemSprites;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Goriya
{
    class GoriyaUseItem : INPCState
    {
        private int delay_frame_index;
        private Goriya goriya;
        private IEnemySprite goriyaSprite;
        private IWeaponSprites boomerang;
        private Vector2 weaponPos;
        private static int delay_frames = 7;
        private Facing dir;

        public GoriyaUseItem(Goriya goriya, Facing dir)
        {
            this.dir = dir;
            this.goriya = goriya;
            delay_frame_index = 0;
            goriyaSprite = NPCSpriteFactory.Instance.CreateGoriyaUseItemSprite(dir);
            switch (dir)
            {
                case Facing.Up:
                case Facing.Down:
                    weaponPos = new Vector2(goriya.xPos + 20, goriya.yPos);
                    break;
                default:
                    weaponPos = new Vector2(goriya.xPos, goriya.yPos);
                    break;
            }
            boomerang = ItemSpriteFactory.Instance.CreateBoomerangSprite(dir, weaponPos);
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            goriyaSprite.Draw(spriteBatch, xPos, yPos);
            if (!boomerang.isFinished())
            {
                boomerang.Draw(spriteBatch);
            }
            
        }

        public void Update(GameTime gameTime)
        {
            if (boomerang.isFinished())
            {
                switch (dir)
                {
                    case Facing.Right:
                        goriya.currentState = new GoriyaWalkEast(goriya);
                        break;
                    case Facing.Down:
                        goriya.currentState = new GoriyaWalkSouth(goriya);
                        break;
                    case Facing.Up:
                        goriya.currentState = new GoriyaWalkNorth(goriya);
                        break;
                    case Facing.Left:
                        goriya.currentState = new GoriyaWalkWest(goriya);
                        break;
                }
                
            }
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriyaSprite.Update();
            }
            boomerang.Update(gameTime);
        }
    }
}
