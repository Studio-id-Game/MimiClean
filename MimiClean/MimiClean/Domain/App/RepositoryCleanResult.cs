namespace StudioIdGames.MimiClean.Domain.App
{
    using IApp;

    /// <summary>
    /// 値の取得に失敗する可能性のあるリスト型データストアを実装します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResult<TValue> : Repository<CleanResultBoxed<TValue>>, IAppRepositoryCleanResult<TValue>
    {
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
        public abstract class DefaultValues : CachingCollection<TValue>
        {
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
    }

    /// <summary>
    /// 値の取得に失敗する可能性のある辞書型データストアを実装します。
    /// </summary>
    /// <typeparam name="TKey">ストアに利用するKeyの型</typeparam>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public abstract class RepositoryCleanResultMap<TKey, TValue> : RepositoryMap<TKey, CleanResultBoxed<TValue>>, IAppRepositoryCleanResultMap<TKey, TValue>
    {
        public abstract class DefaultKeys : CachingCollection<TKey>
        {
        }

        public abstract class DefaultValues : CachingDictionary<TKey, TValue>
        {
        }
    }
}
