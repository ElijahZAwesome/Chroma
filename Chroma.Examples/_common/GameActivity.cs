using System;
using System.Reflection;
using Android.App;
using Android.Content.PM;

namespace Chroma.Examples
{
    [Activity(
        Label = "Chroma",
        MainLauncher = true,
        HardwareAccelerated = true,
        ScreenOrientation = ScreenOrientation.Landscape
    )]
    public class GameActivity : ChromaActivity
    {
        public override Game GetGame()
        {
            var coreType = Type.GetType(Assembly.GetExecutingAssembly().GetName().Name + ".GameCore");
            return (Game)Activator.CreateInstance(coreType!);
        }
    }
}