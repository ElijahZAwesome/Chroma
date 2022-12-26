using System.Runtime.InteropServices;
using Android.Util;

namespace Chroma.Android.Frontend;

static class Bootstrap
{
    delegate void Main();

    public static Game Game;

    public static void SDL_Main()
    {
        MainActivity.Fullscreen = true;
        MainActivity.ActivityInstance.RunOnUiThread(MainActivity.ActivityInstance.ActionBar.Hide);
        DisplayMetrics metrics = new DisplayMetrics();
        MainActivity.ActivityInstance.WindowManager.DefaultDisplay.GetMetrics(metrics);
        Game = new Game();
        Game.Run();
    }

    public static void Quit()
    {
        Game?.Quit();
    }

    public static void SetupMain()
    {
        // Give the main library something to call in Mono-Land afterwards
        SetMain(SDL_Main);
        // Insert your own post-lib-load, pre-SDL2 code here.
    }

    [DllImport("main")]
    static extern void SetMain(Main main);
}