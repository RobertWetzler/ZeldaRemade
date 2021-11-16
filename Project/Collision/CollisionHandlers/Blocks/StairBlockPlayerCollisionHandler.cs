namespace Project.Collision.CollisionHandlers.Blocks
{
    class StairBlockPlayerCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable stairCollidable, ICollidable playerCollidable, CollisionSide side)
        {
            Game1.Instance.GameStateMachine.RoomTransition(GameState.Direction.Left);
        }
    }
}
