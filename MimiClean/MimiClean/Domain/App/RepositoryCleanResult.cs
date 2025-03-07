namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 値の取得に失敗する可能性のあるリスト型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResult<TValue> : Repository<CleanResultBoxed<TValue>>, IAppRepositoryCleanResult<TValue>
    {
        [Obsolete("Use CachingCollection<TValue>")]
        public abstract class DefaultValues : CachingCollection<TValue>
        {
        }
    }

    /// <summary>
    /// 値の取得に失敗する可能性のある単一値型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResultMono<TValue> : RepositoryMono<CleanResultBoxed<TValue>>, IAppRepositoryCleanResultMono<TValue>
    {
        [Obsolete("Use IMonoValueCleanResult and CachingCollection<TValue>")]
        public abstract class DefaultValues : CachingCollection<TValue>, ICleanResultMonoValue
        {
            public CleanResult<TValue> Value => GetValueProtected();

            CleanResultBoxed<TValue> IMonoValue.Value => Value.Box();

            public override CleanResult<int> GetCount()
            {
                var v = GetValueProtected();
                return v.As(v ? 1 : 0);
            }

            protected override CleanResult<TValue> GetValueProtected(int index)
            {
                return GetValueProtected();
            }

            protected abstract CleanResult<TValue> GetValueProtected();
        }

        public interface ICleanResultMonoValue : IMonoValue
        {
            new CleanResult<TValue> Value { get; }
        }

        public abstract class CleanResultMonoValue : ICleanResultMonoValue
        {
            public abstract CleanResult<TValue> Value { get; }

            public int Count
            {
                get
                {
                    var v = Value;
                    return v.As(v.IsSuccess ? 1 : 0);
                }
            }

            CleanResultBoxed<TValue> IMonoValue.Value => Value.Box();

            public IEnumerator<CleanResultBoxed<TValue>> GetEnumerator()
            {
                yield return Value.Box();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                yield return Value.Box();
            }
        }

        protected override sealed IMonoValue ValueProtected => ValueCleanResultProtected;

        protected abstract ICleanResultMonoValue ValueCleanResultProtected { get; }

        public new CleanResult<TValue> Value => ValueCleanResultProtected.Value;
    }

    /// <summary>
    /// 値の取得に失敗する可能性のある辞書型データストアを実装します。
    /// </summary>
    /// <typeparam name="TKey">ストアに利用するKeyの型</typeparam>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResultMap<TKey, TValue> : RepositoryMap<TKey, CleanResultBoxed<TValue>>, IAppRepositoryCleanResultMap<TKey, TValue>
    {
        [Obsolete("Use CachingCollection<TValue>")]
        public abstract class DefaultKeys : CachingCollection<TKey>
        {
        }

        [Obsolete("Use CachingDictionary<TKey, TValue>")]
        public abstract class DefaultValues : CachingDictionary<TKey, TValue>
        {
        }
    }
}
