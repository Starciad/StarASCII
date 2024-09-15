using StarASCII.Samples.Animations;
using StarASCII.Samples.Animations.Common;

using System;
using System.Text;

namespace StarASCII.Samples
{
    internal static class Program
    {
        internal static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;

        private static readonly string BR = Environment.NewLine;

        private static readonly AnimationSample[] samples = [
            new Animation_01(),
            new Animation_02(),
            new Animation_03(),
        ];

        private static void Main()
        {
            Console.Title = "STAR ASCII - SAMPLES";

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string userInput;
            int userIndex;

            while (true)
            {
                Console.Clear();

                DrawHeader();
                DrawSampleList();

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine();
                    Console.Write($"Enter the number of the sampling animation you want to view (01-{samples.Length:00}): ");
                    Console.ForegroundColor = ConsoleColor.White;
                    userInput = Console.ReadLine();
                } while (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out userIndex) || userIndex <= 0 || userIndex > samples.Length);

                samples[userIndex - 1].Play();
            }
        }

        private static void DrawHeader()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{BR}STAR ASCII PROJECT - SAMPLES");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Made By Davi \"Starciad\" Fernandes (c) 2024{BR}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"A project that has a collection of small samples that use the potential of the library to create small demonstration animations.{BR}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"-=-=-=-=-=-=-=-=-=-{BR}");
            Console.WriteLine($"Select one of the samples from the list below to view them.{BR}");
        }

        private static void DrawSampleList()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < samples.Length; i++)
            {
                AnimationSample sample = samples[i];
                Console.WriteLine($"{i + 1:00}) \"{sample.Name}\"");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
