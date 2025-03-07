namespace StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_MultiValue
{
    using StudioIdGames.MimiClean;
    using StudioIdGames.MimiClean.Collections;
    using StudioIdGames.MimiClean.Domain.App;
    using StudioIdGames.MimiClean.Task;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class Program
    {
        private class StartActRepository : RepositoryCleanResult<Task>
        {
            protected override IReadOnlyCollection<CleanResultBoxed<Task>> ValuesProtected { get; } = new Acts(acts);

            private static readonly List<Func<Task>> acts =
            [
                () => Task.Run(async () =>
                {
                    foreach (var item in "Hello!!\n\n")
                    {
                        Console.Write(item);
                        if (item == '\n')
                        {
                            await Task.Delay(500);
                        }
                        else
                        {
                            await Task.Delay(50);
                        }
                    }
                }),
                () => Task.Run(async () =>
                {
                    var text =

@"I am a sample program by ""StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_MultiValue""
Let's Start The Sample Program!!" + "\n\n";

                    foreach (var item in text)
                    {
                        Console.Write(item);
                        if (item == '\n')
                        {
                            await Task.Delay(500);
                        }
                        else
                        {
                            await Task.Delay(50);
                        }
                    }
                }),
            ];

            private class Acts(IReadOnlyList<Func<Task>> acts) : CleanResultList<Func<Task>, Task>(acts)
            {
                protected override CleanResult<Task> GetResult(in Func<Task> value)
                {
                    return CleanResult.Success(value?.Invoke() ?? Task.CompletedTask);
                }
            }
        }

        private class NamesRepository : RepositoryCleanResultMap<string, Task<string>>
        {
            private static readonly Dictionary<string, string> names = new(StringComparer.Ordinal)
            {
                {"Cat", "Neko-Nyan" },
                {"Dog", "Inu-Wan" },
                {"Fox", "Kitu-Kon" },
                {"Fish", "Uo-Pichi" }
            };

            protected override IReadOnlyDictionary<string, CleanResultBoxed<Task<string>>> MapProtected { get; } = new Names(names);

            private class Names(IReadOnlyDictionary<string, string> names) : CleanResultDictionary<string, string, Task<string>>(names)
            {
                protected override CleanResult<Task<string>> GetResult(string key, string value, bool isDefined)
                {
                    if (isDefined)
                    {
                        return CleanResult.Success(Task.Run(async () =>
                        {
                            if (Random.Shared.NextDouble() < 0.75)
                            {
                                await Task.Delay(1000);
                                return value;
                            }
                            else
                            {
                                await Task.Delay(1500);
                                throw new Exception("Dummy Access Error");
                            }
                        }));
                    }
                    else
                    {
                        return CleanResult.Failed<Task<string>>(new ArgumentOutOfRangeException(nameof(key)));
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            var task = MainAsync(args);
            task.Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            var startActRep = new StartActRepository();

            foreach (var act in startActRep)
            {
                await act;
            }

            var namesRep = new NamesRepository();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"- When All -------------------");

                var tasks = namesRep
                    .Where(e => e.Value.IsSuccess)
                    .Select(e =>
                    {
                        return Task.Run(async () =>
                        {
                            Write(e.Key, await e.Value);
                        });
                    })
                    .ToArray();

                await Task.WhenAll(tasks);

                static void Write(string key, in CleanResult<string> res)
                {
                    if (res)
                    {
                        Console.Write($"The {key} is called {res.Result}!\n");
                    }
                    else
                    {
                        Console.Write($"The {key} is called ...??\n");
                    }
                }
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"- Step by Step -------------------");
                foreach (var key in namesRep.Keys)
                {
                    Console.Write($"The {key} is called ...");
                    Write(await namesRep[key]);
                }

                static void Write(in CleanResult<string> res)
                {
                    if (res)
                    {
                        Console.WriteLine($"{res.Result}!");
                    }
                    else
                    {
                        Console.WriteLine($" ...??");
                    }
                }
            }
        }
    }
}
