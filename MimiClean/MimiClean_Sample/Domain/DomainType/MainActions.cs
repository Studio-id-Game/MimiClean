namespace StudioIdGames.MimiClean_Sample.Domain.DomainType
{
    /// <summary>
    /// プログラムの基本操作を表す列挙型です
    /// </summary>
    public enum MainActions
    {
        /// <summary>
        /// 何の操作もあらわさない初期値
        /// </summary>
        None,

        /// <summary>
        /// アイテムの追加操作
        /// </summary>
        AddItem,

        /// <summary>
        /// アイテムの移動操作
        /// </summary>
        MoveItem,

        /// <summary>
        /// アイテムの検索操作
        /// </summary>
        SearchItems,

        /// <summary>
        /// プログラムの終了操作
        /// </summary>
        Exit,
    }
}
