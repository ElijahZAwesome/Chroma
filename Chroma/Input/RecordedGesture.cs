using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Chroma.Input;

public class RecordedGesture
{
    internal const uint DOLLARNPOINTS = 64;

    public delegate void GestureCallbackDelegate(long id, float err, int fingers);

    public long Hash => _hash;
    public IReadOnlyCollection<Vector2> Points => InternalPoints;
    public GestureCallbackDelegate Callback { get; set; }
    
    internal List<Vector2> InternalPoints = new((int)DOLLARNPOINTS);

    private long _hash { get; set; }

    public RecordedGesture()
    {
        RegenerateHash();
    }

    public RecordedGesture(GestureCallbackDelegate callback) : this()
    {
        Callback = callback;
    }

    public RecordedGesture(string filePath, GestureCallbackDelegate callback) : this(callback)
    {
        using (var fs = new FileStream(filePath, FileMode.Open))
        {
            ConstructWithStream(fs);
        }
    }

    public RecordedGesture(Stream stream, GestureCallbackDelegate callback) : this(callback)
    {
        ConstructWithStream(stream);
    }

    public RecordedGesture(Vector2[] points, GestureCallbackDelegate callback) : this(callback)
    {
        Array.Copy(points, InternalPoints, DOLLARNPOINTS);
    }

    internal static long HashPoints(Vector2[] points)
    {
        long hash = 5381;
        int i;
        for (i = 0; i < DOLLARNPOINTS; i++)
        {
            hash = ((hash << 5) + hash) + (long)points[i].X;
            hash = ((hash << 5) + hash) + (long)points[i].Y;
        }

        return hash;
    }

    private void RegenerateHash() => _hash = HashPoints(InternalPoints);

    private void ConstructWithStream(Stream stream)
    {
        var vectorSize = (sizeof(float) * 2);
        var buffer = new byte[DOLLARNPOINTS * vectorSize];
        var pointCount = stream.Read(buffer) / vectorSize;
        for (var i = 0; i < pointCount; i++)
        {
            InternalPoints[i] = new Vector2(
                BitConverter.ToSingle(buffer, i * vectorSize),
                BitConverter.ToSingle(buffer, (i * vectorSize) + sizeof(float))
            );
        }
    }

    public Vector2 this[int index]
    {
        get => InternalPoints[index];
        set
        {
            InternalPoints[index] = value;
            RegenerateHash();
        }
    }
}