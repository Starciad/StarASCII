using StarASCII.Enums;

using System.IO;
using System;

namespace StarASCII.Samples.Animations.Common
{
    internal sealed class Animation_01 : AnimationSample
    {
        private static readonly string framesDirectory = Path.Combine(Program.BaseDirectory, "assets", "blinking_eye");

        private readonly uint duration = 350;

        internal Animation_01()
        {
            this.Name = "Blinking Eye (UTF-8)";
            this.Animation = new()
            {
                Loops = 3,
            };

            this.Animation.AddFrame(new SFrame(File.ReadAllText(Path.Combine(framesDirectory, $"frame_001.txt")), this.duration)
            {
                ForegroundColor = ConsoleColor.Green,
            });

            this.Animation.AddFrame(new SFrame(File.ReadAllText(Path.Combine(framesDirectory, $"frame_002.txt")), this.duration)
            {
                ForegroundColor = ConsoleColor.Red,
            });

            this.Animation.AddFrame(new SFrame(File.ReadAllText(Path.Combine(framesDirectory, $"frame_003.txt")), this.duration)
            {
                ForegroundColor = ConsoleColor.Yellow,
            });

            this.Animation.AddFrame(new SFrame(File.ReadAllText(Path.Combine(framesDirectory, $"frame_004.txt")), this.duration)
            {
                ForegroundColor = ConsoleColor.Blue,
            });

            this.Animation.Direction = SAnimationDirection.PingPong;
        }
    }
}
