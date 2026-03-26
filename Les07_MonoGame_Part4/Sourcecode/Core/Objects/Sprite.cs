
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurfingPikachu.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Core.Objects
{
    public abstract class Sprite
    {
        protected const float NO_SCALE = 1f;

        public Texture2D Texture { get; init; }
        public Vector2 Position { get; private set; }
        public float Scale { get; init; }
        public float Speed { get; init; }

        protected Sprite(Texture2D texture, Vector2 position, float scale, float speed)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            Speed = speed;
        }

        public abstract void Update();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Scale);
        }

        public void ChangePosition(float xChange, float yChange)
        {
            Position = new Vector2(Position.X + xChange, Position.Y + yChange);
        }

        public void ChangePositionX(float xChange)
        {
            Position = Position with { X = Position.X + xChange };
        }

        public void ChangePositionY(float yChange)
        {
            Position = new Vector2(Position.X, Position.Y + yChange);
        }
    }
}
