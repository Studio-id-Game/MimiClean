namespace StudioIdGames.MimiClean.IDomain
{
    using MimiCleanContainer;
    using System;

    /// <summary>
    /// <see cref="IDomainEntity"/>の機能を分割、共有するモジュール機能のインターフェースです。<br/>
    /// Domain層をinterface化するのは Bad Pattern なので非推奨になりました。
    /// </summary>
    [Obsolete("Use StudioIdGames.MimiClean.Domain.DomainModule")]
    public interface IDomainModule : ITransientService
    {
        /// <summary>
        /// 親の<see cref="IDomainEntity"/>
        /// </summary>
        IDomainEntity Entity { get; }

        /// <summary>
        /// モジュールのカスタム名。デフォルトは GetType().Name です。
        /// </summary>
        string ModuleName { get; }
    }
}
