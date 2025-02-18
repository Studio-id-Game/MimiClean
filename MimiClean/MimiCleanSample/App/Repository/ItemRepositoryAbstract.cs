using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.Domain;

namespace StudioIdGames.MimiCleanSample.App.Repository
{
    internal abstract class ItemRepositoryAbstract<TSelf> : RepositoryAsList<IItemRepository, TSelf, ItemEntity>, IItemRepository
        where TSelf : ItemRepositoryAbstract<TSelf>, new()
    {
    }
}
