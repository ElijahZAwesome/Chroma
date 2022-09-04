using System;
using System.Collections;
using System.Collections.Generic;
using Chroma.Natives.Bindings.SDL;

namespace Chroma.Input
{
    public struct TouchDevice : IEquatable<TouchDevice>
    {
        public long Id { get; private set; }

        public TouchDeviceType Type => (TouchDeviceType)SDL2.SDL_GetTouchDeviceType(Id);

        public int ActiveFingerCount => SDL2.SDL_GetNumTouchFingers(Id);
        public IEnumerable<Finger> Fingers => EnumerateFingers();

        internal IEnumerable<Finger> EnumerateFingers()
        {
            for (var i = 0; i < ActiveFingerCount; i++)
            {
                yield return new Finger(Id, SDL2.SDL_GetTouchFinger(Id, i));
            }
        }

        public TouchDevice(long id)
        {
            Id = id;
        }

        public bool Equals(TouchDevice other)
        {
            return Id == other.Id;
        }
    }
}