namespace StudioIdGames.MimiClean.Domain
{
    using IDomain;
    using StudioIdGames.MimiClean.Domain.IApp;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="DomainModule"/>の特定の組み合わせを表現するクラスです。継承して利用する事も出来ます。
    /// </summary>
#pragma warning disable CS0618 // 型またはメンバーが旧型式です IDomainModuleSet

    public class DomainModuleSet : DomainModule, IReadOnlyCollection<DomainModule>, IDomainModuleSet
#pragma warning restore CS0618 // 型またはメンバーが旧型式です IDomainModuleSet
    {
        [Obsolete("IDomainModuleを完全に削除した時にcustomModulesに統一する")]
        private readonly List<IDomainModule> customModulesOld = new List<IDomainModule>();

        private readonly List<DomainModule> customModules = new List<DomainModule>();

        /// <summary>
        /// <see cref="DomainModuleSet"/>のコンストラクタ
        /// </summary>
        /// <param name="entity">親の<see cref="DomainEntity"/></param>
        /// <param name="moduleName">モジュールのカスタム名。デフォルトは GetType().Name です。</param>
        public DomainModuleSet(DomainEntity entity, string moduleName = null) : base(entity, moduleName)
        {
        }

        /// <summary>
        /// <see cref="DomainModuleSet"/>のコンストラクタ
        /// </summary>
        /// <param name="currentEntity">親の<see cref="DomainEntity"/></param>
        /// <param name="moduleName">モジュールのカスタム名。デフォルトは GetType().Name です。</param>
        ///
        [Obsolete("This feature is no longer useful.")]
        public DomainModuleSet(ICurrentEntityService currentEntity, string moduleName = null) : base(currentEntity, moduleName)
        {
        }

        /// <summary>
        /// 継承先から内部のリストにアクセスするための関数
        /// （IDomainModuleを完全に廃止した時、<see cref="CustomModules_v2"/> の動作に変更します）
        /// </summary>
        [Obsolete("IDomainModule is Obsoleted.")]
        protected IReadOnlyList<IDomainModule> CustomModules => customModulesOld;

        /// <summary>
        /// 継承先から内部のリストにアクセスするための関数
        /// （IDomainModuleを完全に廃止した際の<see cref="CustomModules"/>の動作です）
        /// </summary>
        protected IReadOnlyList<DomainModule> CustomModules_v2 => customModules;

        ///<inheritdoc/>
#pragma warning disable CS0618 // 型またはメンバーが旧型式です customModulesOld
        public virtual int Count => customModules.Count + customModulesOld.Count;
#pragma warning restore CS0618 // 型またはメンバーが旧型式です customModulesOld

        ///<inheritdoc/>
        [Obsolete("IDomainModuleSet is Obsoleted.")]
        public virtual IEnumerable<T> Get<T>()
            where T : class, IDomainModule
        {
            foreach (var module in customModulesOld)
            {
                if (module is T moduleT) yield return moduleT;
            }
        }

        ///<inheritdoc/>
        [Obsolete("IDomainModuleSet is Obsoleted.")]
        public virtual bool Add<T>()
            where T : class, IDomainModule, new()
        {
            return Add(new T());
        }

        ///<inheritdoc/>
        [Obsolete("IDomainModuleSet is Obsoleted.")]
        public virtual bool Add<T>(T value)
            where T : class, IDomainModule
        {
            customModulesOld.Add(value);
            return true;
        }

        ///<inheritdoc/>
        [Obsolete("IDomainModuleSet is Obsoleted.")]
        public virtual bool Remove<T>(T value) where T : class, IDomainModule
        {
            return customModulesOld.Remove(value);
        }

        ///<inheritdoc/>
        [Obsolete("IDomainModuleSet is Obsoleted.")]
        public virtual IEnumerator<IDomainModule> GetEnumerator()
        {
            // yield return UniqueModule01;
            // yield return UniqueModule02;

            foreach (var module in customModulesOld)
            {
                yield return module;
            }
        }

        /// <summary>
        /// このセットに含まれる<see cref="DomainModule"/>を列挙します。
        /// （IDomainModuleSetを完全に廃止した際の<see cref="Get{T}"/>の動作です）
        /// </summary>
        /// <typeparam name="T">列挙するモジュールの型フィルター</typeparam>
        /// <param name="match">列挙の条件。nullの場合全ての <typeparamref name="T"/> を列挙します。</param>
        /// <returns>結果の列挙体</returns>
        public virtual IEnumerable<T> Get_v2<T>(Predicate<T> match = null)
            where T : DomainModule
        {
            if (match == null)
            {
                foreach (var module in customModules)
                {
                    if (module is T moduleT) yield return moduleT;
                }
            }
            else
            {
                foreach (var module in customModules)
                {
                    if (module is T moduleT && match(moduleT)) yield return moduleT;
                }
            }
        }

        /// <summary>
        /// モジュールをセットに追加します。
        /// </summary>
        /// <param name="value">追加するモジュールのインスタンス</param>
        /// <returns>追加に成功した時のみtrue</returns>
        public virtual bool CustomAdd(DomainModule value)
        {
            customModules.Add(value);
            return true;
        }

        /// <summary>
        /// モジュールをセットから除外します。
        /// </summary>
        /// <param name="value">除外するモジュールのインスタンス</param>
        /// <returns>除外に成功した時のみtrue</returns>
        public virtual bool CustomRemove(DomainModule value)
        {
            return customModules.Remove(value);
        }

        /// <summary>
        /// 条件が一致する全てのモジュールをセットから除外します。
        /// </summary>
        /// <param name="match">除外の条件</param>
        /// <returns>除外に成功した時のみtrue</returns>
        public virtual int CustomRemoveAll(Predicate<DomainModule> match)
        {
            return customModules.RemoveAll(match);
        }

        /// <summary>
        /// このセットに含まれる<see cref="DomainModule"/>を列挙します。
        /// （IDomainModuleSetを完全に廃止した際の<see cref="GetEnumerator"/>の動作です）
        /// </summary>
        public virtual IEnumerator<DomainModule> GetEnumerator_v2()
        {
            var modules = customModules;

            // yield return UniqueModule01;
            // yield return UniqueModule02;

            foreach (var m in modules)
            {
                yield return m;
            }
        }

        ///<inheritdoc/>
        IEnumerator<DomainModule> IEnumerable<DomainModule>.GetEnumerator()
        {
            return GetEnumerator_v2();
        }

        /// <summary>
        /// IDomainModuleSetを完全に廃止した際のデフォルト列挙体としての動作です。
        /// foreach でv2の動作を実現できます。
        /// </summary>
        public IEnumerable<DomainModule> Enum_v2 => this;

        ///<inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
#pragma warning disable CS0618 // 型またはメンバーが旧型式です GetEnumerator()
            foreach (var module in this)
            {
                yield return module;
            }
#pragma warning restore CS0618 // 型またはメンバーが旧型式です GetEnumerator()

            foreach (var module in Enum_v2)
            {
                yield return module;
            }
        }
    }
}
