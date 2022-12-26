using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Chroma.NALO.PlatformSpecific;
using Chroma.NALO.Syscalls;

namespace Chroma.NALO
{
    public static class NativeLoader
    {
        internal static IPlatform Platform { get; private set; }

        public static void LoadNatives(bool skipChecksumVerification)
        {
            try
            {
                var assembly = Assembly.GetCallingAssembly();
                var trace = new StackTrace();
                var frame = trace.GetFrame(1);
                
                if (frame == null || !frame.HasMethod())
                {
                    throw new InvalidOperationException("LoadNatives must be called from a method.");
                }
                
                var attrib = frame.GetMethod()?.GetCustomAttribute<ModuleInitializerAttribute>();

                if (attrib == null)
                {
                    throw new InvalidOperationException("LoadNatives must be called from a valid module initializer.");
                }

                var libraryFileNames = NativeLibraryExtractor.ExtractAll(assembly, skipChecksumVerification)
                    .Select(Path.GetFileName);

                Posix.DetectLibcEnvironment();

                if (Platform == null)
                {
                    if (OperatingSystem.IsWindows())
                    {
                        Platform = new WindowsPlatform();
                    }
                    else if (OperatingSystem.IsLinux())
                    {
                        Platform = new LinuxPlatform();
                    }
                    else if (OperatingSystem.IsMacOS())
                    {
                        Platform = new MacPlatform();
                    }
                    else throw new PlatformNotSupportedException("This platform is not supported.");
                }

                foreach (var libraryFileName in libraryFileNames)
                {
                    EarlyLog.Info($"Now loading: {libraryFileName}");
                    Platform.Register(libraryFileName);
                }
            }
            catch (Exception e)
            {
                throw new NativeLoaderException(
                    "NALO has failed. This is an engine error. If you are:\n" +
                    "  a) a user: contact the application developer\n" +
                    "  b) a developer: if you believe this is Chroma's fault post an issue on our website\n" +
                    "  c) cookie: you fucked up - better fix it quickly before anyone notices",
                    e
                );
            }
        }
    }
}