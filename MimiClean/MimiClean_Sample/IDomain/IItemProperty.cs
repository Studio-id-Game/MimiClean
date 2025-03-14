namespace StudioIdGames.MimiClean_Sample.IDomain
{
    /// <summary>
    /// 全てのアイテムを表すモジュール群を抽象化します。
    /// </summary>
    public interface IItemProperty : IInt2DPosProperty, IItemNameProperty
    {
        /// <summary>
        /// アイテム名プロパティ
        /// </summary>
        IItemNameProperty ItemNameProperty { get; }

        /// <summary>
        /// アイテム座標プロパティ
        /// </summary>
        IInt2DPosProperty Int2DPosProperty { get; }
    }

    /// <summary>
    /// <typeparamref name="TInt2D"/>を座標としたアイテムを表すモジュール群を抽象化します。
    /// </summary>
    public interface IItemProperty<TInt2D> : IItemProperty, IInt2DPosProperty<TInt2D>
    {
        /// <summary>
        /// アイテム座標プロパティ
        /// </summary>
        new IInt2DPosProperty<TInt2D> Int2DPosProperty { get; }
    }
}
