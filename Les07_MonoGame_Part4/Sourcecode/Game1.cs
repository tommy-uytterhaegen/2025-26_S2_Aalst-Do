using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Core.Graphics;
using SurfingPikachu.Core.Input;
using SurfingPikachu.Objects;

namespace SurfingPikachu
{
    public class Game1 : Game
    {
        // TODO: Niet alles is volledig uitgewerkt. Het is aan jou om de openstaande zaken te gebruiken om de concepten in te oefenen.
        // TODO: Je kan ook zelf extra zaken verzinnen om het nog beter in je vingers te krijgen. Deze oplossing geef je een goede basis om me te 'spelen'
        private SpriteBatch _spriteBatch;
        private GameContext _gameContext;

        public Game1()
        {
            GraphicsFacade.Initialize(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            _gameContext = new GameContext(this);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardFacade.Update();

            if (KeyboardFacade.IsKeyDown(Keys.Escape))
                Exit();

            _gameContext.Update(gameTime);
 
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _gameContext.Draw(gameTime, _spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
