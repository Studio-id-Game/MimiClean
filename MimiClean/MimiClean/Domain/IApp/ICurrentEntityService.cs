using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.IApp
{
    using IDomain;

    /// <summary>
    /// 現在の文脈における<see cref="IDomainEntity"/>を提供するサービスを抽象化します
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    public interface ICurrentEntityService : IAppService
    {
        /// <summary>
        /// 現在の文脈における<see cref="IDomainEntity"/>のインスタンス
        /// </summary>
        IDomainEntity CurrentEntity { get; set; }
    }
}
