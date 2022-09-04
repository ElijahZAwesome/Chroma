using System;
using System.Collections.Generic;
using System.Numerics;
using Chroma.Natives.Bindings.SDL;
using Chroma.Windowing;

namespace Chroma.Input
{
    public static class Touch
    {
        public static int DeviceCount => SDL2.SDL_GetNumTouchDevices();
        public static IEnumerable<TouchDevice> Devices => EnumerateDevices();

        private static IEnumerable<TouchDevice> EnumerateDevices()
        {
            for (var i = 0; i < DeviceCount; i++)
            {
                yield return new TouchDevice(SDL2.SDL_GetTouchDevice(i));
            }
        }

        public static IEnumerable<Finger> AllFingers => EnumerateAllFingers();

        private static IEnumerable<Finger> EnumerateAllFingers()
        {
            foreach (var device in Devices)
            {
                foreach (var finger in device.Fingers)
                {
                    yield return finger;
                }
            }
        }

        /*
         * While currently these event methods don't actually need to exist I think there's good reason
         * to eventually store the states of touch events, but for now this is not implemented.
         */
        internal static void OnTouchPressed(Game game, TouchEventArgs e)
        {
            //_buttonStates.Add(e.Button);
            
            game.OnTouchPressed(e);
        }

        internal static void OnTouchReleased(Game game, TouchEventArgs e)
        {
            //_buttonStates.Remove(e.Button);
            
            game.OnTouchReleased(e);
        }
        
        /*
         * TODO: Test trackpad modes
         */
        internal static float TransformRawFingerValue(float val, TouchDeviceType deviceType)
        {
            return deviceType switch
            {
                TouchDeviceType.Invalid => throw new Exception("An invalid device was used as touch input."),
                TouchDeviceType.Touchscreen => MathF.Sqrt((Window.Instance.Size.Width^2) + (Window.Instance.Size.Height^2)) * val,
                TouchDeviceType.TrackpadAbsolute or TouchDeviceType.TrackpadRelative => MathF.Sqrt((Window.Instance.CurrentDisplay.Bounds.Width^2) + (Window.Instance.CurrentDisplay.Bounds.Height^2)) * val,
                _ => throw new ArgumentOutOfRangeException(nameof(deviceType), deviceType, null)
            };
        }
        
        internal static Vector2 TransformRawFingerVector(float x, float y, TouchDeviceType deviceType)
        {
            return deviceType switch
            {
                TouchDeviceType.Invalid => throw new Exception("An invalid device was used as touch input."),
                TouchDeviceType.Touchscreen => new Vector2(
                    Window.Instance.Size.Width * x,
                    Window.Instance.Size.Height * y
                ),
                TouchDeviceType.TrackpadAbsolute or TouchDeviceType.TrackpadRelative => new Vector2(
                    (Window.Instance.CurrentDisplay.Bounds.Width -
                     (Window.Instance.Position.X + Window.Instance.Size.Width)) * x,
                    (Window.Instance.CurrentDisplay.Bounds.Height -
                     (Window.Instance.Position.Y + Window.Instance.Size.Height)) * y
                ),
                _ => throw new ArgumentOutOfRangeException(nameof(deviceType), deviceType, null)
            };
        }

        internal static Vector2 TransformRawFingerVector(Vector2 pos, TouchDeviceType deviceType)
            => TransformRawFingerVector(pos.X, pos.Y, deviceType);
    }
}