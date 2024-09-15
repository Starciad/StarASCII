using System;
using System.Linq;

namespace StarASCII
{
    public struct SFrame
    {
        public string Content { get; private set; }
        public uint Duration { get; private set; }
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }
        public (uint width, uint height) Size { get; private set; }

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
            uint columns = 0;

            string[] rows = value.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int i = 0; i < rows.Length; i++)
            {
                int length = rows[i].Length;

                if (columns < length)
                {
                    columns = (uint)length;
                }
            }

            return ((uint)rows.Length, columns);
        }
    }
}
