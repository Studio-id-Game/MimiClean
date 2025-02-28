namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    /// <summary>
    /// アイテム追加に用いる入力データ
    /// </summary>
    /// <param name="name">アイテム名</param>
    /// <param name="x">x座標</param>
    /// <param name="y">y座標</param>
    public readonly struct AddItemInput(string name, int x, int y)
    {
        /// <summary>
        /// x座標
        /// </summary>
        public readonly int x = x;

        /// <summary>
        /// y座標
        /// </summary>
        public readonly int y = y;

        /// <summary>
        /// アイテム名
        /// </summary>
        public readonly string name = name;
    }
}
