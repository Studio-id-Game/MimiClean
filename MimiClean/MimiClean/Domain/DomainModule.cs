namespace StudioIdGames.MimiClean.Domain
{
    using IDomain;
    using StudioIdGames.MimiClean.Domain.IApp;
    using System;

    /// <summary>
    /// <see cref="DomainEntity"/>の機能を分割、共有するモジュール機能の抽象クラスです。
    /// </summary>
#pragma warning disable CS0618 // 型またはメンバーが旧型式です

    public abstract class DomainModule : IDomainModule
#pragma warning restore CS0618 // 型またはメンバーが旧型式です
    {
        /// <summary>
        /// <see cref="DomainModule"/>のコンストラクタ
        /// </summary>
        /// <param name="entity">親の<see cref="DomainEntity"/></param>
        /// <param name="moduleName">モジュールのカスタム名。デフォルトは <c> GetType().Name </c> です。</param>
        protected DomainModule(DomainEntity entity, string moduleName = null)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            ModuleName = moduleName ?? GetType().Name;
        }

        /// <summary>
        /// <see cref="DomainModule"/>のコンストラクタ
        /// </summary>
        /// <param name="currentEntity">親の<see cref="IDomainEntity"/></param>
        /// <param name="moduleName">モジュールのカスタム名。デフォルトは GetType().Name です。</param>
        [Obsolete("This feature is no longer useful.")]
        protected DomainModule(ICurrentEntityService currentEntity, string moduleName = null)
            : this(currentEntity.CurrentEntity as DomainEntity, moduleName)
        {
        }

        /// <summary>
        /// 親の<see cref="DomainEntity"/>
        /// </summary>
        public DomainEntity Entity { get; protected set; }

        /// <summary>
        /// モジュールのカスタム名。デフォルトは <c> GetType().Name </c> です。
        /// </summary>
        public string ModuleName { get; }

        [Obsolete("IDomainModule is Obsoleted.")]
        IDomainEntity IDomainModule.Entity => Entity;
    }
}
