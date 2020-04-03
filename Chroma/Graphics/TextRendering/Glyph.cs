﻿namespace Chroma.Graphics.TextRendering
{
    public struct Glyph
    {
        public Vector2 Position { get; internal set; }
        public Vector2 Size { get; internal set; }
        public Vector2 BitmapCoordinates { get; internal set; }
        public Vector2 Bearing { get; internal set; }

        public int Advance { get; internal set; }
    }
}
