using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.IDomain.IModule
{
    /// <summary>
    /// 全てのアイテムを表すモジュール群を抽象化します。
    /// </summary>
    public interface IItemModuleSet : IDomainModuleSet, IInt2DPosModule, INameModule
    {
        /// <summary>
        /// アイテム名モジュール
        /// </summary>
        INameModule NameModule { get; }

        /// <summary>
        /// アイテム座標モジュール
        /// </summary>
        IInt2DPosModule Int2DPosModule { get; }
    }

    /// <summary>
    /// <typeparamref name="TInt2D"/>を座標としたアイテムを表すモジュール群を抽象化します。
    /// </summary>
    public interface IItemModuleSet<TInt2D> : IItemModuleSet, IInt2DPosModule<TInt2D>
    {
        /// <summary>
        /// アイテム座標モジュール
        /// </summary>
        new IInt2DPosModule<TInt2D> Int2DPosModule { get; }
    }
}
