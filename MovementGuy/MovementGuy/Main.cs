using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MovementGuy
{
    public class Main : Game
    {
        public const float UpdateRate = 1 / 60;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        CharacterManager character;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            character = new CharacterManager();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Sprites.LoadContent(Content);
        }

        protected override void UnloadContent(){}

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Control.Update(gameTime);
            character.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
            character.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
