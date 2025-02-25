using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Gateway.Abstract
{
    public abstract class ConsoleGateway<TInput>(string name) : Gateway<TInput>
    {
        protected static class Utility
        {
            public static string ReadName(string? nameText = null)
            {
                nameText ??= "name";

                string name;

                do
                {
                    Console.Write($"{nameText} : ");
                } while (string.IsNullOrWhiteSpace(name = Console.ReadLine() ?? ""));

                return name;
            }

            public static (int x, int y) ReadXY(string? xText = null, string? yText = null)
            {
                xText ??= "x";
                yText ??= "y";

                int x, y;

                do
                {
                    Console.Write($"{xText} : ");
                } while (!int.TryParse(Console.ReadLine(), out x));

                do
                {
                    Console.Write($"{yText} : ");
                } while (!int.TryParse(Console.ReadLine(), out y));

                return (x, y);
            }
        }

        public string Name => name;

        protected abstract TInput MakeInputProtected();

        protected abstract string Print(TInput input);

        public override CleanResult<TInput> MakeInput()
        {
            Console.WriteLine($"[Input] {Name}");

            var input = MakeInputProtected();
            var print = Print(input);

            Console.WriteLine($"[EndInput] {Name} ({print})\n");

            return CleanResult<TInput>.Success(input);
        }
    }
}
