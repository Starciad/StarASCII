using System;

namespace StarASCII
{
    /// <summary>
    /// 
    /// </summary>
    public struct SFrame
    {
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SFrame()
        {
            this.Content = string.Empty;
            this.Duration = 500;
            this.ForegroundColor = ConsoleColor.White;
            this.BackgroundColor = ConsoleColor.Black;
        }
    }
}
