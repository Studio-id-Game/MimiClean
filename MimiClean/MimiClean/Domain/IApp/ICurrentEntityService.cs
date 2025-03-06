namespace StudioIdGames.MimiClean.Domain.IApp
{
    using MimiCleanContainer;

    using IDomain;
    using System;

    /// <summary>
    /// 現在の文脈における<see cref="IDomainEntity"/>を提供するサービスを抽象化します
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    [Obsolete("This feature is no longer useful.")]
    public interface ICurrentEntityService : IMimiService, IAppService
    {
        /// <summary>
        /// 現在の文脈における<see cref="IDomainEntity"/>のインスタンス
        /// </summary>
        IDomainEntity CurrentEntity { get; set; }
    }
}
