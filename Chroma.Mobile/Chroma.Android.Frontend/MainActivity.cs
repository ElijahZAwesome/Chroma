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
    public static MainActivity ActivityInstance { get; protected set; }

    public static bool Fullscreen = true;

    public override void LoadLibraries()
    {
        base.LoadLibraries();
        ActivityInstance = this;
        Bootstrap.SetupMain();
    }

    public override void OnWindowFocusChanged(bool hasFocus)
    {
        base.OnWindowFocusChanged(hasFocus);
        if (hasFocus && Fullscreen)
        {
            Window!.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                SystemUiFlags.LayoutStable |
                SystemUiFlags.LayoutHideNavigation |
                SystemUiFlags.LayoutFullscreen |
                SystemUiFlags.HideNavigation |
                SystemUiFlags.Fullscreen |
                SystemUiFlags.ImmersiveSticky
            );
        }
    }
}