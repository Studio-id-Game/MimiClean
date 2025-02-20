using StudioIdGames.MimiClean.CleanContainer;

namespace StudioIdGames.MimiClean.CleanContainerSample
{
    internal interface IService01 : IScopedService
    {
        public string Text { get; set; }
    }
}
