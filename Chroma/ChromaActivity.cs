#if ANDROID
using System.Runtime.InteropServices;
using Org.Libsdl.App;

namespace Chroma
{
    public abstract class ChromaActivity : SDLActivity
    {
        private delegate void Main();
        
        public Game Game { get; private set; }
        
        public ChromaActivity()
        {
        }

        public sealed override void LoadLibraries()
        {
            base.LoadLibraries();
            SetMain(SdlMain);
        }

        private void SdlMain()
        {
            OnPreload();
            Game = GetGame();
            OnPostload();
            Game.Run();
        }

        public virtual void OnPreload()
        {
            
        }

        public abstract Game GetGame();

        public virtual void OnPostload()
        {
            
        }

        protected override void Dispose(bool disposing)
        {
            Quit();
            base.Dispose(disposing);
        }
        
        public virtual void Quit()
        {
            Game?.Quit();
        }

        [DllImport("main")]
        private static extern void SetMain(Main main);
    }
}
#endif