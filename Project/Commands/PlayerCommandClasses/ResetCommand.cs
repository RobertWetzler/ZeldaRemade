using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class ResetCommand : ICommand
    {
        private Game1 game;

        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            //Reset the lists to show first element in list
            game.CurrentBlockSpriteIndex = 0;
            game.CurrentItemSpriteIndex = 0;
            game.CurrentNPCIndex = 0;
            //Reset player position
            game.Player.StopMoving();
            game.Player.Position = Vector2.Zero;
            game.Player.SetSprite(LinkSpriteFactory.Instance.CreateLinkIdleSprite(Entities.Facing.Right));
        }
    }
}
