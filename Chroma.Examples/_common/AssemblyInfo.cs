using Android;
using Android.App;

[assembly: Application(
    Debuggable = true,
    AllowBackup = true,
    Label = "Chroma Example",
    SupportsRtl = true
)]
[assembly: Permission(Name = Manifest.Permission.HighSamplingRateSensors)]