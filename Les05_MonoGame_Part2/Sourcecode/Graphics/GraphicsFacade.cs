using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Graphics
{
    public static class GraphicsFacade
    {
        private static GraphicsDeviceManager _graphics;

        public static void Initialize(Game game)
        {
            _graphics = new GraphicsDeviceManager(game);
        }

        public static int GetScreenWidth()
        {
            return _graphics.PreferredBackBufferWidth;
        }

        public static float GetScreenHeight()
        {
            return _graphics.PreferredBackBufferHeight;
        }

        public static float GetScreenYCenter()
        {
            return _graphics.PreferredBackBufferHeight * 0.5f;
        }
    }
}
