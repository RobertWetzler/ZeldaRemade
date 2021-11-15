using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;
using Project.Sprites.TextSprites;
using Project.Utilities;

namespace Project.Factory
{
    public class DoorSpriteFactory
    {
        private Texture2D doorSpriteSheet;


        private static DoorSpriteFactory instance = new DoorSpriteFactory();

        public static DoorSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private DoorSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            doorSpriteSheet = content.Load<Texture2D>("Room/doors");
        }

        public ISprite CreateNorthDoorSprite(DoorType doorType)
        {
            return new DoorSprite(doorSpriteSheet, doorType, 0, 5, 4);
        }

        public ISprite CreateEastDoorSprite(DoorType doorType)
        {
            return new DoorSprite(doorSpriteSheet, doorType, 2, 5, 4);
        }

        public ISprite CreateSouthDoorSprite(DoorType doorType)
        {
            return new DoorSprite(doorSpriteSheet, doorType, 3, 5, 4);
        }

        public ISprite CreateWestDoorSprite(DoorType doorType)
        {
            return new DoorSprite(doorSpriteSheet, doorType, 1, 5, 4);
        }

    }
}
