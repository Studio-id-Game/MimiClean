using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Repository
{
    using IApp.IRepository;
    using Entity;

    /// <summary>
    /// <see cref="IMapInfoRepository"/> を実装します。マップサイズは10x10で固定です。
    /// </summary>
    public class MapInfoRepository10x10 : RepositoryMono<MapInfoEntity>, IMapInfoRepository
    {
        public MapInfoRepository10x10(MimiServiceProvider mimiServiceProvider)
        {
            using var scope = mimiServiceProvider.CreateScope();

            var entity = new MapInfoEntity(10, 10);

            ValueProtected = new MonoValue(entity);
        }

        protected override MonoValue ValueProtected { get; }
    }
}
