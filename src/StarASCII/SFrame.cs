using System;
using System.Linq;

namespace StarASCII
{
    public struct SFrame
    {
        public string Content { get; private set; }
        public uint Duration { get; private set; }
        public (uint width, uint height) Size { get; private set; }

        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

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
