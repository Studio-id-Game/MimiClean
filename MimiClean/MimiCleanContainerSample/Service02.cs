using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainerSample
{
    internal class Service02_1(IService01 service01) : IService02
    {
        public IService01 Service01 { get; } = service01;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_1]" + Service01.Text);
    }


    internal class Service02_OtherConst(IServiceProvider provider) : IService02
    {
        public IService01 Service01 { get; } = provider.GetMimiService<IService01>()!;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_OtherConst]" + Service01.Text);
    }

    [MimiServiceType(MimiServiceType.Singleton)]
    internal class Service02_Singleton(MimiServiceProvider provider) : IService02
    {
        public IService01 Service01 { get; } = provider.GetService<IService01>()!;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_Singleton]" + Service01.Text);
    }

    [MimiServiceType(MimiServiceType.Scoped)]
    internal class Service02_Scoped(MimiServiceProvider provider) : IService02
    {
        public IService01 Service01 { get; } = provider.GetService<IService01>()!;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_Scoped]" + Service01.Text);
    }

    [MimiServiceType(MimiServiceType.Transient)]
    internal class Service02_Transient(MimiServiceProvider provider) : IService02
    {
        public IService01 Service01 { get; } = provider.GetService<IService01>()!;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_Transient]" + Service01.Text);
    }
}
