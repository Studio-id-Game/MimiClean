﻿using Microsoft.Extensions.DependencyInjection;
using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Repository
{
    using EntityConfig;
    using IApp.IRepository;
    using IDomain.IEntity;

    /// <summary>
    /// <see cref="IMapInfoRepository"/> を実装します。マップサイズは20x20で固定です。
    /// </summary>
    public class MapInfoRepository20x20 : RepositoryMono<IMapInfoEntity>, IMapInfoRepository
    {
        public MapInfoRepository20x20(MimiServiceProvider mimiServiceProvider)
        {
            using var scope = mimiServiceProvider.CreateScope();

            var entity = scope.MimiServiceProvider()
                .Config<MapInfoConfig>(c => c.SetHeight(20).SetWidth(20))
                .GetService<IMapInfoEntity>();

            ValueProtected = new MonoValue(entity);
        }

        protected override MonoValue ValueProtected { get; }
    }
}
