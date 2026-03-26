using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurfingPikachu.Core.Assets;
using SurfingPikachu.Input;
using SurfingPikachu.States;
using System.Collections.Generic;

namespace SurfingPikachu.Objects
{
    public class GameContext
    {
        public AbstractState _currentState;

        public PlayerSprite _player;
        public Vector2 _backgroundPosition;

        public List<SharkSprite> _enemySharks;

        public AssetsManager AssetsManager;

        public int _elapsedSinceLastSpawnInMs;
    
        public GameContext(Game game)
        {
            _currentState = new MenuState(this);

            _backgroundPosition = new Vector2(0, 0);
            _enemySharks = new List<SharkSprite>();
            _elapsedSinceLastSpawnInMs = 0;

            AssetsManager = new AssetsManager(game);

            // TODO: Maak hiervoor een Factory
            _player = new PlayerSprite(AssetsManager.GetTexture(AssetNames.PlayerTexture),
                                       Vector2.Zero,
                                       Constants.PLAYER_SPEED,
                                       new PlayerInputService());
        }

        public void ChangeState(AbstractState newState)
        {
            _currentState = newState;
        }

        public void Update(GameTime gameTime)
        {
            _currentState.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _currentState.Draw(gameTime, spriteBatch);
        }
    }
}
