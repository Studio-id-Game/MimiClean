using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Repository
{
    using Entity;
    using IApp.IRepository;
    using StudioIdGames.MimiClean.Collections;

    /// <summary>
    /// <see cref="IMapInfoRepository"/> を実装します。マップサイズは20x20で固定です。
    /// </summary>
    public class MapInfoRepository20x20 : RepositoryMono<MapInfoEntity>, IMapInfoRepository
    {
        public MapInfoRepository20x20(MimiServiceProvider mimiServiceProvider)
        {
            using var scope = mimiServiceProvider.CreateScope();

            var entity = new MapInfoEntity(20, 20);

            ValueProtected = new MonoCollection<MapInfoEntity>(entity);
        }

        protected override MonoCollection<MapInfoEntity> ValueProtected { get; }
    }
}
