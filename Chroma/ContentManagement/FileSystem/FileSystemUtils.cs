using System;
using System.Runtime.InteropServices;

namespace Chroma.ContentManagement.FileSystem
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