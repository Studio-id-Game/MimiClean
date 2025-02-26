using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.IDomain.IModule
{
    public interface INameModule : IDomainModule
    {
        string ItemName { get; set; }
    }
}
