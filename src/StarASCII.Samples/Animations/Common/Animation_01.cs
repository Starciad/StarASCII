using System.IO;

namespace StarASCII.Samples.Animations.Common
{
    internal sealed class Animation_01 : AnimationSample
    {
        private static readonly string framesDirectory = Path.Combine(Program.BaseDirectory, "assets", "blinking_eye");

        private readonly uint duration = 100;

        internal Animation_01()
        {
            this.Name = "Blinking Eye";
            this.Animation = new()
            {
                Loops = 3,
            };

            this.Animation.AddFrame(new SFrame()
            {
                Content = File.ReadAllText(Path.Combine(framesDirectory, $"frame_001.txt")),
                Duration = this.duration,
            });

            this.Animation.AddFrame(new SFrame()
            {
                Content = File.ReadAllText(Path.Combine(framesDirectory, $"frame_002.txt")),
                Duration = this.duration,
            });

            this.Animation.AddFrame(new SFrame()
            {
                Content = File.ReadAllText(Path.Combine(framesDirectory, $"frame_003.txt")),
                Duration = this.duration,
            });

            this.Animation.AddFrame(new SFrame()
            {
                Content = File.ReadAllText(Path.Combine(framesDirectory, $"frame_004.txt")),
                Duration = this.duration,
            });
        }
    }
}
