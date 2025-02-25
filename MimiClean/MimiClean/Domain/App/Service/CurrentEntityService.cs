using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.Service
{
    using IApp;
    using IDomain;

    public sealed class CurrentEntityService : IStaticService, ICurrentEntityService
    {
        public IDomainEntity CurrentEntity { get; set; }
    }
}
