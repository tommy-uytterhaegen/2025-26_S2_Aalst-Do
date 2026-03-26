using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Core.Graphics;
using SurfingPikachu.Extensions;
using SurfingPikachu.Factories;
using SurfingPikachu.Objects;

namespace SurfingPikachu.States
{
    public class PlayingState : AbstractState
    {
        public PlayingState(GameContext context) 
            : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {
            // Enemy Spawn Logic
            // TODO: Maak hiervoor een 'EnemySpawner'
            Context._elapsedSinceLastSpawnInMs += gameTime.ElapsedGameTime.Milliseconds;
            if (Context._elapsedSinceLastSpawnInMs >= 3000)
            {
                Context._enemySharks.Add(SharkFactory.CreateBig(Context.AssetsManager.GetTexture(AssetNames.EnemyTexture),
                                                                x: GraphicsFacade.GetWindowWidth(),
                                                                y: GraphicsFacade.GetWindowVerticalCenter()));

                Context._elapsedSinceLastSpawnInMs = 0;
            }

            // TODO: Zet background om naar de Sprite class
            // Scrolling Background
            Context._backgroundPosition.X -= Constants.BACKGROUND_SPEED;

            // Moving the enemies
            foreach (var shark in Context._enemySharks)
                shark.Update();

            Context._player.Update();

            // Checking if the player wants to pause
            if (WasKeyJustPressed(Keys.P))
                Context.ChangeState(new PausedState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Context.AssetsManager.GetTexture(AssetNames.BackgroundTexture), 
                             Context._backgroundPosition,
                             Constants.BACKGROUND_SCALE);

            foreach (var shark in Context._enemySharks)
                shark.Draw(spriteBatch);

            Context._player.Draw(spriteBatch);
        }

    }
}
