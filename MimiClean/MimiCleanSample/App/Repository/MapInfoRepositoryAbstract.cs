using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.Domain;

namespace StudioIdGames.MimiCleanSample.App.Repository
{
    internal abstract class MapInfoRepositoryAbstract<TSelf> : RepositoryAsSingle<IMapInfoRepository, TSelf, MapInfoEntity>, IMapInfoRepository
        where TSelf : MapInfoRepositoryAbstract<TSelf>, new()
    {
    }
}
