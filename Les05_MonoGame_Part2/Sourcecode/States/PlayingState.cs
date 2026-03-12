using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Extensions;
using SurfingPikachu.Graphics;

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
                Context._enemySharkPositions.Add(new Vector2(GraphicsFacade.GetScreenWidth(), GraphicsFacade.GetScreenYCenter()));
                Context._elapsedSinceLastSpawnInMs = 0;
            }

            // Scrolling Background
            Context._backgroundPosition.X -= Game1.BACKGROUND_SPEED;

            // Moving the enemies
            for (var i = 0; i < Context._enemySharkPositions.Count; i++)
                Context._enemySharkPositions[i] = Context._enemySharkPositions[i] with { X = Context._enemySharkPositions[i].X - Game1.ENEMY_SHARK_SPEED };

            // Player input
            if (ShouldGoRight())
                Context._playerPosition.X += Game1.PLAYER_SPEED;

            if (ShouldGoLeft())
                Context._playerPosition.X -= Game1.PLAYER_SPEED;

            if (ShouldGoUp())
                Context._playerPosition.Y -= Game1.PLAYER_SPEED;

            if (ShouldGoDown())
                Context._playerPosition.Y += Game1.PLAYER_SPEED;

            // Checking if the player wants to pause
            if (IsKeyDown(Keys.P))
                Context.ChangeState(new PausedState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Context._backgroundTexture, Context._backgroundPosition, Game1.BACKGROUND_SCALE);

            foreach (var sharkPosition in Context._enemySharkPositions)
                spriteBatch.Draw(Context._enemySharkTexture, sharkPosition, Game1.ENEMY_SHARK_SCALE);

            spriteBatch.Draw(Context._playerTexture, Context._playerPosition);
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
