using Microsoft.Xna.Framework.Input;
using SurfingPikachu.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Input
{
    public interface IPlayerInputService
    {
        public bool ShouldGoUp();
        public bool ShouldGoDown();
        public bool ShouldGoRight();
        public bool ShouldGoLeft();
    }
}
