using System;

namespace StarASCII.Tests
{
    public sealed class SFrameTests
    {
        [Fact]
        public void SFrame_Initialization_CorrectlySetsProperties()
        {
            // Arrange
            string content = "Hello";
            uint duration = 500;

            // Act
            SFrame frame = new(content, duration);

            // Assert
            Assert.Equal(content, frame.Content);
            Assert.Equal(duration, frame.Duration);
            Assert.Equal(ConsoleColor.White, frame.ForegroundColor);
            Assert.Equal(ConsoleColor.Black, frame.BackgroundColor);
        }

        [Theory]
        [InlineData(@"Hello
                      World", 6, 2)]
        [InlineData("Test", 5, 1)]
        public void SFrame_CalculatesCorrectSize(string content, uint expectedWidth, uint expectedHeight)
        {
            // Act
            SFrame frame = new(content, 100);

            // Assert
            Assert.Equal((expectedWidth, expectedHeight), frame.Size);
        }

        [Fact]
        public void SFrame_UpdatesColors_Correctly()
        {
            // Arrange
            SFrame frame = new("Content", 100)
            {
                // Act
                ForegroundColor = ConsoleColor.Green,
                BackgroundColor = ConsoleColor.Blue
            };

            // Assert
            Assert.Equal(ConsoleColor.Green, frame.ForegroundColor);
            Assert.Equal(ConsoleColor.Blue, frame.BackgroundColor);
        }
    }
}
