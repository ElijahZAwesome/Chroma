using System;
using System.Numerics;
using Chroma.Natives.Bindings.SDL;
using Chroma.Windowing;

namespace Chroma.Input
{
    public class Finger
    {
        internal IntPtr Handle { get; private set; }
        internal long DeviceId { get; private set; }
        internal unsafe SDL2.SDL_Finger* InternalFinger => (SDL2.SDL_Finger*)Handle.ToPointer();

        public TouchDevice Device
        {
            get
            {
                EnsureHandleValid();

                return new TouchDevice(DeviceId);
            }
        }
        
        public long Id
        {
            get
            {
                EnsureHandleValid();

                unsafe
                {
                    return InternalFinger->id;
                }
            }
        }

        public Vector2 Position
        {
            get
            {
                EnsureHandleValid();

                unsafe
                {
                    return Touch.TransformRawFingerVector(InternalFinger->x, InternalFinger->y, Device.Type);
                }
            }
        }

        public Vector2 RawPosition
        {
            get
            {
                EnsureHandleValid();

                unsafe
                {
                    return new Vector2(
                        InternalFinger->x,
                        InternalFinger->y
                    );
                }
            }
        }

        public float Pressure
        {
            get
            {
                EnsureHandleValid();

                unsafe
                {
                    return InternalFinger->pressure;
                }
            }
        }

        internal Finger(long deviceId, IntPtr handle)
        {
            DeviceId = deviceId;
            Handle = handle;
        }

        protected void EnsureHandleValid()
        {
            if (Handle == IntPtr.Zero)
                throw new InvalidOperationException("Finger handle is not valid.");
        }
    }
}