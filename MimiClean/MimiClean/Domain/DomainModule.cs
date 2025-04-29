namespace StudioIdGames.MimiClean.Domain
{
    using System;

    /// <summary>
    /// <see cref="DomainEntity"/>の機能を分割、共有するモジュール機能の抽象クラスです。
    /// </summary>

    public abstract class DomainModule
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
        /// 親の<see cref="DomainEntity"/>
        /// </summary>
        public DomainEntity Entity { get; protected set; }

        /// <summary>
        /// モジュールのカスタム名。デフォルトは <c> GetType().Name </c> です。
        /// </summary>
        public string ModuleName { get; }
    }
}
