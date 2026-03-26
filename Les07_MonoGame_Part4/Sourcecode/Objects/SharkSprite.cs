using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurfingPikachu.Core.Objects;
using SurfingPikachu.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Objects
{
    public class SharkSprite : Sprite
    {
        private ISharkMovementStrategy MovementStrategy { get; init;  }

        public SharkSprite(Texture2D texture, Vector2 position, float scale, float speed, ISharkMovementStrategy movementStrategy) 
            : base(texture, position, scale, speed)
        {
            MovementStrategy = movementStrategy;
        }

        public override void Update()
        {
            MovementStrategy.Update(this);
        }
    }
}
