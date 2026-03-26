using SurfingPikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Strategies
{
    public interface ISharkMovementStrategy
    {
        public void Update(SharkSprite shark);
    }
}
