using System;

namespace StarASCII
{
    public struct SFrame
    {
        public string Content { get; set; }
        public uint Duration { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public SFrame()
        {
            this.Content = string.Empty;
            this.Duration = 500;
            this.ForegroundColor = ConsoleColor.White;
            this.BackgroundColor = ConsoleColor.Black;
        }
    }
}
