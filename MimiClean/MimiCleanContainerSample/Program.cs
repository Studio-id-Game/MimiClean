using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainerSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var services = new MimiServiceContainer()
                .Add<IService01, Service01>()
                .Add<IService02, Service02>();
            var p = services.BuildServiceProvider();

            using var scope = p.CreateScope();
            var provider = scope.MimiServiceProvider();
            var s2 = provider.GetService<IService02>()!;
            s2.Print();

            s2.Set("TESTES");
            s2.Print();

            using (var scope2 = provider.CreateScope())
            {
                var p2 = scope2.MimiServiceProvider();
                var s22 = p2.GetService<IService02>();
                s22!.Print();
                s22.Set("TESTES2");
                s22 = p2.GetService<IService02>();
                s22!.Print();
            }

            s2.Print();
        }
    }
}
