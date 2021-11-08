using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Project.Factory
{
    public class SoundFactory
    {
        public SoundEffect arrow_boomerang;
        public SoundEffect background_music;
        public SoundEffect bomb_blow;
        public SoundEffect bomb_drop;
        public SoundEffect boss_scream;
        public SoundEffect candle;
        public SoundEffect door_unlock;
        public SoundEffect enemy_die;
        public SoundEffect enemy_hit;
        public SoundEffect fanfare;
        public SoundEffect get_heart;
        public SoundEffect get_item;
        public SoundEffect get_rupee;
        public SoundEffect get_key;
        public SoundEffect link_death;
        public SoundEffect link_hurt;
        public SoundEffect low_health;
        public SoundEffect get_secret;
        public SoundEffect stairs;
        public SoundEffect sword_shoot;
        public SoundEffect sword_slash;
        public SoundEffect text;
        public SoundEffectInstance music;
        public SoundEffectInstance soundInstance;
        public static SoundFactory instance = new SoundFactory();

        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private SoundFactory()
        {
        }

        public void LoadAllTextures(ContentManager soundFile)
        {
            arrow_boomerang = soundFile.Load<SoundEffect>("Sound/LOZ_Arrow_Boomerang");
            background_music = soundFile.Load<SoundEffect>("Sound/LOZ_Background_Music");
            bomb_blow = soundFile.Load<SoundEffect>("Sound/LOZ_Bomb_Blow");
            bomb_drop = soundFile.Load<SoundEffect>("Sound/LOZ_Bomb_Drop");
            boss_scream = soundFile.Load<SoundEffect>("Sound/LOZ_Boss_Scream1");
            candle = soundFile.Load<SoundEffect>("Sound/LOZ_Candle");
            door_unlock = soundFile.Load<SoundEffect>("Sound/LOZ_Door_Unlock");
            enemy_die = soundFile.Load<SoundEffect>("Sound/LOZ_Enemy_Die");
            enemy_hit = soundFile.Load<SoundEffect>("Sound/LOZ_Enemy_Hit");
            fanfare = soundFile.Load<SoundEffect>("Sound/LOZ_Fanfare");
            get_heart = soundFile.Load<SoundEffect>("Sound/LOZ_Get_Heart");
            get_item = soundFile.Load<SoundEffect>("Sound/LOZ_Get_Item");
            get_rupee = soundFile.Load<SoundEffect>("Sound/LOZ_Get_Rupee");
            get_key = soundFile.Load<SoundEffect>("Sound/LOZ_Key_Appear");
            link_death = soundFile.Load<SoundEffect>("Sound/LOZ_Link_Die");
            link_hurt = soundFile.Load<SoundEffect>("Sound/LOZ_Link_Hurt");
            low_health = soundFile.Load<SoundEffect>("Sound/LOZ_LowHealth");
            get_secret = soundFile.Load<SoundEffect>("Sound/LOZ_Secret");
            stairs = soundFile.Load<SoundEffect>("Sound/LOZ_Stairs");
            sword_shoot = soundFile.Load<SoundEffect>("Sound/LOZ_Sword_Shoot");
            sword_slash = soundFile.Load<SoundEffect>("Sound/LOZ_Sword_Slash");
            text = soundFile.Load<SoundEffect>("Sound/LOZ_Text");

            if(music != null)
            {
                music.Stop();
            }
            music = background_music.CreateInstance();
            music.IsLooped = true;
            music.Play();

        }

        public SoundEffect CreateArrowBoomerang()
        {
            soundInstance = arrow_boomerang.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return arrow_boomerang;
        }
        public SoundEffect CreateBackgroundMusic()
        {
            
            return background_music;
        }
        public SoundEffect CreateBombBlow()
        {
            soundInstance = bomb_blow.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            
            return bomb_blow;
        }
        public SoundEffect CreateBombDrop()
        {
            soundInstance = bomb_drop.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return bomb_drop;
        }
        public SoundEffect CreateBossScream()
        {
            soundInstance = boss_scream.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return boss_scream;
        }
        public SoundEffect CreateCandle()
        {
            soundInstance = candle.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return candle;
        }
        public SoundEffect CreateDoorUnlock()
        {
            soundInstance = door_unlock.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return door_unlock;
        }
        public SoundEffect CreateEnemyDeath()
        {
            soundInstance = enemy_die.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return enemy_die;
        }
        public SoundEffect CreateEnemyHit()
        {
            soundInstance = enemy_hit.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return enemy_hit;
        }
        public SoundEffect CreateFanfare()
        {
            soundInstance = fanfare.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return fanfare;
        }
        public SoundEffect CreateHeart()
        {
            soundInstance = get_heart.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return get_heart;
        }
        public SoundEffect CreateItem()
        {
            soundInstance = get_item.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return get_item;
        }
        public SoundEffect CreateRupee()
        {
            soundInstance = get_rupee.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return get_rupee;
        }
        public SoundEffect CreateKey()
        {
            soundInstance = get_key.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return get_key;
        }
        public SoundEffect CreateLinkDeath()
        {
            soundInstance = link_death.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return link_death;
        }
        public SoundEffect CreateLinkHurt()
        {
            soundInstance = link_hurt.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return link_hurt;
        }
        public SoundEffect CreateLowHealth()
        {
            soundInstance = low_health.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return low_health;
        }
        public SoundEffect CreateSecret()
        {
            soundInstance = get_secret.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return get_secret;
        }
        public SoundEffect CreateStairs()
        {
            soundInstance = stairs.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return stairs;
        }
        public SoundEffect CreateSwordShoot()
        {
            soundInstance = sword_shoot.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return sword_shoot;
        }
        public SoundEffect CreateSwordSlash()
        {
            soundInstance = sword_slash.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return sword_slash;
        }
        public SoundEffect CreateText()
        {
            soundInstance = text.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return text;
        }


    }
}
