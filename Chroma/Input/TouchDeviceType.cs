namespace Chroma.Input
{
    public enum TouchDeviceType
    {
        Invalid = -1,
        Touchscreen,            /* touch screen with window-relative coordinates */
        TrackpadAbsolute,       /* trackpad with absolute device coordinates */
        TrackpadRelative        /* trackpad with screen cursor-relative coordinates */
    }
}