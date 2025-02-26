using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiCleanContainer;
using StudioIdGames.MimiCleanSample.IDomain.IEntity;

namespace StudioIdGames.MimiCleanSample.Domain.IApp.IRepository
{
    [MimiServiceType(MimiServiceType.Static)]
    public interface IMapInfoRepository : IAppRepositoryMono<IMapInfoEntity>
    {
    }
}
