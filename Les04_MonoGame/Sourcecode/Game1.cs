using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Extensions;
using System.Collections.Generic;

namespace SurfingPikachu
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _pikachuTexture;
        private Vector2 _pikachuPosition;

        private Texture2D _backgroundTexture;
        private Vector2 _backgroundPosition;

        private Texture2D _sharkTexture;
        private List<Vector2> _sharkPositions;

        private int _elapsedSinceLastSpawnInMs;

        private const int PLAYER_SPEED = 5;
        private const int BACKGROUND_SPEED = 2;
        private const int SHARK_SPEED = 3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _pikachuPosition = new Vector2(0, 0);
            _backgroundPosition = new Vector2(0, 0);
            _sharkPositions = new List<Vector2>();
            _elapsedSinceLastSpawnInMs = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pikachuTexture = Content.Load<Texture2D>("surfing-pikachu");
            _backgroundTexture = Content.Load<Texture2D>("water");
            _sharkTexture = Content.Load<Texture2D>("haai");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _elapsedSinceLastSpawnInMs += gameTime.ElapsedGameTime.Milliseconds;
            if (_elapsedSinceLastSpawnInMs >= 3000)
            {
                _sharkPositions.Add(new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight / 2));
                _elapsedSinceLastSpawnInMs = 0;
            }
            _backgroundPosition.X -= BACKGROUND_SPEED;

            for ( var i = 0; i < _sharkPositions.Count; i++)
                _sharkPositions[i] = new Vector2(_sharkPositions[i].X - SHARK_SPEED, _sharkPositions[i].Y);

            if (ShouldGoRight())
                _pikachuPosition.X += PLAYER_SPEED;

            if (ShouldGoLeft())
                _pikachuPosition.X -= PLAYER_SPEED;

            if (ShouldGoUp())
                _pikachuPosition.Y -= PLAYER_SPEED;

            if (ShouldGoDown())
                _pikachuPosition.Y += PLAYER_SPEED;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_backgroundTexture, _backgroundPosition, 0.25F);

            foreach (var sharkPosition in _sharkPositions)
                _spriteBatch.Draw(_sharkTexture, sharkPosition, 0.25F);

            _spriteBatch.Draw(_pikachuTexture, _pikachuPosition);
            _spriteBatch.End();

            base.Draw(gameTime);
        }


















        private bool ShouldGoUp()
            => IsKeyDown(Keys.Up, Keys.Z);

        private bool ShouldGoDown()
            => IsKeyDown(Keys.Down, Keys.S);

        private bool ShouldGoRight()
            => IsKeyDown(Keys.Right, Keys.D);

        private bool ShouldGoLeft()
            => IsKeyDown(Keys.Left, Keys.Q);


        private bool IsKeyDown(Keys key1, Keys key2)
        {
            return IsKeyDown(key1) || IsKeyDown(key2);
        }

        private bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }

    }
}
