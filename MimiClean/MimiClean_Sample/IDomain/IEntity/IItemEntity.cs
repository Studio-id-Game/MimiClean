using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.IDomain.IEntity
{
    using IDomain.IModule;

    /// <summary>
    /// 全てのアイテムエンティティを抽象化します。
    /// </summary>
    public interface IItemEntity : IDomainEntity
    {
        /// <summary>
        /// アイテムを定義するモジュールセット
        /// </summary>
        IItemModuleSet ItemModuleSet { get; }

        /// <summary>
        /// アイテム名
        /// </summary>
        string ItemName { get; set; }

        /// <summary>
        /// x座標
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y座標
        /// </summary>
        public int Y { get; set; }
    }

    /// <summary>
    /// <typeparamref name="TInt2D"/>を座標とするアイテムエンティティを抽象化します。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    public interface IItemEntity<TInt2D> : IItemEntity
    {
        /// <summary>
        /// アイテムを定義するモジュールセット
        /// </summary>
        new IItemModuleSet<TInt2D> ItemModuleSet { get; }

        /// <summary>
        /// ２次元整数座標
        /// </summary>
        public TInt2D XY { get; set; }
    }
}
