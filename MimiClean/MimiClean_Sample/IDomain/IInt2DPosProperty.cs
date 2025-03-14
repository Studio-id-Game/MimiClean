namespace StudioIdGames.MimiClean_Sample.IDomain
{
    /// <summary>
    /// 全ての２次元整数座標モジュールを抽象化します。
    /// </summary>
    public interface IInt2DPosProperty
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
    public interface IInt2DPosProperty<TInt2D> : IInt2DPosProperty
    {
        /// <summary>
        /// ２次元整数座標
        /// </summary>
        public TInt2D XY { get; set; }
    }
}
