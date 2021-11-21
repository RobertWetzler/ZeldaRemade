using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Sprites;
using Project.Utilities;

namespace Project.Factory
{
    public class DoorSpriteFactory
    {
        private Texture2D doorSpriteSheet;
        private Texture2D doorMaskSpriteSheet;


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
            doorMaskSpriteSheet = content.Load<Texture2D>("Room/doorMasks");
        }

        public ISprite CreateNorthDoorSprite(DoorType doorType, Vector2 position)
        {
            return new DoorSprite(doorSpriteSheet, doorMaskSpriteSheet, doorType, 0, 5, 4, position);
        }

        public ISprite CreateEastDoorSprite(DoorType doorType, Vector2 position)
        {
            return new DoorSprite(doorSpriteSheet, doorMaskSpriteSheet, doorType, 2, 5, 4, position);
        }

        public ISprite CreateSouthDoorSprite(DoorType doorType, Vector2 position)
        {
            return new DoorSprite(doorSpriteSheet, doorMaskSpriteSheet, doorType, 3, 5, 4, position);
        }

        public ISprite CreateWestDoorSprite(DoorType doorType, Vector2 position)
        {
            return new DoorSprite(doorSpriteSheet, doorMaskSpriteSheet, doorType, 1, 5, 4, position);
        }

    }
}
