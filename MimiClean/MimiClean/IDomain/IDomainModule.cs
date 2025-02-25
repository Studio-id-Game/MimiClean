using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.IDomain
{
    /// <summary>
    /// <see cref="IDomainEntity"/>の機能を分割、共有するモジュール機能のインターフェースです。
    /// </summary>
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
