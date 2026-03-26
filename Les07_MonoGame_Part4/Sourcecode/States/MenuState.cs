using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Objects;

namespace SurfingPikachu.States
{
    internal class MenuState : AbstractState
    {
        public MenuState(GameContext context) 
            : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.Enter))
                Context.ChangeState(new PlayingState(Context));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetNames.GameFont), 
                                   "Druk enter om te beginnen", 
                                   Vector2.Zero, 
                                   Color.White);
        }

    }
}
