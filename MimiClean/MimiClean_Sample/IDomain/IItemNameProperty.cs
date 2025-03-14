namespace StudioIdGames.MimiClean_Sample.IDomain
{
    /// <summary>
    /// 全てのアイテム名モジュールを抽象化します。
    /// </summary>
    public interface IItemNameProperty
    {
        /// <summary>
        /// アイテム名
        /// </summary>
        string ItemName { get; set; }
    }
}
