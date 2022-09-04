using System.Numerics;

namespace Chroma.Input
{
    public class TouchEventArgs
    {
        public TouchDevice Device { get; }
        public long FingerId { get; }
        public Vector2 Position => Touch.TransformRawFingerVector(RawPosition, Device.Type);
        public Vector2 RawPosition { get; }
        public Vector2 Delta => Touch.TransformRawFingerVector(RawDelta, Device.Type);
        public Vector2 RawDelta { get; }
        public float Pressure { get; }

        internal TouchEventArgs(long deviceId, long fingerId, Vector2 position, Vector2 delta, float pressure)
        {
            Device = new TouchDevice(deviceId);
            FingerId = fingerId;
            RawPosition = position;
            RawDelta = delta;
            Pressure = pressure;
        }
    }
}