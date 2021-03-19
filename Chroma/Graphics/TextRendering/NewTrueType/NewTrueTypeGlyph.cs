using System.Numerics;

namespace Chroma.Graphics.TextRendering.NewTrueType
{
    public class NewTrueTypeGlyph
    {
        public Vector2 Position { get; internal set; }
        public Vector2 Size { get; internal set; }
        
        public int HorizontalAdvance { get; internal set; }
    }
}