namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    /// <summary>
    /// アイテム移動に用いる入力データ
    /// </summary>
    /// <param name="name">アイテム名</param>
    /// <param name="dx">x座標増加分</param>
    /// <param name="dy">y座標増加分</param>
    public readonly struct MoveItemInput(string name, int dx, int dy)
    {
        /// <summary>
        /// アイテム名
        /// </summary>
        public readonly string name = name;

        /// <summary>
        /// x座標増加分
        /// </summary>
        public readonly int dx = dx;

        /// <summary>
        /// y座標増加分
        /// </summary>
        public readonly int dy = dy;
    }
}
