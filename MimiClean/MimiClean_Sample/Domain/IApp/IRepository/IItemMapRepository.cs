using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiCleanContainer;
using StudioIdGames.MimiClean_Sample.IDomain.IEntity;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IRepository
{
    [MimiServiceType(MimiServiceType.Static)]
    public interface IItemMapRepository : IAppRepository
    {
        public IEnumerable<string> ItemNames { get; }
    }

    public interface IItemMapRepository<TInt2D> : IItemMapRepository, IAppRepositoryMap<TInt2D, IItemEntity<TInt2D>>
    {
        public bool TryAdd(IItemEntity<TInt2D> value);

        public bool Remove(TInt2D key);
    }
}
