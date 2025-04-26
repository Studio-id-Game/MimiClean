using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Adapter.Repository
{
    using IApp.IRepository;
    using StudioIdGames.MimiClean.App;
    using StudioIdGames.MimiClean.Collections;

    /// <summary>
    /// <see cref="IMapInfoRepository"/> を実装します。マップサイズは10x10で固定です。
    /// </summary>
    public class MapInfoRepository10x10 : RepositoryMono<MapInfoEntity>, IMapInfoRepository
    {
        public MapInfoRepository10x10(MimiServiceProvider mimiServiceProvider)
        {
            using var scope = mimiServiceProvider.CreateScope();

            var entity = new MapInfoEntity(10, 10);

            ValueProtected = new MonoCollection<MapInfoEntity>(entity);
        }

        protected override MonoCollection<MapInfoEntity> ValueProtected { get; }
    }
}
