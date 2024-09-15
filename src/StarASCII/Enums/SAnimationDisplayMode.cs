namespace StarASCII.Enums
{
    /// <summary>
    /// Specifies the display mode for the animation, controlling how the terminal is cleared before execution.
    /// </summary>
    public enum SAnimationDisplayMode
    {
        /// <summary>
        /// Clears the terminal and sets the cursor position to the top-left corner before starting the animation.
        /// </summary>
        CleanAndStart,

        /// <summary>
        /// Starts the animation without clearing the terminal, preserving the current content.
        /// </summary>
        StartWithoutCleaning
    }
}
