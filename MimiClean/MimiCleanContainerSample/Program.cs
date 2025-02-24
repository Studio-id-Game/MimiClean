using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainerSample
{
    public class Program
    {
        public static void ModeTest()
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

        public class PerformanceTest
        {
            private const int COUNT = 10000;

            /// <summary>
            /// [BenchmarkDotNet] Mean : 21.051 us | Error : 3.928 us | StdDev : 11.581 us
            /// </summary>
            [Benchmark]
            public void SingletonSetup()
            {
                var services = new MimiServiceContainer()
                    .Add<IService01, Service01_Singleton>();

                var p = services.BuildServiceProvider();
            }

            /// <summary>
            /// [BenchmarkDotNet] Mean : 6.325 us | Error : 1.075 us | StdDev :  3.170 us
            /// </summary>
            [Benchmark]
            public void StaticSetup()
            {
                var services = new MimiServiceContainer()
                    .Add<IService01, Service01_1>();

                var p = services.BuildServiceProvider();
            }

            /// <summary>
            /// [BenchmarkDotNet] Mean : 121.798 us | Error : 1.477 us | StdDev :  1.233 us |
            /// </summary>
            [Benchmark]
            public string Singleton()
            {
                var services = new MimiServiceContainer()
                    .Add<IService01, Service01_Singleton>();

                var p = services.BuildServiceProvider();

                string s = "";
                for (int i = 0; i < COUNT; i++)
                {
                    s = p.GetService<IService01>().Text;
                }

                return s;
            }

            /// <summary>
            /// [BenchmarkDotNet] Mean : 70.911 us | Error : 1.172 us | StdDev :  1.350 us |
            /// </summary>
            [Benchmark]
            public string Static()
            {
                var services = new MimiServiceContainer()
                    .Add<IService01, Service01_1>();

                var p = services.BuildServiceProvider();

                string s = "";
                for (int i = 0; i < COUNT; i++)
                {
                    s = p.GetService<IService01>().Text;
                }

                return s;
            }
        }

        private static void Main(string[] _)
        {
            BenchmarkRunner.Run<PerformanceTest>();
            // ModeTest();
        }
    }
}
