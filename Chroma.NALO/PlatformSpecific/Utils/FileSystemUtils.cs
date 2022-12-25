using System;

namespace Chroma.NALO.PlatformSpecific.Utils
{
    public static class FileSystemUtils
    {
        public static string BaseDirectory
        {
            get
            {
                if (OperatingSystem.IsAndroid())
                    return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                else
                    return AppContext.BaseDirectory;
            }
        }
    }
}