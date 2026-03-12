using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Graphics;
using SurfingPikachu.States;
using System.Collections.Generic;

namespace SurfingPikachu
{
    public class Game1 : Game
    {
        public const int PLAYER_SPEED = 5;

        public const int BACKGROUND_SPEED = 2;
        public const float BACKGROUND_SCALE = 0.25F;

        public const int ENEMY_SHARK_SPEED = 3;
        public const float ENEMY_SHARK_SCALE = 0.25F;

        private AbstractState _currentState;

        private SpriteBatch _spriteBatch;

        // BEGIN: TIJDELIJKE oplossing om assets te delen tussen states. We gaan dit later refactoren naar een betere oplossing.
        // TIJDELIJK !!! DIT IS NIET OK
        public Texture2D _playerTexture;
        public Vector2 _playerPosition;

        public Texture2D _backgroundTexture;
        public Vector2 _backgroundPosition;

        public Texture2D _enemySharkTexture;
        public List<Vector2> _enemySharkPositions;

        public SpriteFont _spriteFont;

        public int _elapsedSinceLastSpawnInMs;
        // END: TIJDELIJK

        public void ChangeState(AbstractState newState)
        {
            _currentState = newState;
        }   

        public Game1()
        {
            GraphicsFacade.Initialize(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            _currentState = new MenuState(this);
            
            _playerPosition = new Vector2(0, 0);
            _backgroundPosition = new Vector2(0, 0);
            _enemySharkPositions = new List<Vector2>();
            _elapsedSinceLastSpawnInMs = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerTexture = Content.Load<Texture2D>("surfing-pikachu");
            _backgroundTexture = Content.Load<Texture2D>("water");
            _enemySharkTexture = Content.Load<Texture2D>("haai");

            _spriteFont = Content.Load<SpriteFont>("game-font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // We roepen de Update method op van de huidige state aan, zodat deze zelf kan bepalen wat er moet gebeuren.
            _currentState.Update(gameTime);
 
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // We roepen de Draw method op van de huidige state aan, zodat deze zelf kan bepalen wat er moet gebeuren.
            _currentState.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
