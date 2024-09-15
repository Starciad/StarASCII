using StarASCII.Enums;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StarASCII
{
    public sealed class SAnimation()
    {
        public uint Loops
        {
            get => this.loops;
            set => this.loops = value > 0 ? value : 1;
        }

        public SAnimationDirection Direction { get; set; }
        public SAnimationDisplayMode DisplayMode { get; set; }

        public delegate void AnimationEventHandler();
        public delegate void FrameChangedEventHandler(SFrame frame, int frameIndex);
        public delegate void LoopCompletedEventHandler(uint loopCount);

        public event AnimationEventHandler OnAnimationStart;
        public event AnimationEventHandler OnAnimationEnd;
        public event FrameChangedEventHandler OnFrameChanged;
        public event LoopCompletedEventHandler OnLoopCompleted;

        private readonly List<SFrame> registeredFrames = [];
        private uint loops = 1;

        private readonly StringBuilder buffer = new();

        public void Play()
        {
            this.OnAnimationStart?.Invoke();

            int tCursorPosX, tCursorPosY;

            switch (this.DisplayMode)
            {
                case SAnimationDisplayMode.CleanAndStart:
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    break;

                case SAnimationDisplayMode.StartWithoutCleaning:
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                    break;

                default:
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    break;
            }

            tCursorPosX = Console.CursorLeft;
            tCursorPosY = Console.CursorTop;

            SFrame[] framesToExecute = GetFramesToExecute();

            for (uint i = 0; i < this.loops; i++)
            {
                for (int j = 0; j < framesToExecute.Length; j++)
                {
                    SFrame frame = framesToExecute[j];

                    _ = this.buffer.Clear();
                    _ = this.buffer.Append(frame.Content);

                    Console.SetCursorPosition(tCursorPosX, tCursorPosY);

                    Console.ForegroundColor = frame.ForegroundColor;
                    Console.BackgroundColor = frame.BackgroundColor;

                    Console.Write(this.buffer.ToString());

                    this.OnFrameChanged?.Invoke(frame, j);

                    Thread.Sleep(TimeSpan.FromMilliseconds(frame.Duration));
                }

                this.OnLoopCompleted?.Invoke(i + 1);
            }

            _ = this.buffer.Clear();

            this.OnAnimationEnd?.Invoke();
        }

        public void AddFrame(SFrame frame)
        {
            this.registeredFrames.Add(frame);
        }

        private SFrame[] GetFramesToExecute()
        {
            return this.Direction switch
            {
                SAnimationDirection.Forward => Forward(),
                SAnimationDirection.Reverse => Reverse(),
                SAnimationDirection.PingPong => PingPong(),
                _ => Forward(),
            };

            SFrame[] Forward()
            {
                return [.. this.registeredFrames];
            }

            SFrame[] Reverse()
            {
                SFrame[] result = [.. this.registeredFrames];
                Array.Reverse(result);
                return result;
            }

            SFrame[] PingPong()
            {
                SFrame[] forward = [.. this.registeredFrames];
                SFrame[] result = new SFrame[this.registeredFrames.Count * 2];
                forward.CopyTo(result, 0);
                ReverseInto(result, this.registeredFrames.Count);
                return result;
            }

            void ReverseInto(SFrame[] array, int offset)
            {
                for (int i = 0, j = this.registeredFrames.Count - 1; i < this.registeredFrames.Count; i++, j--)
                {
                    array[offset + i] = this.registeredFrames[j];
                }
            }
        }
    }
}
