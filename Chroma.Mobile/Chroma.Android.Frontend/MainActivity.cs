using Android.Content.PM;
using Android.Content.Res;
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

    protected override void Dispose(bool disposing)
    {
        Bootstrap.Quit();
        base.Dispose(disposing);
    }

    public override void OnConfigurationChanged(Configuration newConfig)
    {
        base.OnConfigurationChanged(newConfig);
    }

    public override void OnWindowFocusChanged(bool hasFocus)
    {
        base.OnWindowFocusChanged(hasFocus);
        Window!.SetDecorFitsSystemWindows(!(hasFocus && Fullscreen));
    }
}