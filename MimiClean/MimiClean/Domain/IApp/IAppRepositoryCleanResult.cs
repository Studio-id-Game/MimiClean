using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain.IApp
{
    /// <summary>
    /// 値の取得に失敗する可能性のあるリスト型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryCleanResult<TValue> : IAppRepository<CleanResultBoxed<TValue>>
    {
    }

    /// <summary>
    /// 値の取得に失敗する可能性のある単一値型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryCleanResultMono<TValue> : IAppRepositoryMono<CleanResultBoxed<TValue>>
    {
    }

    /// <summary>
    /// 値の取得に失敗する可能性のある辞書型データストアを抽象化します。
    /// </summary>
    /// <typeparam name="TKey">ストアに利用するKeyの型</typeparam>
    /// <typeparam name="TValue">ストアする値の型</typeparam>
    public interface IAppRepositoryCleanResultMap<TKey, TValue> : IAppRepositoryMap<TKey, CleanResultBoxed<TValue>>
    {
    }
}
