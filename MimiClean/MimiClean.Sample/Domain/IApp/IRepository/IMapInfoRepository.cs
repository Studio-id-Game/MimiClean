using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiCleanContainer;
using StudioIdGames.MimiClean_Sample.IDomain.IEntity;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IRepository
{
    [MimiServiceType(MimiServiceType.Static)]
    public interface IMapInfoRepository : IAppRepositoryMono<IMapInfoEntity>
    {
    }
}
