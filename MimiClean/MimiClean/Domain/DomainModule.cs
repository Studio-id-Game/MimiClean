namespace StudioIdGames.MimiClean.Domain
{
    using IApp;
    using IDomain;

    /// <summary>
    /// <see cref="DomainEntity"/>の機能を分割、共有するモジュール機能の抽象クラスです。
    /// </summary>
    /// <typeparam name="TDomainEntity">親の<see cref="DomainEntity"/></typeparam>
    public abstract class DomainModule : IDomainModule
    {
        /// <summary>
        /// <see cref="DomainModule{TDomainEntity}"/>のコンストラクタ
        /// </summary>
        /// <param name="entity">親の<see cref="IDomainEntity"/></param>
        /// <param name="moduleName">モジュールのカスタム名。デフォルトは GetType().Name です。</param>
        protected DomainModule(ICurrentEntityService currentEntity, string moduleName = null)
        {
            Entity = currentEntity.CurrentEntity ??
                throw new System.ArgumentNullException(nameof(currentEntity.CurrentEntity));
            ModuleName = moduleName ?? GetType().Name;
        }

        /// <inheritdoc/>
        public IDomainEntity Entity { get; protected set; }

        /// <inheritdoc/>
        public string ModuleName { get; }
    }
}
