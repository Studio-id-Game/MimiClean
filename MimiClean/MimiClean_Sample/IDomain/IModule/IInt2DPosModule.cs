using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.IDomain.IModule
{
    /// <summary>
    /// 全ての２次元整数座標モジュールを抽象化します。
    /// </summary>
    public interface IInt2DPosModule : IDomainModule
    {
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
    /// <typeparamref name="TInt2D"/>型の２次元整数座標モジュールを抽象化します。
    /// </summary>
    public interface IInt2DPosModule<TInt2D> : IInt2DPosModule
    {
        /// <summary>
        /// ２次元整数座標
        /// </summary>
        public TInt2D XY { get; set; }
    }
}
