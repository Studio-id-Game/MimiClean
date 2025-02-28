using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiClean_Sample.IDomain.IEntity;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IRepository
{
    /// <summary>
    /// 全てのアイテムマップリポジトリを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    public interface IItemMapRepository : IAppRepository
    {
        /// <summary>
        /// アイテムの名前一覧
        /// </summary>
        public IEnumerable<string> ItemNames { get; }
    }

    /// <summary>
    /// 座標が <typeparamref name="TInt2D"/> で表されるアイテムマップリポジトリを抽象化します。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    public interface IItemMapRepository<TInt2D> : IItemMapRepository, IAppRepositoryMap<TInt2D, IItemEntity<TInt2D>>
    {
        /// <summary>
        /// 座標を持ったアイテムの追加を試みます。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>アイテムの追加に成功した時ture</returns>
        public bool TryAdd(IItemEntity<TInt2D> value);

        /// <summary>
        /// 指定座標のアイテムを削除します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TInt2D key);
    }
}
