using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurfingPikachu.Core.Objects;
using SurfingPikachu.Input;
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
        private readonly IPlayerInputService _inputService;

        public PlayerSprite(Texture2D texture, Vector2 position, float speed, IPlayerInputService inputService) 
            : base(texture, position, NO_SCALE, speed)
        {
            _inputService = inputService;
        }

        public override void Update()
        {
            // Player input
            if (_inputService.ShouldGoRight())
                ChangePositionX(+ Speed);

            if (_inputService.ShouldGoLeft())
                ChangePositionX(-Speed);

            if (_inputService.ShouldGoUp())
                ChangePositionY(-Speed);

            if (_inputService.ShouldGoDown())
                ChangePositionY(+Speed);

        }
    }
}
