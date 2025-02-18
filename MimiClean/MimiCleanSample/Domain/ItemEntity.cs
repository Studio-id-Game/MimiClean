using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiCleanSample.Domain.Modules;

namespace StudioIdGames.MimiCleanSample.Domain
{
    internal class ItemEntity : DomainEntity
    {
        public ItemEntity()
        {
            ItemModuleSet = new ItemModuleSet<ItemEntity>(this);
        }

        public ItemModuleSet<ItemEntity> ItemModuleSet { get; }
        public NameModule<ItemEntity> NameModule => ItemModuleSet.NameModule;
        public Int2DPosModule<ItemEntity> Int2DPosModule => ItemModuleSet.Int2DPosModule;

        public override IEnumerable<T> M<T>() => ItemModuleSet.Get<T>();
    }
}
