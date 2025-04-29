namespace StudioIdGames.MimiClean.Domain
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="DomainModule"/>の特定の組み合わせを表現するクラスです。継承して利用する事も出来ます。
    /// </summary>

    public class DomainModuleSet : DomainModule, IReadOnlyCollection<DomainModule>
    {
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
        /// 継承先から内部のリストにアクセスするための関数
        /// </summary>
        protected IReadOnlyList<DomainModule> CustomModules => customModules;

        ///<inheritdoc/>
        public virtual int Count => customModules.Count;

        /// <summary>
        /// このセットに含まれる<see cref="DomainModule"/>を列挙します。
        /// （IDomainModuleSetを完全に廃止した際の<see cref="Get{T}"/>の動作です）
        /// </summary>
        /// <typeparam name="T">列挙するモジュールの型フィルター</typeparam>
        /// <param name="match">列挙の条件。nullの場合全ての <typeparamref name="T"/> を列挙します。</param>
        /// <returns>結果の列挙体</returns>
        public virtual IEnumerable<T> Get<T>(Predicate<T> match = null)
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

        ///<inheritdoc/>
        public virtual IEnumerator<DomainModule> GetEnumerator()
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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
