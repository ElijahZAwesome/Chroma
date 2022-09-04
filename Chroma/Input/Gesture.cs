using System;
using System.Collections.Generic;

namespace Chroma.Input;

public static class Gesture
{
    public static IReadOnlyList<RecordedGesture> Gestures { get; }
    internal static List<RecordedGesture> MutableGestures { get; }
    private static bool _recording;
    private static RecordedGesture _recordedGesture;

    public static void Record(TouchDevice? device = null)
    {
        var id = device?.Id ?? -1;

        _recording = true;
        _recordedGesture = new RecordedGesture();
    }

    internal static void RecordStep(TouchEventArgs e)
    {
    }
}