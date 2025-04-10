namespace StudioIdGames.MimiClean.Collections
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 単一値を表すコレクション
    /// </summary>
    public class MonoCollection<TValue> : IMonoCollection<TValue>
    {
        /// <inheritdoc/>
        public TValue Value { get; set; }

        /// <inheritdoc/>
        public int Count => 1;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="value">ストアする単一の値</param>
        public MonoCollection(TValue value = default)
        {
            Value = value;
        }

        /// <inheritdoc/>
        public IEnumerator<TValue> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value;
        }
    }
}
