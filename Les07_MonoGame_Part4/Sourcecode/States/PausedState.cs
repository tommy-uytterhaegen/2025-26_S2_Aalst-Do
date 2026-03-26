using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.States
{
    public class PausedState : AbstractState
    {
        private PlayingState PreviousState { get; }

        public PausedState(GameContext context, PlayingState previousState) 
            : base(context)
        {
            PreviousState = previousState;
        }

        public override void Update(GameTime gameTime)
        {
            if (WasKeyJustPressed(Keys.P))
                Context.ChangeState(PreviousState);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            PreviousState.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetNames.GameFont), 
                                   "Gepauzeerd. Druk enter om te hernemen", 
                                   Vector2.Zero, 
                                   Color.White);
        }

    }
}
