namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// リスト型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class Repository<TValue> : IAppRepository<TValue>
    {
        /// <inheritdoc/>
        public int Count => ValuesProtected.Count;

        /// <summary>
        /// 内部のデータコレクション
        /// </summary>
        protected abstract IReadOnlyCollection<TValue> ValuesProtected { get; }

        /// <inheritdoc/>
        public IEnumerator<TValue> GetEnumerator()
        {
            return ValuesProtected.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)ValuesProtected).GetEnumerator();
        }
    }
}
