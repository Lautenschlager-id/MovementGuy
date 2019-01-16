using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovementGuy
{
    public class SpriteHandler
    {
        private Dictionary<Enum, SpriteObj> structure;
        private Point dimension;
        private Rectangle spriteLocation;

        private int frame = 0;
        private int stateTimer = 0;

        private Enum currentState;
        public Enum lastState;
        public Enum CurrentState
        {
            get => currentState;
            set
            {
                if (value.Equals(currentState)) return;
                frame = 0;
                stateTimer = 0;
                spriteLocation.X = 0;

                lastState = currentState;
                currentState = value;
            }
        }

        public SpriteHandler(Dictionary<Enum, SpriteObj> structure, Point dimension)
        {
            this.structure = structure;
            this.dimension = dimension;

            lastState = currentState = structure.Keys.First();
            spriteLocation = new Rectangle(0, 0, dimension.X, dimension.Y);
        }

        public Texture2D getSprite()
        {
            return structure[currentState].Texture;
        }
        public Rectangle getSpriteRegion()
        {
            return spriteLocation;
        }

        public void Update(GameTime t)
        {
            if (structure[currentState].Frames == 0) return;

            stateTimer++;
            if (stateTimer >= structure[currentState].Speed)
            {
                stateTimer = 0;
                spriteLocation.X = (++frame % structure[currentState].Frames) * dimension.X;
            }
        }
    }
}
