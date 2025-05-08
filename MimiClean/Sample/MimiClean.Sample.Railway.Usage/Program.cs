using StudioIdGames.MimiClean.Railway;
using StudioIdGames.MimiClean.Railway.CleanResultErrors;
using System.Resources;
using System.Transactions;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace StudioIdGames.MimiClean.Sample.Railway.Usage
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter text your like. (\"null\" or \"error\" or \"exit\" is special word case.)");
                var line = Console.ReadLine();
                if (line == "null") line = null;
                var result1 = line.ToCleanResult();
                if (line == "error")
                {
                    result1 = result1.Chain((result, state, chain) =>
                    {
                        chain.AddError(new InvalidOperationError($"Test Error1, {result}"));
                        chain.AddError(new InvalidOperationError($"Test Error2, {result}"));
                        chain.AddError(new InvalidOperationError($"Test Error3, {result}"));

                        return result;
                    });
                }
                else if (line == "exit")
                {
                    break;
                }

                var result2 = GetLength(result1);
                var result2LengthSquere = result2.Chain((result, _, _) => result.length);
                ToSquere(ref result2LengthSquere);
                result2.ChainTo(ref result2, (result, _, chain) =>
                {
                    var chain2 = result2LengthSquere.Chain(out var length, out _);
                    chain.Join(chain2);
                    return (length, result.error);
                });
                var result3 = GetText(result2);

                try
                {
                    result3.Close((text, state, close) =>
                    {
                        if (state == CleanResultState.Success)
                        {
                            Console.WriteLine(text);
                        }
                        else
                        {
                            Console.WriteLine($"{text}\n{string.Join("\n", close.Errors)}");
                        }
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nCatch Exception!\n{e}");
                }

                Console.WriteLine();
            }
        }

        internal static CleanResult<(int length, InvalidOperationError? error)> GetLength(CleanResult<string?> result)
        {
            return result.Chain((result, state, chain) =>
            {
                int length = -1;
                var error = (InvalidOperationError?)null;

                Console.WriteLine("Cancel? (enter \"c\")");
                if (Console.ReadLine() == "c")
                {
                    Console.WriteLine();
                    chain.AddCancel(default);
                }
                else if (state == CleanResultState.Success)
                {
                    if (result == null)
                    {
                        error = new InvalidOperationError("Value is null");
                        chain.AddError(error);
                    }
                    else
                    {
                        length = result.Length;
                    }
                }

                return (length, error);
            });
        }

        internal static void ToSquere(ref CleanResult<int> result)
        {
            result.ChainTo(ref result, (result, _, _) => result * result);
        }

        internal static CleanResult<string> GetText(CleanResult<(int length, InvalidOperationError? error)> result)
        {
            var chain = result.Chain(out var length_error, out var state);
            var (length, error) = length_error;
            string text;

            switch (state)
            {
                case CleanResultState.Success:
                    text = $"Length : {length}";
                    break;

                case CleanResultState.Failed:
                    text = "Failed : ";
                    chain.FixError(e =>
                    {
                        if (e == error)
                        {
                            text += "Value is null, ";
                            return true;
                        }
                        else
                        {
                            text += e.Message + ", ";
                            return false;
                        }
                    });

                    text = text.TrimEnd(',', ' ');
                    break;

                case CleanResultState.Canceled:
                    text = "Canceled";
                    break;

                default:
                    throw new NotSupportedException();
            }

            return chain.With(text);
        }
    }
}
