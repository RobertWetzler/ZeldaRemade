using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Factory;
using Project.Entities;
using Project.Sprites.ItemSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Dragon
{
    class DragonAttack : INPCState
    {
        private int delay_frame_index;
        private Dragon dragon;
        private IEnemySprite sprite;
        private static int delay_frames = 10;
        private Vector2 weaponPos;
        private IWeaponSprite leftUpFireball, leftFireball, leftDownFireball;

        public DragonAttack(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = NPCSpriteFactory.Instance.CreateDragonAttackSprite();
            delay_frame_index = 0;
            weaponPos = new Vector2(dragon.xPos - 10, dragon.yPos);
            leftUpFireball = ItemSpriteFactory.Instance.CreateLeftUpFireballSprite(weaponPos);
            leftFireball = ItemSpriteFactory.Instance.CreateLeftFireballSprite(weaponPos);
            leftDownFireball = ItemSpriteFactory.Instance.CreateLeftDownFireballSprite(weaponPos);
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
            if (!leftDownFireball.isFinished())
            {
                leftUpFireball.Draw(spriteBatch);
                leftFireball.Draw(spriteBatch);
                leftDownFireball.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (leftDownFireball.isFinished())
            {
                dragon.currentState = new DragonWalkRight(dragon);
            }
             
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                sprite.Update();
            }
            leftUpFireball.Update(gameTime);
            leftFireball.Update(gameTime);
            leftDownFireball.Update(gameTime);
        }
    }
}
