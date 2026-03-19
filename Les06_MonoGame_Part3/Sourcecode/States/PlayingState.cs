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
        public PlayingState(Game1 context) 
            : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {
            // Enemy Spawn Logic
            Context._elapsedSinceLastSpawnInMs += gameTime.ElapsedGameTime.Milliseconds;
            if (Context._elapsedSinceLastSpawnInMs >= 3000)
            {
                Context._enemySharks.Add(SharkFactory.CreateBig(Context._enemySharkTexture,
                                                             x: GraphicsFacade.GetWindowWidth(),
                                                             y: GraphicsFacade.GetWindowVerticalCenter()));

                Context._elapsedSinceLastSpawnInMs = 0;
            }

            // Scrolling Background
            Context._backgroundPosition.X -= Game1.BACKGROUND_SPEED;

            // Moving the enemies
            foreach (var shark in Context._enemySharks)
                shark.ChangePositionX(-Game1.ENEMY_SHARK_SPEED);

            // Player input
            if (ShouldGoRight())
                Context._player.ChangePositionX( + Game1.PLAYER_SPEED);

            if (ShouldGoLeft())
                Context._player.ChangePositionX( - Game1.PLAYER_SPEED);

            if (ShouldGoUp())
                Context._player.ChangePositionY( - Game1.PLAYER_SPEED);

            if (ShouldGoDown())
                Context._player.ChangePositionY( + Game1.PLAYER_SPEED);

            // Checking if the player wants to pause
            if (WasKeyJustPressed(Keys.P))
                Context.ChangeState(new PausedState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Context._backgroundTexture, Context._backgroundPosition, Game1.BACKGROUND_SCALE);

            foreach (var shark in Context._enemySharks)
                shark.Draw(spriteBatch);

            Context._player.Draw(spriteBatch);
        }

        private bool ShouldGoUp()
            => IsKeyDown(Keys.Up, Keys.Z);

        private bool ShouldGoDown()
            => IsKeyDown(Keys.Down, Keys.S);

        private bool ShouldGoRight()
            => IsKeyDown(Keys.Right, Keys.D);

        private bool ShouldGoLeft()
            => IsKeyDown(Keys.Left, Keys.Q);

    }
}
