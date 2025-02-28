namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    /// <summary>
    /// アイテム検索に用いる入力データ
    /// </summary>
    /// <param name="name">アイテム名</param>
    public readonly struct SearchItemsInput(string name)
    {
        /// <summary>
        /// アイテム名
        /// </summary>
        public readonly string name = name;
    }
}
