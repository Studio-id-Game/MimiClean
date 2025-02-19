using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    /// <summary>
    /// <see cref="IDomainModule"/>の特定の組み合わせを表現するクラスです。継承して利用する事も出来ます。
    /// </summary>
    /// <typeparam name="TDomainEntity">親の<see cref="DomainEntity"/></typeparam>
    public class DomainModuleSet<TDomainEntity> : DomainModule<TDomainEntity>, IDomainModuleSet, IEnumerable<IDomainModule>
        where TDomainEntity : IDomainEntity
    {
        private readonly List<IDomainModule> customModules = new List<IDomainModule>();

        /// <summary>
        /// <see cref="DomainModuleSet{TDomainEntity}"/>のコンストラクタ
        /// </summary>
        /// <param name="entity">親の<see cref="DomainEntity"/></param>
        /// <param name="moduleName">モジュールのカスタム名。デフォルトは GetType().Name です。</param>
        public DomainModuleSet(TDomainEntity entity, string moduleName = null) : base(entity, moduleName)
        {
        }

        /// <summary>
        /// 継承先から内部のリストにアクセスするための関数
        /// </summary>
        protected IReadOnlyList<IDomainModule> CustomModules => customModules;

        /// <summary>
        /// セット内のモジュールの数
        /// </summary>
        public virtual int Count => customModules.Count;

        ///<inheritdoc/>
        public virtual IEnumerable<T> Get<T>()
            where T : class, IDomainModule
        {
            foreach (var module in customModules)
            {
                if (module is T moduleT) yield return moduleT;
            }
        }

        ///<inheritdoc/>
        public virtual bool Add<T>()
            where T : class, IDomainModule, new()
        {
            return Add(new T());
        }

        ///<inheritdoc/>
        public virtual bool Add<T>(T value)
            where T : class, IDomainModule
        {
            customModules.Add(value);
            return true;
        }

        ///<inheritdoc/>
        public virtual bool Remove<T>(T value) where T : class, IDomainModule
        {
            return customModules.Remove(value);
        }

        ///<inheritdoc/>
        public virtual IEnumerator<IDomainModule> GetEnumerator()
        {
            // yield return UniqueModule01; 
            // yield return UniqueModule02; 

            foreach (var module in customModules)
            {
                yield return module;
            }
        }

        ///<inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IDomainModule>)this).GetEnumerator();
        }
    }
}
