namespace Project.Sprites.PlayerSprites
{
    public interface IPlayerSprite : ISprite
    {
        bool IsFinished
        {
            get;
        }
    }
}