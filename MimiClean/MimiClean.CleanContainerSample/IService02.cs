using StudioIdGames.MimiClean.CleanContainer;

namespace StudioIdGames.MimiClean.CleanContainerSample
{
    internal interface IService02 : ITransientService
    {
        public void Set(string t);

        public void Print();
    }
}
