using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MovementGuy
{
    static class Sprites
    {
        public static Texture2D c_breathing { get; private set; }
        public static Texture2D c_movingRight { get; private set; }
        public static Texture2D c_movingLeft { get; private set; }
        public static Texture2D c_duckingRight { get; private set; }
        public static Texture2D c_duckingLeft { get; private set; }
        public static Texture2D c_jumping { get; private set; }
        public static Texture2D c_falling { get; private set; }


        public static void LoadContent(ContentManager content)
        {
            c_breathing  = content.Load<Texture2D>("Sprites/Character/breathing");
            c_movingRight = content.Load<Texture2D>("Sprites/Character/movingRight");
            c_movingLeft = content.Load<Texture2D>("Sprites/Character/movingLeft");
            c_duckingRight = content.Load<Texture2D>("Sprites/Character/duckingRight");
            c_duckingLeft = content.Load<Texture2D>("Sprites/Character/duckingLeft");
            c_jumping = content.Load<Texture2D>("Sprites/Character/jumping");
            c_falling = content.Load<Texture2D>("Sprites/Character/falling");
        }
    }
}
