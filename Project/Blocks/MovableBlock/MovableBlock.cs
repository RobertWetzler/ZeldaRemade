using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.Blocks.MovableBlock
{
    class MovableBlock: IBlock
    {
        private ISprite sprite;
        private Vector2 position;
        private MovingBlockState currentState;
        public bool IsMovable => currentState == null;


        public MovableBlock(Vector2 position)
        {
            this.position = position;
            sprite = BlockSpriteFactory.Instance.CreatePyramidBlockSprite();
            currentState = null;
        }

        public Rectangle BoundingBox => sprite.DestRectangle;
        public Vector2 Position { get => position; set => position = value; }

        public void MoveBlock(MovingDir dir)
        {
            if(this.currentState is null)
            {
                this.currentState = new MovingBlockState(this, dir);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
            if (this.currentState != null)
            {
                this.currentState.Update(gameTime);
            }
            sprite.Update(gameTime);
        }
    }
}
