using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StarASCII
{
    public sealed class EPAnimation()
    {
        public float Delay { get => delay; set => delay = value; }
        public uint Loops { get => loops; set => loops = value; }

        private readonly List<SFrame> frames = [];
        private float delay = 500;
        private uint loops = 1;

        public void Play()
        {
            Console.Clear();
            StringBuilder buffer = new();

            for (uint i = 0; i < loops; i++)
            {
                foreach (SFrame frame in frames)
                {
                    _ = buffer.Clear();
                    _ = buffer.Append(frame.Content);

                    Console.SetCursorPosition(0, 0);

                    Console.Write(buffer.ToString());
                    Thread.Sleep(TimeSpan.FromMilliseconds(delay));
                }
            }

            Thread.Sleep(TimeSpan.FromSeconds(2f));
            Console.Clear();
        }

        public void AddFrame(SFrame frame)
        {
            frames.Add(frame);
        }
    }
}
