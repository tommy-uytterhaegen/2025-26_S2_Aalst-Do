using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Input
{
    public class PlayerInputService 
        : IPlayerInputService
    {
        public bool ShouldGoUp()
            => KeyboardFacade.IsKeyDown(Keys.Up, Keys.Z);

        public bool ShouldGoDown()
            => KeyboardFacade.IsKeyDown(Keys.Down, Keys.S);

        public bool ShouldGoRight()
            => KeyboardFacade.IsKeyDown(Keys.Right, Keys.D);

        public bool ShouldGoLeft()
            => KeyboardFacade.IsKeyDown(Keys.Left, Keys.Q);

    }
}
