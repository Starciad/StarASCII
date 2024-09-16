using StarASCII.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StarASCII
{
    /// <summary>
    /// Represents an ASCII-based animation with multiple customizable settings.
    /// </summary>
    public sealed class SAnimation
    {
        /// <summary>
        /// Gets or sets the number of loops the animation will run.
        /// Ensures the value is always greater than or equal to 1.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when an attempt is made to set loops to 0 or a negative value.</exception>
        public uint Loops
        {
            get => this.loops;
            set => this.loops = value > 0 ? value : throw new ArgumentException("Loops must be greater than 0.");
        }

        /// <summary>
        /// Gets or sets the direction in which the animation frames will be played.
        /// </summary>
        public SAnimationDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets how the display is handled before and during the animation.
        /// </summary>
        public SAnimationDisplayMode DisplayMode { get; set; }

        /// <summary>
        /// Delegate for handling generic animation events like start and end.
        /// </summary>
        public delegate void AnimationEventHandler();

        /// <summary>
        /// Delegate for handling frame changes during the animation.
        /// Provides the current frame and its index.
        /// </summary>
        /// <param name="frame">The current frame being displayed.</param>
        /// <param name="frameIndex">The index of the current frame.</param>
        public delegate void FrameChangedEventHandler(SFrame frame, int frameIndex);

        /// <summary>
        /// Delegate for handling the completion of a loop within the animation.
        /// Provides the current loop count.
        /// </summary>
        /// <param name="loopCount">The number of loops completed so far.</param>
        public delegate void LoopCompletedEventHandler(uint loopCount);

        /// <summary>
        /// Event triggered when the animation starts.
        /// </summary>
        public event AnimationEventHandler OnAnimationStart;

        /// <summary>
        /// Event triggered when the animation ends.
        /// </summary>
        public event AnimationEventHandler OnAnimationEnd;

        /// <summary>
        /// Event triggered whenever a frame changes during the animation.
        /// </summary>
        public event FrameChangedEventHandler OnFrameChanged;

        /// <summary>
        /// Event triggered when a loop completes within the animation.
        /// </summary>
        public event LoopCompletedEventHandler OnLoopCompleted;

        private readonly List<SFrame> registeredFrames = [];
        private uint loops = 1;
        private readonly StringBuilder buffer = new();

        /// <summary>
        /// Plays the animation based on the registered frames and current settings.
        /// Throws an exception if no frames are registered.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when attempting to play an animation with no registered frames.</exception>
        public void Play()
        {
            ValidateFrames();
            this.OnAnimationStart?.Invoke();

            (int cursorX, int cursorY) = SetupDisplay();
            SFrame[] framesToExecute = GetFramesToExecute();

            ExecuteAnimation(framesToExecute, cursorX, cursorY);

            FinalizeAnimation();
        }

        private void ValidateFrames()
        {
            if (this.registeredFrames.Count == 0)
            {
                throw new InvalidOperationException("No frames have been registered. Cannot start animation.");
            }
        }

        private (int, int) SetupDisplay()
        {
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

            return (Console.CursorLeft, Console.CursorTop);
        }

        private void ExecuteAnimation(SFrame[] framesToExecute, int cursorX, int cursorY)
        {
            for (uint loop = 0; loop < this.loops; loop++)
            {
                PlayFrames(framesToExecute, cursorX, cursorY);
                this.OnLoopCompleted?.Invoke(loop + 1);
            }
        }

        private void PlayFrames(SFrame[] frames, int cursorX, int cursorY)
        {
            foreach (var (frame, index) in frames.Select((f, idx) => (f, idx)))
            {
                RenderFrame(frame, cursorX, cursorY);
                this.OnFrameChanged?.Invoke(frame, index);
                Thread.Sleep(TimeSpan.FromMilliseconds(frame.Duration));
            }
        }

        private void RenderFrame(SFrame frame, int cursorX, int cursorY)
        {
            _ = this.buffer.Clear();
            _ = this.buffer.Append(frame.Content);

            Console.SetCursorPosition(cursorX, cursorY);
            Console.ForegroundColor = frame.ForegroundColor;
            Console.BackgroundColor = frame.BackgroundColor;

            Console.Write(this.buffer.ToString());
        }

        private void FinalizeAnimation()
        {
            _ = this.buffer.Clear();
            this.OnAnimationEnd?.Invoke();
        }

        /// <summary>
        /// Registers a new frame to be used in the animation.
        /// </summary>
        /// <param name="frame">The frame to be added.</param>
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
