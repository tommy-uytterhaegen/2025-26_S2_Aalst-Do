using SurfingPikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Strategies
{
    internal class FastHorizontalMovementStrategy
        : ISharkMovementStrategy
    {
        public void Update(SharkSprite shark)
        {
            shark.ChangePositionX(-1.5F * shark.Speed);
        }
    }
}
