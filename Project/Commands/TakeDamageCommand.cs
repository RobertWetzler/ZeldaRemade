namespace Project
{
    class TakeDamageCommand : ICommand
    {
        private Game1 game;

        public TakeDamageCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
