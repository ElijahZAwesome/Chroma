using Android.Content.PM;
using Android.Views;
using Org.Libsdl.App;

namespace Chroma.Android.Frontend;

[Activity(
    Label = "Chroma",
    MainLauncher = true,
    Icon = "@mipmap/appicon",
    HardwareAccelerated = true,
    ScreenOrientation = ScreenOrientation.Landscape
)]
public class MainActivity : SDLActivity
{
    public static MainActivity ActivityInstance { get; private set; }

    public static bool Fullscreen = true;

    public MainActivity()
    {
        ActivityInstance = this;
    }

    public override void LoadLibraries()
    {
        base.LoadLibraries();
        Bootstrap.SetupMain();
    }

    public override void OnWindowFocusChanged(bool hasFocus)
    {
        base.OnWindowFocusChanged(hasFocus);
        Window!.SetDecorFitsSystemWindows(!(hasFocus && Fullscreen));
    }
}