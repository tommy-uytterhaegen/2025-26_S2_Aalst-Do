using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Core.Input;
using SurfingPikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.States
{
    public abstract class AbstractState
    {
        // We gebruiken de Game1 klasse als 'Context', dit gaan we nog afsplitsen in een aparte klasse zodat we niet zo afhankelijk zijn van de Game1 klasse.
        protected GameContext Context { get; init; }

        public AbstractState(GameContext context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);


        // Basis methoden die voor elke state wel nuttig kunnen zijn
        protected bool IsKeyDown(Keys key1, Keys key2)
        {
            return IsKeyDown(key1) || IsKeyDown(key2);
        }

        protected bool IsKeyDown(Keys key)
        {
            return KeyboardFacade.IsKeyDown(key);
        }

        protected bool WasKeyJustPressed(Keys key)
        {
            return KeyboardFacade.WasKeyJustPressed(key);
        }
    }
}
