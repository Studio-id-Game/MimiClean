using StudioIdGames.MimiClean.Domain;
using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// 現在利用されている<see cref="IRepository"/>インスタンスへのシンプルなアクセスを提供します。
    /// </summary>
    /// <typeparam name="TInterface">Repositoryを定義しているインターフェース</typeparam>
    public static class Repository<TInterface>
        where TInterface : class, IRepository
    {
        /// <summary>
        /// 現在利用されているRepository。nullの場合エラーをスローします。
        /// </summary>
        public static TInterface I => SingletonMap<TInterface>.Instance;
    }

    /// <summary>
    /// データストアを表現するための抽象クラスです。
    /// </summary>
    /// <typeparam name="TInterface">実体化する対象のインターフェースの型</typeparam>
    /// <typeparam name="TSelf">自身の型</typeparam>
    /// <typeparam name="TValue"></typeparam>
    public abstract class Repository<TInterface, TSelf, TValue> : Singleton<TInterface, TSelf>, IRepository<TValue>
        where TInterface : class, IRepository
        where TSelf : Repository<TInterface, TSelf, TValue>, TInterface, new()
    {
        /// <inheritdoc/>
        public abstract IEnumerator<TValue> GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TValue>)this).GetEnumerator();
        }
    }
}