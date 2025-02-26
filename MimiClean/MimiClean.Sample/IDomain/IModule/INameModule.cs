using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiCleanSample.IDomain.IModule
{
    public interface INameModule : IDomainModule
    {
        string ItemName { get; set; }
    }
}
