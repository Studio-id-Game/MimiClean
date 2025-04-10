namespace StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_MultiValue
{
    using StudioIdGames.MimiClean;
    using StudioIdGames.MimiClean.Collections;
    using StudioIdGames.MimiClean.Domain.App;
    using StudioIdGames.MimiClean.Task;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {
        private class StartActRepository : RepositoryCleanResult<Task>
        {
            protected override ICleanResultCollection<Task> CleanResultValuesProtected { get; } = new Acts(acts);

            private static readonly List<Func<CancellationToken, Task>> acts =
            [
                (ct) => Task.Run(async ( ) =>
                {
                    foreach (var item in "Hello!!\n\n")
                    {
                        Console.Write(item);
                        if (item == '\n')
                        {
                            await Task.Delay(200, ct);
                        }
                        else
                        {
                            await Task.Delay(20, ct);
                        }
                    }
                }),
                (ct) => Task.Run(async () =>
                {
                    var text =

@"I am a sample program by ""StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_MultiValue""
Let's Start The Sample Program!!" + "\n\n";

                    foreach (var item in text)
                    {
                        Console.Write(item);
                        if (item == '\n')
                        {
                            await Task.Delay(200, ct);
                        }
                        else
                        {
                            await Task.Delay(20, ct);
                        }
                    }
                }),
            ];

            private class Acts(IReadOnlyList<Func<CancellationToken, Task>> acts) : CleanResultList<Func<CancellationToken, Task>, Task>(acts)
            {
                public override IEnumerable<CleanResultBoxed<Task>> GetValues(CancellationToken cancellationToken)
                {
                    return base.GetValues(cancellationToken);
                }

                protected override CleanResult<Task> GetResult(Func<CancellationToken, Task> value, CancellationToken cancellationToken)
                {
                    return CleanResult.Success(value?.Invoke(cancellationToken) ?? Task.CompletedTask);
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

            protected override ICleanResultDictionary<string, Task<string>> CleanResultMapProtected { get; } = new Names(names);

            private class Names(IReadOnlyDictionary<string, string> names) : CleanResultDictionary<string, string, Task<string>>(names)
            {
                protected override CleanResult<Task<string>> GetResult(string key, string value, bool isDefined, CancellationToken cancellationToken)
                {
                    if (isDefined)
                    {
                        var task = Task.Run(async () =>
                        {
                            if (Random.Shared.NextDouble() < 0.75)
                            {
                                await Task.Delay(1000, cancellationToken);
                                return value;
                            }
                            else
                            {
                                await Task.Delay(1000, cancellationToken);
                                throw new Exception("Dummy Access Error");
                            }
                        });

                        return CleanResult.Success(task);
                    }
                    else
                    {
                        return CleanResult.Failed<Task<string>>(new ArgumentOutOfRangeException(nameof(key)));
                    }
                }
            }
        }

        private class SimpleCanceller : IDisposable
        {
            private readonly CancellationTokenSource tokenSource = new();

            public SimpleCanceller()
            {
                var token = tokenSource.Token;
                _ = Task.Run(async () =>
                {
                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {
                                if (!tokenSource.IsCancellationRequested)
                                {
                                    tokenSource.Cancel();
                                    Console.WriteLine();
                                }
                                break;
                            }
                        }

                        await Task.Delay(50, token);
                    }
                }, token);
            }

            public CancellationToken Token => tokenSource.Token;

            public void Dispose()
            {
                if (!tokenSource.IsCancellationRequested)
                {
                    tokenSource.Cancel();
                }
                tokenSource.Dispose();
            }
        }

        private static void Main(string[] args)
        {
            var task = MainAsync(args);
            task.Wait();
        }

        private static async Task MainAsync(string[] _)
        {
            Console.WriteLine("[Press Enter to cancel a section.]\n");

            var startActRep = new StartActRepository();

            using (var cts = new SimpleCanceller())
            {
                foreach (var act in startActRep.GetValues(cts.Token))
                {
                    await act.Unbox();
                }
            }

            var namesRep = new NamesRepository();

            for (int i = 0; i < 3; i++)
            {
                using var cts = new SimpleCanceller();

                Console.WriteLine($"- When All -------------------");

                var tasks = namesRep.GetValues(cts.Token)
                    .Where(e => e.Value.IsSuccess)
                    .Select(async e =>
                    {
                        try
                        {
                            Write(e.Key, await e.Value.Unbox());
                        }
                        catch (Exception ex)
                        {
                            Console.Write($"The {e.Key} is error, by {ex.GetType()} : {ex.Message}!\n");
                        }
                    })
                    .ToArray();

                await Task.WhenAll(tasks);

                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                using var cts = new SimpleCanceller();
                Console.WriteLine($"- Step by Step -------------------");

                foreach (var (key, value) in namesRep.GetValues(cts.Token))
                {
                    try
                    {
                        Write(key, await value.Unbox());
                    }
                    catch (Exception ex)
                    {
                        Console.Write($"The {key} is error, by {ex.GetType()} : {ex.Message}!\n");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void Write(string key, in CleanResult<string> res)
        {
            if (res)
            {
                Console.WriteLine($"The {key} is called {res.Result}!");
            }
            else
            {
                Console.WriteLine($"The {key} is {res.State}!");
            }
        }
    }
}
