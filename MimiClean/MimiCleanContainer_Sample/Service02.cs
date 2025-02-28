using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainer_Sample
{
    /// <summary>
    /// <see cref="IService02"/>の実装
    /// </summary>
    /// <param name="service01">DIで注入する<see cref="IService01"/></param>
    public class Service02_Default(IService01 service01) : IService02
    {
        public IService01 Service01 { get; } = service01;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_Default]" + Service01.Text);
    }

    /// <summary>
    /// <see cref="IService02"/>の実装。（<see cref="IServiceProvider"/> でコンストラクトするバージョン）
    /// </summary>
    /// <param name="provider">DIで注入する<see cref="IServiceProvider"/></param>
    public class Service02_OtherConst(IServiceProvider provider) : IService02
    {
        public IService01 Service01 { get; } = provider.GetMimiService<IService01>()!;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_OtherConst]" + Service01.Text);
    }

    /// <summary>
    /// <see cref="IService02"/>の実装。（<see cref="MimiServiceType.Singleton"/> で上書き）
    /// </summary>
    /// <param name="provider">DIで注入する<see cref="IServiceProvider"/></param>
    [MimiServiceType(MimiServiceType.Singleton)]
    public class Service02_Singleton(IService01 service01) : IService02
    {
        public IService01 Service01 { get; } = service01;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_Singleton]" + Service01.Text);
    }

    /// <summary>
    /// <see cref="IService02"/>の実装。（<see cref="MimiServiceType.Scoped"/> で上書き）
    /// </summary>
    [MimiServiceType(MimiServiceType.Scoped)]
    public class Service02_Scoped(IService01 service01) : IService02
    {
        public IService01 Service01 { get; } = service01;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_Scoped]" + Service01.Text);
    }

    /// <summary>
    /// <see cref="IService02"/>の実装。（<see cref="MimiServiceType.Transient"/> で上書き）
    /// </summary>
    [MimiServiceType(MimiServiceType.Transient)]
    public class Service02_Transient(IService01 service01) : IService02
    {
        public IService01 Service01 { get; } = service01;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine("[02_Transient]" + Service01.Text);
    }
}
