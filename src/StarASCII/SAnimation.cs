using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StarASCII
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SAnimation()
    {
        /// <summary>
        /// 
        /// </summary>
        public uint Loops { get => loops; set => loops = value; }

        private readonly List<SFrame> frames = [];
        private uint loops = 1;

        private readonly StringBuilder buffer = new();

        /// <summary>
        /// 
        /// </summary>
        public void Play()
        {
            Console.Clear();
            
            for (uint i = 0; i < loops; i++)
            {
                for (int j = 0; j < frames.Count; j++)
                {
                    SFrame frame = frames[j];

                    _ = buffer.Clear();
                    _ = buffer.Append(frame.Content);

                    Console.SetCursorPosition(0, 0);

                    Console.ForegroundColor = frame.ForegroundColor;
                    Console.BackgroundColor = frame.BackgroundColor;

                    Console.Write(buffer.ToString());

                    Thread.Sleep(TimeSpan.FromMilliseconds(frame.Duration));
                }
            }

            Thread.Sleep(TimeSpan.FromSeconds(2f));

            Console.Clear();
            buffer.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame"></param>
        public void AddFrame(SFrame frame)
        {
            frames.Add(frame);
        }
    }
}
