using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Core.Graphics
{
    public static class GraphicsFacade
    {
        private static GraphicsDeviceManager _graphics;

        public static void Initialize(Game game)
        {
            _graphics = new GraphicsDeviceManager(game);
        }

        public static int GetWindowWidth()
        {
            return _graphics.PreferredBackBufferWidth;
        }

        public static float GetWindowHeight()
        { 
            return _graphics.PreferredBackBufferHeight;
        }

        public static float GetWindowVerticalCenter()
        {
            return _graphics.PreferredBackBufferHeight * 0.5f;
        }
    }
}
