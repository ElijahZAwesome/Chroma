using System.Numerics;

namespace Chroma.Input;

public class GestureEventArgs
{
    public TouchDevice Device { get; }
    public Vector2 Position => Touch.TransformRawFingerVector(RawPosition, Device.Type);
    public Vector2 RawPosition { get; }
    public float RotationDelta => Touch.TransformRawFingerValue(RawRotationDelta, Device.Type);
    public float RawRotationDelta { get; }
    public float DistanceDelta => Touch.TransformRawFingerValue(RawDistanceDelta, Device.Type);
    public float RawDistanceDelta { get; }
    public int FingerCount { get; }

    public GestureEventArgs(long deviceId, Vector2 pos, float theta, float dist, int numFingers)
    {
        Device = new TouchDevice(deviceId);
        RawPosition = pos;
        RawRotationDelta = theta;
        RawDistanceDelta = dist;
        FingerCount = numFingers;
    }
}