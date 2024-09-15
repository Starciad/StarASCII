using StarASCII.Enums;

using System;
using System.IO;

namespace StarASCII.Samples.Animations.Common
{
    internal sealed class Animation_01 : AnimationSample
    {
        private static readonly string framesDirectory = Path.Combine(Program.BaseDirectory, "assets", "blinking_eye");

        private readonly sbyte frames = 4;
        private readonly uint duration = 350;

        internal Animation_01()
        {
            this.Name = "Blinking Eye (UTF-8)";
            this.Animation = new()
            {
                Loops = 3,
            };

            for (int i = 0; i < this.frames; i++)
            {
                int index = i + 1;

                this.Animation.AddFrame(new SFrame(File.ReadAllText(Path.Combine(framesDirectory, $"frame_{index:000}.txt")), this.duration)
                {
                    ForegroundColor = ConsoleColor.Green,
                });
            }

            this.Animation.Direction = SAnimationDirection.PingPong;
        }
    }
}
