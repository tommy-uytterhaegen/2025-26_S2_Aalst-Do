using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurfingPikachu.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Objects
{
    public class PlayerSprite
        : Sprite
    {
        public PlayerSprite(Texture2D texture, Vector2 position) 
            : base(texture, position, NO_SCALE)
        {
        }
    }
}
