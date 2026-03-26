using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurfingPikachu.Objects;
using SurfingPikachu.Strategies;
using System;

namespace SurfingPikachu.Factories
{
    public static class SharkFactory
    {
        public static SharkSprite CreateBig(Texture2D texture, float x, float y)
        {
            return Create(texture, Constants.ENEMY_SHARK_SCALE, new Vector2(x, y));
        }

        public static SharkSprite Create(Texture2D texture, float scale, float x, float y)
        {
            return Create(texture, scale, new Vector2(x, y));
        }

        public static SharkSprite Create(Texture2D texture, float scale, Vector2 position)
        {
            return new SharkSprite(texture, position, scale, Constants.ENEMY_SHARK_SPEED, Random.Shared.Next(3) switch
            {
                0 => new HorizontalSharkMovementStrategy(),
                1 => new DiagonalSharkMovementStrategy(),
                2 => new FastHorizontalMovementStrategy(),
                _ => throw new NotImplementedException()
            });
        }
    }
}
