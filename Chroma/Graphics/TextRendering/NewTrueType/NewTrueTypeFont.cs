using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Chroma.STB.TrueType;

namespace Chroma.Graphics.TextRendering.NewTrueType
{
    public class NewTrueTypeFont : IFontProvider<NewTrueTypeGlyph>
    {
        private readonly byte[] _ttfData;
        private readonly Texture _texture;
        private readonly FontInfo _fontInfo = new();
        
        public string FileName { get; }
        
        public int Height { get; private set; }
        public int LineSpacing { get; private set; }
        
        public bool UseKerning { get; set; }

        public Dictionary<char, NewTrueTypeGlyph> Glyphs { get; } = new();

        public NewTrueTypeFont(string fileName)
            : this(new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            FileName = fileName;
        }

        public NewTrueTypeFont(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream), "Stream provided was null.");

            using var ms = new MemoryStream();
            stream.CopyTo(ms);

            _ttfData = ms.ToArray();
            
            
            InitializeFontData();
        }
        
        public bool HasGlyph(char c)
        {
            throw new System.NotImplementedException();
        }

        public Size Measure(string s)
        {
            throw new System.NotImplementedException();
        }

        public Texture GetTexture(char c = '\0')
            => _texture;

        private void InitializeFontData()
        {
            _fontInfo.stbtt_InitFont(_ttfData, 0);
            
        }
    }
}