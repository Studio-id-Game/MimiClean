using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiCleanContainer;
using StudioIdGames.MimiCleanSample.IDomain.IEntity;

namespace StudioIdGames.MimiCleanSample.Domain.IApp.IRepository
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
