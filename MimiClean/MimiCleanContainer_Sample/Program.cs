using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainer_Sample
{
    public class Program
    {
        /// <summary>
        /// <see cref="MimiServiceType"/> による振る舞いの違い等をテストする為の関数。
        /// </summary>
        public static void ModeTest()
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine();

            // You cna select services type (TInstance of .Add<TInterface, TInstance>()).
            var services = new MimiServiceContainer()
                .Add<IService01, Service01_Scoped>()
                .Add<IService02, Service02_Transient>();

            var p = services.BuildServiceProvider();

            using var scope = p.CreateScope();
            var provider = scope.MimiServiceProvider();
            var s2 = provider.GetService<IService02>()!;

            s2.Print();
            Console.WriteLine("<SET SET_01>");
            s2.Set("SET_01");
            s2.Print();
            Console.WriteLine();

            using (var scope2 = provider.CreateScope())
            {
                Console.WriteLine("<Scope Start>");
                var p2 = scope2.MimiServiceProvider();
                var s22 = p2.GetService<IService02>()!;
                s22.Print();
                Console.WriteLine("<SET SET_02>");
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

        /// <summary>
        /// BenchmarkDotNet による、Staticモードのパフォーマンステスト。計測結果のMeanがCOUNTにほぼ比例している事から、Staticモードの純粋アクセスタイムはSingletonモードの約7%である事が確認できます。
        /// <code>
        /// Mean   : Arithmetic mean of all measurements
        /// Error  : Half of 99.9% confidence interval
        /// StdDev : Standard deviation of all measurements
        /// 1 us   : 1 Microsecond(0.000001 sec)
        ///
        /// COUNT = 10000
        /// | Method    | Mean       | Error      | StdDev    |
        /// |---------- |-----------:|-----------:|----------:|
        /// | Scoped    |  55.128 us |  1.9950 us | 0.1094 us |
        /// | Transient |  58.733 us | 23.3906 us | 1.2821 us |
        /// | Singleton |  40.426 us |  5.9840 us | 0.3280 us |
        /// | Static    |   2.823 us |  0.0584 us | 0.0032 us |
        ///
        /// COUNT = 10000 * 100
        /// | Method    | Mean       | Error      | StdDev    |
        /// |---------- |-----------:|-----------:|----------:|
        /// | Scoped    | 5,400.4 us |  278.15 us |  15.25 us |
        /// | Transient | 6,005.7 us |  410.92 us |  22.52 us |
        /// | Singleton | 3,952.1 us |  123.56 us |   6.77 us |
        /// | Static    |   282.7 us |    5.61 us |   0.31 us |（めちゃはやいらしい…。…:*…:*=…:*三(o'ω')o
        /// </code>
        /// </summary>
        [ShortRunJob]
        public class PerformanceTest
        {
            private const int COUNT = 1000000;

            private readonly MimiServiceProvider serviceProviderScoped = new MimiServiceContainer()
                    .Add<IService01, Service01_Scoped>()
                    .BuildServiceProvider();

            private readonly MimiServiceProvider serviceProviderTransient = new MimiServiceContainer()
                    .Add<IService01, Service01_Transient>()
                    .BuildServiceProvider();

            private readonly MimiServiceProvider serviceProviderSingleton = new MimiServiceContainer()
                    .Add<IService01, Service01_Singleton>()
                    .BuildServiceProvider();

            private readonly MimiServiceProvider serviceProviderStatic = new MimiServiceContainer()
                    .Add<IService01, Service01_Static>()
                    .BuildServiceProvider();

            [Benchmark]
            public IService01? Scoped()
            {
                return Test(serviceProviderScoped);
            }

            [Benchmark]
            public IService01? Transient()
            {
                return Test(serviceProviderTransient);
            }

            [Benchmark]
            public IService01? Singleton()
            {
                return Test(serviceProviderSingleton);
            }

            [Benchmark]
            public IService01? Static()
            {
                return Test(serviceProviderStatic);
            }

            public static IService01? Test(MimiServiceProvider serviceProvider)
            {
                IService01? s = null;
                for (int i = 0; i < COUNT; i++)
                {
                    s = serviceProvider.GetService<IService01>();
                }

                return s;
            }
        }

        private static void Main(string[] _)
        {
            Console.Write("SelectMode (1:PerformanceTest, other:ModeTest) : ");
            var key = Console.ReadKey().Key;
            Console.WriteLine();

            if (key == ConsoleKey.D1)
            {
                Console.WriteLine();
                BenchmarkRunner.Run<PerformanceTest>();
            }
            else
            {
                ModeTest();
            }
        }
    }
}
