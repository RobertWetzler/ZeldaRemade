namespace Project
{
    public class Health
    {
        private int currentHealth;
        private int maxHealth;

        public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }

        public Health(int maxHealth)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
        }

        public void AddHealth(int value)
        {
            if (currentHealth <= (maxHealth - value))
            {
                currentHealth += value;
            }
            else
            {
                currentHealth = maxHealth;
            }
        }

        public void UpdateMaxHealth(int value)
        {
            maxHealth += value;
            currentHealth += value;
        }

        public void DecreaseHealth(int value)
        {
            currentHealth -= value;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }
    }
}
