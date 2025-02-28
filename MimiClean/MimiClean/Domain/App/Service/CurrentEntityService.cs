using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.Service
{
    using IApp;
    using IDomain;

    /// <summary>
    /// 現在の文脈における<see cref="IDomainEntity"/>を提供するサービスを実装します
    /// </summary>
    public sealed class CurrentEntityService : IStaticService, ICurrentEntityService
    {
        public IDomainEntity CurrentEntity { get; set; }
    }
}
