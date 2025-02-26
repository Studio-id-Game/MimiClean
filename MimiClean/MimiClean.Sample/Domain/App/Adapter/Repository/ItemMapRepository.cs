using StudioIdGames.MimiClean.Domain.App;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Repository
{
    using IApp.IRepository;
    using IDomain.IEntity;

    public sealed class ItemMapRepository<TInt2D> : RepositoryMap<TInt2D, IItemEntity<TInt2D>>, IItemMapRepository<TInt2D>
        where TInt2D : notnull
    {
        private readonly Dictionary<TInt2D, IItemEntity<TInt2D>> map = [];

        public IEnumerable<string> ItemNames => map.Values.Select(v => v.ItemName);

        protected override IReadOnlyDictionary<TInt2D, IItemEntity<TInt2D>> MapProtected => map;

        public bool Remove(TInt2D key)
        {
            return map.Remove(key);
        }

        public bool TryAdd(IItemEntity<TInt2D> value)
        {
            return map.TryAdd(value.XY, value);
        }
    }
}
