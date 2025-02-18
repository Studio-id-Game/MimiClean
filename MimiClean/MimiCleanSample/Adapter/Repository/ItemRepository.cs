using StudioIdGames.MimiCleanSample.App.Repository;
using StudioIdGames.MimiCleanSample.Domain;

namespace StudioIdGames.MimiCleanSample.Adapter.Repository
{
    internal class ItemRepository01 : ItemRepositoryAbstract<ItemRepository01>
    {
        protected override IList<ItemEntity> List { get; } = [];
    }

    internal class ItemRepository02 : ItemRepositoryAbstract<ItemRepository02>
    {
        //You can develop other List class for another way.
        //For example, File-based system.
        protected override IList<ItemEntity> List { get; } = [];
    }
}
