using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainerSample
{
    internal class Program
    {
        private static void Main(string[] _)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine();

            var services = new MimiServiceContainer()
                .Add<IService01, Service01_1>()
                .Add<IService02, Service02_Transient>();
            var p = services.BuildServiceProvider();

            using var scope = p.CreateScope();
            var provider = scope.MimiServiceProvider();
            var s2 = provider.GetService<IService02>()!;

            s2.Print();
            s2.Set("SET_01");
            s2.Print();
            Console.WriteLine();

            using (var scope2 = provider.CreateScope())
            {
                Console.WriteLine("<Scope Start>");
                var p2 = scope2.MimiServiceProvider();
                var s22 = p2.GetService<IService02>()!;
                s22.Print();
                s22.Set("SET_02");
                s22.Print();
                Console.WriteLine();

                s22 = p2.GetService<IService02>()!;
                s22.Print();
                Console.WriteLine("<Scope END>");
                Console.WriteLine();
            }

            s2 = provider.GetService<IService02>()!;
            s2.Print();
        }
    }
}
