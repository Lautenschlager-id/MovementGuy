using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementGuy
{
    static class Enums
    {
        public enum Facing
        {
            Right,
            Left
        }

        public enum CharacterState
        {
            breathing,
            movingLeft,
            movingRight,
            duckingLeft,
            duckingRight,
            jumping,
            falling
        }
    }
}
