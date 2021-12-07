using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Project.Sound
{
    public class SoundManager
    {
        private SoundEffect arrow_boomerang;
        private SoundEffect background_music;
        private SoundEffect bomb_blow;
        private SoundEffect bomb_drop;
        private SoundEffect boss_scream;
        private SoundEffect candle;
        private SoundEffect door_unlock;
        private SoundEffect enemy_die;
        private SoundEffect enemy_hit;
        private SoundEffect fanfare;
        private SoundEffect get_heart;
        private SoundEffect get_item;
        private SoundEffect get_rupee;
        private SoundEffect get_key;
        private SoundEffect link_death;
        private SoundEffect link_hurt;
        private SoundEffect low_health;
        private SoundEffect get_secret;
        private SoundEffect stairs;
        private SoundEffect sword_shoot;
        private SoundEffect sword_slash;
        private SoundEffect text;
        private SoundEffect title;
        private SoundEffect victory;
        private SoundEffect magical;
        public SoundEffectInstance backgroundInstance;
        public SoundEffectInstance titleInstance;
        public SoundEffectInstance soundInstance;
        public static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }
        private SoundManager()
        {
        }

        public void LoadAllSounds(ContentManager soundFile)
        {
            arrow_boomerang = soundFile.Load<SoundEffect>("Sound/LOZ_Arrow_Boomerang");
            background_music = soundFile.Load<SoundEffect>("Sound/LOZ_Background_Music");
            backgroundInstance = background_music.CreateInstance();
            backgroundInstance.IsLooped = true;
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
            title = soundFile.Load<SoundEffect>("Sound/LOZ_Title");
            victory = soundFile.Load<SoundEffect>("Sound/LOZ_Victory");
            magical = soundFile.Load<SoundEffect>("Sound/LOZ_Magical");
            titleInstance = title.CreateInstance();
            titleInstance.IsLooped = true;
        }

        public void CreateArrowBoomerangSound()
        {
            soundInstance = arrow_boomerang.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();

        }
        public void CreateBackgroundMusic()
        {
            titleInstance.Stop();
            if (backgroundInstance.State != SoundState.Playing)
            {
                backgroundInstance.Play();
            }
        }
        public void CreateBombBlowSound()
        {
            soundInstance = bomb_blow.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();

        }
        public void CreateBombDropSound()
        {
            soundInstance = bomb_drop.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateBossScream()
        {
            soundInstance = boss_scream.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();

        }
        public void CreateCandleSound()
        {
            soundInstance = candle.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateDoorUnlockSound()
        {
            soundInstance = door_unlock.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateEnemyDeathSound()
        {
            soundInstance = enemy_die.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateEnemyHitSound()
        {
            soundInstance = enemy_hit.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateFanfare()
        {
            soundInstance = fanfare.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateHeartSound()
        {
            soundInstance = get_heart.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateItemSound()
        {
            soundInstance = get_item.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateRupeeSound()
        {
            soundInstance = get_rupee.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateKeySound()
        {
            soundInstance = get_key.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateLinkDeathSound()
        {
            soundInstance = link_death.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateLinkHurtSound()
        {
            soundInstance = link_hurt.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public SoundEffect CreateLowHealthSound()
        {
            soundInstance = low_health.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
            return low_health;
        }
        public void CreateSecretSound()
        {
            soundInstance = get_secret.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateStairsSound()
        {
            soundInstance = stairs.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateSwordShootSound()
        {
            soundInstance = sword_shoot.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateSwordSlashSound()
        {
            soundInstance = sword_slash.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateTextSound()
        {
            soundInstance = text.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateTitleSound()
        {
            backgroundInstance.Stop();
            if (titleInstance.State != SoundState.Playing)
            {
                titleInstance.Play();
            }
        }

        public void CreateVictorySound()
        {
            backgroundInstance.Stop();
            soundInstance = victory.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        public void CreateMagicalSound()
        {
            soundInstance = magical.CreateInstance();
            soundInstance.IsLooped = false;
            soundInstance.Play();
        }
        
    }
}
