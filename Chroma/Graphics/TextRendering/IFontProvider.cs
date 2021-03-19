using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Microsoft.Win32.SafeHandles;

namespace Chroma.Graphics.TextRendering
{
    public interface IFontProvider<T>
    {
        string FileName { get; }

        int Ascent { get; }
        int Descent { get; }
        
        int Height { get; }
        int LineSpacing { get; }
        bool UseKerning { get; set; }
        
        Dictionary<char, T> Glyphs { get; }

        bool HasGlyph(char c);
        Size Measure(string s);

        Vector2 GetKerning(char c1, char c2);
        Texture GetTexture(char c = (char)0);
    }
}