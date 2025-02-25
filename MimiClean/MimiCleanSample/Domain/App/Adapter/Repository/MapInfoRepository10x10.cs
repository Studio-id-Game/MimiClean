using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Repository
{
    using EntityConfig;
    using IApp.IRepository;
    using IDomain.IEntity;

    public class MapInfoRepository10x10 : RepositoryMono<IMapInfoEntity>, IMapInfoRepository
    {
        public MapInfoRepository10x10(MimiServiceProvider mimiServiceProvider)
        {
            using var scope = mimiServiceProvider.CreateScope();

            var entity = scope.MimiServiceProvider()
                .Config<MapInfoConfig>(c => c.SetHeight(10).SetWidth(10))
                .GetService<IMapInfoEntity>();

            ValueProtected = new MonoValue(entity);
        }

        protected override MonoValue ValueProtected { get; }
    }
}
