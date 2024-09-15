using System;

namespace StarASCII
{
    /// <summary>
    /// Represents a single frame of an ASCII animation, including its content, display duration, and appearance.
    /// </summary>
    public struct SFrame
    {
        /// <summary>
        /// Gets the content to be displayed in this frame.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Gets the duration (in milliseconds) for which this frame will be displayed.
        /// </summary>
        public uint Duration { get; private set; }

        /// <summary>
        /// Gets the dimensions of the frame, including its width and height.
        /// </summary>
        public (uint width, uint height) Size { get; private set; }

        /// <summary>
        /// Gets or sets the foreground color used to display the frame's content.
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color used behind the frame's content.
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SFrame"/> struct with the specified content and duration.
        /// The foreground color defaults to white and the background color to black.
        /// </summary>
        /// <param name="content">The text content to be displayed in the frame.</param>
        /// <param name="duration">The duration (in milliseconds) for which the frame will be displayed.</param>
        public SFrame(string content, uint duration)
        {
            WithContent(content);
            this.Duration = duration;
            this.ForegroundColor = ConsoleColor.White;
            this.BackgroundColor = ConsoleColor.Black;
        }

        private void WithContent(string value)
        {
            this.Content = value;
            this.Size = GetSize(value);
        }

        private static (uint, uint) GetSize(string value)
        {
            uint width = 0;
            string[] rows = value.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int i = 0; i < rows.Length; i++)
            {
                int length = rows[i].Length;

                if (width <= length)
                {
                    width = (uint)length;
                }
            }

            return (width + 1, (uint)rows.Length);
        }
    }
}
