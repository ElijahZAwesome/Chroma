using Android;
using Android.App;

[assembly: Application(
    Debuggable = true,
    AllowBackup = true,
    SupportsRtl = true,
    Label = "Chroma Example"
)]
[assembly: Permission(Name = Manifest.Permission.HighSamplingRateSensors)]