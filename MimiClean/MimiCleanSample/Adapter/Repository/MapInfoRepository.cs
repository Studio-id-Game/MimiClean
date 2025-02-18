using StudioIdGames.MimiCleanSample.Domain;

namespace StudioIdGames.MimiCleanSample.Adapter.Repository
{
    internal class MapInfoRepository10x10 : App.Repository.MapInfoRepositoryAbstract<MapInfoRepository10x10>
    {
        public override MapInfoEntity Value { get; } = new MapInfoEntity(10, 10);
    }

    internal class MapInfoRepository20x20 : App.Repository.MapInfoRepositoryAbstract<MapInfoRepository20x20>
    {
        public override MapInfoEntity Value { get; } = new MapInfoEntity(20, 20);
    }
}
