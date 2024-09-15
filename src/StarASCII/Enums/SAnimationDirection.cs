namespace StarASCII.Enums
{
    /// <summary>
    /// Specifies the direction in which the animation frames are played.
    /// </summary>
    public enum SAnimationDirection
    {
        /// <summary>
        /// Plays the animation frames in a forward direction, from the first frame to the last.
        /// </summary>
        Forward,

        /// <summary>
        /// Plays the animation frames in reverse order, from the last frame back to the first.
        /// </summary>
        Reverse,

        /// <summary>
        /// Plays the animation frames in a ping-pong fashion, going forward to the last frame and then reversing back to the first.
        /// </summary>
        PingPong,
    }
}
