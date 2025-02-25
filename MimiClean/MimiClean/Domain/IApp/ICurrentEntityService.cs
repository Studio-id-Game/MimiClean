using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.IApp
{
    using IDomain;

    [MimiServiceType(MimiServiceType.Static)]
    public interface ICurrentEntityService : IAppService
    {
        IDomainEntity CurrentEntity { get; set; }
    }
}
