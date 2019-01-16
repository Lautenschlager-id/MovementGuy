using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MovementGuy
{
    class CharacterManager
    {
        private static Dictionary<Enum, SpriteObj> structure = new Dictionary<Enum, SpriteObj>();
        private static Point dimension = new Point(130, 270);

        static CharacterManager()
        {
            structure.Add(Enums.CharacterState.breathing, new SpriteObj() {
                Texture = Sprites.c_breathing,
                Frames = 2,
                Speed = 30
            });
            structure.Add(Enums.CharacterState.movingLeft, new SpriteObj() {
                Texture = Sprites.c_movingLeft,
                Frames = 2,
                Speed = 15
            });
            structure.Add(Enums.CharacterState.movingRight, new SpriteObj() {
                Texture = Sprites.c_movingRight,
                Frames = 2,
                Speed = 15
            });
            structure.Add(Enums.CharacterState.duckingLeft, new SpriteObj() {
                Texture = Sprites.c_duckingLeft,
                Frames = 2,
                Speed = 30
            });
            structure.Add(Enums.CharacterState.duckingRight, new SpriteObj() {
                Texture = Sprites.c_duckingRight,
                Frames = 2,
                Speed = 30
            });
            structure.Add(Enums.CharacterState.jumping, new SpriteObj()
            {
                Texture = Sprites.c_jumping,
                Frames = 1
            });
            structure.Add(Enums.CharacterState.falling, new SpriteObj()
            {
                Texture = Sprites.c_falling,
                Frames = 1
            });
        }
        
        private static float speed = 1.4f;
        private float lastGroundY;

        SpriteHandler spriteHandler = new SpriteHandler(structure, dimension);
        
        private static Keys[] controlKeys = new Keys[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down };

        private Vector2 position;
        private Enums.Facing facingDir;

        public CharacterManager()
        {
            position = new Vector2(5, lastGroundY = 150);
            facingDir = Enums.Facing.Right;
        }

        private double iniVelocity = -300, jumpingTime = 0;
        private double G = 600;
        private bool isJumping = false, isFalling = false;

        public void Update(GameTime t)
        {
            Vector2 dir = Vector2.Zero;

            if (!isJumping && Control.HoldingKey(controlKeys[2]))
            {
                spriteHandler.CurrentState = Enums.CharacterState.jumping;
                isJumping = true;
            }
            if (Control.HoldingKey(controlKeys[0]))
            {
                dir.X -= speed;
                facingDir = Enums.Facing.Left;
                if (!isJumping)
                    spriteHandler.CurrentState = Enums.CharacterState.movingLeft;
            }
            else if (Control.HoldingKey(controlKeys[1]))
            {
                dir.X += speed;
                facingDir = Enums.Facing.Right;
                if (!isJumping)
                    spriteHandler.CurrentState = Enums.CharacterState.movingRight;
            }
            else if (!isJumping)
            {
                if (Control.HoldingKey(controlKeys[3]))
                    spriteHandler.CurrentState = (facingDir == Enums.Facing.Right) ? Enums.CharacterState.duckingRight : Enums.CharacterState.duckingLeft;
                else
                    spriteHandler.CurrentState = Enums.CharacterState.breathing;
            }

            if (isJumping)
            {
                if (position.Y > lastGroundY)
                {
                    dir.Y = lastGroundY - position.Y;
                    jumpingTime = 0;
                    isJumping = false;
                    isFalling = false;
                    spriteHandler.CurrentState = Enums.CharacterState.breathing;
                }
                else
                {
                    float oldY = position.Y;
                    position.Y = (float)(iniVelocity * jumpingTime + G * jumpingTime * jumpingTime / 2) + lastGroundY;
                    jumpingTime += t.ElapsedGameTime.TotalSeconds;
                    if (!isFalling && (oldY - position.Y) < 0)
                    {
                        isFalling = true;
                        spriteHandler.CurrentState = Enums.CharacterState.falling;
                    }
                }
            }

            if (dir != Vector2.Zero)
                position += dir;

            spriteHandler.Update(t);
        }

        public void Draw(SpriteBatch s)
        {
            s.Draw(spriteHandler.getSprite(), position, spriteHandler.getSpriteRegion(), Color.White);
        }
    }
}
