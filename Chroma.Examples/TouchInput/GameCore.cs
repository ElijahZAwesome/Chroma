using System;
using System.Drawing;
using System.IO;
using System.Numerics;
using Chroma;
using Chroma.ContentManagement;
using Chroma.ContentManagement.FileSystem;
using Chroma.Graphics;
using Chroma.Input;
using Color = Chroma.Graphics.Color;

namespace TouchInput
{
    public class GameCore : Game
    {
        private Vector2 LastGesturePosition = Vector2.Zero;
        
        private Camera _cam;
        private Texture _grid;

        public GameCore() : base(new(false, false))
        {
        }

        protected override IContentProvider InitializeContentPipeline()
        {
            return new FileSystemContentProvider(
                Path.Combine(AppContext.BaseDirectory, "../../../../_common")
            );
        }

        protected override void LoadContent()
        {
            _cam = new Camera
            {
                UseCenteredOrigin = true
            };
            
            _grid = Content.Load<Texture>("Textures/grid.png");
        }

        protected override void Draw(RenderContext context)
        {
            context.WithCamera(_cam, () =>
            {
                context.DrawTexture(
                    _grid,
                    Vector2.Zero,
                    Vector2.One,
                    Vector2.Zero,
                    rotation: 0f
                );
            });

            foreach (var device in Touch.Devices)
            {
                context.DrawString(device.Type.ToString(), Vector2.Zero, Color.White);
                foreach (var finger in device.Fingers)
                {
                    context.Circle(ShapeMode.Fill, finger.Position, 5f * finger.Pressure, Color.Red);
                }
            }
        }

        protected override void TouchPressed(TouchEventArgs e)
        {
            Console.WriteLine(e.Device.Id);
            LastGesturePosition = Vector2.Zero;
        }

        protected override void TouchGesture(GestureEventArgs e)
        {
            if (LastGesturePosition != Vector2.Zero)
            {
                _cam.Position -= new Vector3(e.Position - LastGesturePosition, _cam.Z);
            }

            _cam.Rotation += e.RotationDelta;
            _cam.Zoom += new Vector2(e.RawDistanceDelta);

            LastGesturePosition = e.Position;
        }
    }
}