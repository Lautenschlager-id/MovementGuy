using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovementGuy
{
    static class Control
    {
        private static KeyboardState kCurrent, kLast;

        public static bool KeyDown(Keys key)
        {
            return kLast.IsKeyUp(key) && kCurrent.IsKeyDown(key);
        }
        public static bool KeyUp(Keys key)
        {
            return kLast.IsKeyDown(key) && kCurrent.IsKeyUp(key);
        }
        public static bool HoldingKey(Keys key)
        {
            return kCurrent.IsKeyDown(key);
        }

        public static void Update(GameTime t)
        {
            kLast = kCurrent;
            kCurrent = Keyboard.GetState();
        }
    }
}
