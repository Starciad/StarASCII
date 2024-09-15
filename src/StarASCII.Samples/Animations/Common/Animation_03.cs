using System;
using System.IO;

namespace StarASCII.Samples.Animations.Common
{
    internal sealed class Animation_03 : AnimationSample
    {
        private static readonly string framesDirectory = Path.Combine(Program.BaseDirectory, "assets", "zebra");

        private readonly sbyte frames = 9;
        private readonly uint duration = 185;

        internal Animation_03()
        {
            this.Name = "Zebra (UTF-8)";
            this.Animation = new()
            {
                Loops = 4,
            };

            for (int i = 0; i < this.frames; i++)
            {
                int index = i + 1;

                this.Animation.AddFrame(new SFrame(File.ReadAllText(Path.Combine(framesDirectory, $"frame_{index:000}.txt")), this.duration)
                {
                    ForegroundColor = ConsoleColor.Gray,
                });
            }
        }
    }
}
