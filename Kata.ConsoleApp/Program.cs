using System;
using Kata.Core;

namespace Kata.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EnsureArgumentIsProvided(args);

            new KataConsole(new DiamondFormProvider()).Write(args[0][0]);
        }

        private static void EnsureArgumentIsProvided(string[] args)
        {
            if (!(args is { Length: 1 }) || string.IsNullOrWhiteSpace(args[0]) || args[0].Length != 1)
            {
                throw new ArgumentException($"Valid {nameof(args)} is required");
            }
        }
    }
}
