using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainerSample
{
    internal class Service02(IServiceProvider provider) : IService02
    {
        public IService01 Service01 { get; } = provider.GetMimiService<IService01>()!;

        public void Set(string t) => Service01.Text = t;

        public void Print() => Console.WriteLine(Service01.Text);
    }
}
