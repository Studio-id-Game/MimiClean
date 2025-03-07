namespace StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_SingleValue
{
    using StudioIdGames.MimiClean;
    using StudioIdGames.MimiClean.Domain.App;
    using StudioIdGames.MimiClean.Task;
    using System.Threading.Tasks;

    internal class Program
    {
        private class StartActRepository : RepositoryCleanResultMono<Task>
        {
            private class CountUp : CleanResultMonoValue
            {
                public override CleanResult<Task> Value => CleanResult.Success(GetValueAsync());

                private static async Task GetValueAsync()
                {
                    var text =

@"I am a sample program by ""StudioIdGames.Sample.MimiClean.Task.CleanResultExtension_SingleValue"".
Let's Start The Sample Program!!." + "\n\n";

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
                }
            }

            protected override ICleanResultMonoValue ValueCleanResultProtected { get; } = new CountUp();
        }

        private class CountRepository : RepositoryCleanResultMono<Task<int>>
        {
            private class CountUp : CleanResultMonoValue
            {
                private int num = 1;

                public override CleanResult<Task<int>> Value => CleanResult.Success(GetValueAsync());

                private async Task<int> GetValueAsync()
                {
                    await Task.Delay(1000);
                    return num++;
                }
            }

            protected override ICleanResultMonoValue ValueCleanResultProtected { get; } = new CountUp();
        }

        private static void Main(string[] args)
        {
            var task = MainAsync(args);
            task.Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            var startActRep = new StartActRepository();

            await startActRep.Value;

            var countRep = new CountRepository();
            for (int i = 0; i < 10; i++)
            {
                Write(await countRep.Value);
            }
        }

        private static void Write(in CleanResult<int> res)
        {
            Console.WriteLine($"{res.State}, {res.Result}");
        }
    }
}
