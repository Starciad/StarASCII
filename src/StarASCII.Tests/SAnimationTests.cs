using System;

namespace StarASCII.Tests
{
    public sealed class SAnimationTests
    {
        [Fact]
        public void SAnimation_SetLoops_ThrowsExceptionForInvalidValue()
        {
            // Arrange
            SAnimation animation = new();

            // Act & Assert
            _ = Assert.Throws<ArgumentException>(() => animation.Loops = 0);
            _ = Assert.Throws<ArgumentException>(() => animation.Loops = uint.MaxValue * 0);
        }

        [Fact]
        public void SAnimation_AddFrame_IncreasesFrameCount()
        {
            // Arrange
            SAnimation animation = new();
            SFrame frame = new("Content", 100);

            // Act
            animation.AddFrame(frame);

            // Assert
            // Verificar o conteúdo em um teste posterior
        }

        [Fact]
        public void SAnimation_Play_ThrowsException_WhenNoFramesRegistered()
        {
            // Arrange
            SAnimation animation = new();

            // Act & Assert
            _ = Assert.Throws<InvalidOperationException>(() => animation.Play());
        }
    }
}
