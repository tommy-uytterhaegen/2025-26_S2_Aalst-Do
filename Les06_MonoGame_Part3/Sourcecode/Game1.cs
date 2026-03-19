using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Core.Graphics;
using SurfingPikachu.Core.Input;
using SurfingPikachu.Objects;
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

        // TODO: Maak een AssetManager die het laden van assets voor ons doet. Deze zal ook elke asset maar 1x inladen.
        //       Als hij een asset (Texture, Font, ...) al eens geladen heeft dan moet hij dezelfde instantie geven (denk dictionary)

        // BEGIN: TIJDELIJKE oplossing om assets te delen tussen states. We gaan dit later refactoren naar een betere oplossing.
        // TIJDELIJK !!! DIT IS NIET OK
        public PlayerSprite _player;
        public Texture2D _playerTexture;
        //public Vector2 _playerPosition;

        public Texture2D _backgroundTexture;
        public Vector2 _backgroundPosition;

        public Texture2D _enemySharkTexture;
        public List<SharkSprite> _enemySharks;

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

            _backgroundPosition = new Vector2(0, 0);
            _enemySharks = new List<SharkSprite>();
            _elapsedSinceLastSpawnInMs = 0;

            base.Initialize();

            _player = new PlayerSprite(_playerTexture, Vector2.Zero);
            
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
            KeyboardFacade.Update();

            if (KeyboardFacade.IsKeyDown(Keys.Escape))
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
