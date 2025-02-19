namespace StudioIdGames.MimiClean.Domain
{
    /// <summary>
    /// <see cref="DomainEntity"/>の機能を分割、共有するモジュール機能の抽象クラスです。
    /// </summary>
    /// <typeparam name="TDomainEntity">親の<see cref="DomainEntity"/></typeparam>
    public abstract class DomainModule<TDomainEntity> : IDomainModule
        where TDomainEntity : IDomainEntity
    {
        /// <summary>
        /// <see cref="DomainModule{TDomainEntity}"/>のコンストラクタ
        /// </summary>
        /// <param name="entity">親の<see cref="DomainEntity"/></param>
        /// <param name="moduleName">モジュールのカスタム名。デフォルトは GetType().Name です。</param>
        protected DomainModule(TDomainEntity entity, string moduleName = null)
        {
            Entity = entity;
            ModuleName = moduleName ?? GetType().Name;
        }

        /// <inheritdoc cref="IDomainModule.Entity"/>
        public TDomainEntity Entity { get; }

        /// <inheritdoc/>
        public string ModuleName { get; }

        /// <inheritdoc/>
        IDomainEntity IDomainModule.Entity => Entity;
    }
}
