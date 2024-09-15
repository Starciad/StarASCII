using System;
using System.IO;

namespace StarASCII.Samples.Animations.Common
{
    internal sealed class Animation_02 : AnimationSample
    {
        private static readonly string framesDirectory = Path.Combine(Program.BaseDirectory, "assets", "man_walking");

        private readonly sbyte frames = 9;
        private readonly uint duration = 150;

        internal Animation_02()
        {
            this.Name = "Man Walking (UTF-8)";
            this.Animation = new()
            {
                Loops = 2,
            };

            for (int i = 0; i < this.frames; i++)
            {
                int index = i + 1;

                this.Animation.AddFrame(new SFrame(File.ReadAllText(Path.Combine(framesDirectory, $"frame_{index:000}.txt")), this.duration)
                {
                    ForegroundColor = ConsoleColor.Yellow,
                });
            }
        }
    }
}
