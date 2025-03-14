namespace StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_SingleValue
{
    using StudioIdGames.MimiClean;
    using StudioIdGames.MimiClean.Collections;
    using StudioIdGames.MimiClean.Domain.App;
    using StudioIdGames.MimiClean.Task;
    using System.Threading.Tasks;

    internal class Program
    {
        private class StartActRepository : RepositoryCleanResultMono<Task>
        {
            private class CountUp : CleanResultMonoValue
            {
                public override CleanResult<Task> GetValue(CancellationToken cancellationToken)
                {
                    return CleanResult.Success(GetValueAsync(cancellationToken));
                }

                private static async Task GetValueAsync(CancellationToken cancellationToken = default)
                {
                    var text =
@"I am a sample program by ""StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_SingleValue"".
Let's Start The Sample Program!!" + "\n\n";

                    try
                    {
                        foreach (var item in text)
                        {
                            Console.Write(item);
                            if (item == '\n')
                            {
                                await Task.Delay(200, cancellationToken);
                            }
                            else
                            {
                                await Task.Delay(20, cancellationToken);
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine();
                    }
                }
            }

            protected override ICleanResultMonoCollection<Task> ValueCleanResultProtected { get; } = new CountUp();
        }

        private class CountRepository : RepositoryCleanResultMono<Task<int>>
        {
            private class CountUp : CleanResultMonoValue
            {
                private int num = 1;

                public override CleanResult<Task<int>> GetValue(CancellationToken cancellationToken)
                {
                    return CleanResult.Success(GetValueAsync(cancellationToken));
                }

                private Task<int> GetValueAsync(CancellationToken cancellationToken = default)
                {
                    var _cancellationToken = cancellationToken;

                    return Task.Run(async () =>
                    {
                        await Task.Delay(200, _cancellationToken);

                        if (Random.Shared.NextDouble() < 0.75)
                        {
                            return num++;
                        }
                        else
                        {
                            throw new Exception("Dummy Error");
                        }
                    });
                }
            }

            protected override ICleanResultMonoCollection<Task<int>> ValueCleanResultProtected { get; } = new CountUp();
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
            var countRep = new CountRepository();

            using (var cts = new SimpleCanceller())
            {
                await startActRep.GetValue(cts.Token);
            }

            using (var cts = new SimpleCanceller())
            {
                for (int i = 0; i < 20; i++)
                {
                    Write(i, await countRep.GetValue(cts.Token));
                }
            }
        }

        private static void Write(int index, in CleanResult<int> res)
        {
            Console.WriteLine($"[{index}] {res.State}, {res.Result}");
        }
    }
}
