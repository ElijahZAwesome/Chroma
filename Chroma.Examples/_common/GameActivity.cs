using System;
using System.Reflection;
using Android.App;
using Android.Content.PM;

namespace Chroma.Examples
{
    [Activity(
        Label = "Chroma",
        MainLauncher = true,
        Icon = "@mipmap/appicon",
        HardwareAccelerated = true,
        ScreenOrientation = ScreenOrientation.Landscape
    )]
    public class GameActivity : ChromaActivity
    {
        public override Game GetGame()
        {
            return (Game)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetName().Name, "GameCore").Unwrap();
        }
    }
}