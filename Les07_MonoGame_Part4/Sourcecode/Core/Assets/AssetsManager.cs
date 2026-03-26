using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SurfingPikachu.Core.Assets
{
    public class AssetsManager
    {
        private ContentManager ContentManager { get; init; }

        private Dictionary<string, Texture2D> _textures;
        private Dictionary<string, SpriteFont> _fonts;

        public AssetsManager(Game game)
        {
            ContentManager = game.Content;

            _textures = new Dictionary<string, Texture2D>();
            _fonts = new Dictionary<string, SpriteFont>();
        }

        public Texture2D GetTexture(string name)
        {
            if ( ! _textures.TryGetValue(name, out var texture))
            {
                texture = ContentManager.Load<Texture2D>(name);
                _textures.Add(name, texture);
            }

            return texture;
        }

        public SpriteFont GetFont(string name)
        {
            if (!_fonts.TryGetValue(name, out var font))
            {
                font = ContentManager.Load<SpriteFont>(name);
                _fonts.Add(name, font);
            }

            return font;
        }
    }
}
