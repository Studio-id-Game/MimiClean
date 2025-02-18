using StudioIdGames.MimiClean.Domain;

namespace StudioIdGames.MimiCleanSample.Domain.Modules
{
    internal class ItemModuleSet<TDomainEntity>(TDomainEntity entity) : DomainModuleSet<TDomainEntity>(entity)
        where TDomainEntity : IDomainEntity
    {
        public NameModule<TDomainEntity> NameModule { get; } = new NameModule<TDomainEntity>(entity);

        public Int2DPosModule<TDomainEntity> Int2DPosModule { get; } = new Int2DPosModule<TDomainEntity>(entity);

        public override int Count => base.Count + 2;

        public override IEnumerable<T> Get<T>()
        {
            if (NameModule is T nameModuleT) yield return nameModuleT;
            if (Int2DPosModule is T int2DPosModuleT) yield return int2DPosModuleT;
            foreach (var item in base.Get<T>()) yield return item;
        }

        public override IEnumerator<IDomainModule> GetEnumerator()
        {
            yield return NameModule;
            yield return Int2DPosModule;
            foreach (var module in CustomModules)
            {
                yield return module;
            }
        }
    }
}
