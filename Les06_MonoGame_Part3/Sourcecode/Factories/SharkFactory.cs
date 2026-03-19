using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurfingPikachu.Core.Graphics;
using SurfingPikachu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Factories
{
    public static class SharkFactory
    {
        public static SharkSprite CreateBig(Texture2D texture, float x, float y)
        {
            return Create(texture, Game1.ENEMY_SHARK_SCALE, new Vector2(x, y));
        }

        public static SharkSprite Create(Texture2D texture, float scale, float x, float y)
        {
            return Create(texture, scale, new Vector2(x, y));
        }

        public static SharkSprite Create(Texture2D texture, float scale, Vector2 position)
        {
            return new SharkSprite(texture, position, scale);
        }
    }
}
