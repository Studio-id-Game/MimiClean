namespace StudioIdGames.MimiClean.Domain
{
    /// <summary>
    /// <see cref="DomainEntity"/>の機能を分割、共有するモジュール機能のインターフェースです。
    /// </summary>
    public interface IDomainModule
    {
        /// <summary>
        /// 親の<see cref="DomainEntity"/>
        /// </summary>
        IDomainEntity Entity { get; }

        /// <summary>
        /// モジュールのカスタム名。デフォルトは GetType().Name です。
        /// </summary>
        string ModuleName { get; }
    }
}
