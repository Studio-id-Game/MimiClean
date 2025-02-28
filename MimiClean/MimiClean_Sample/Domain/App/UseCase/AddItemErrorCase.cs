namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    /// <summary>
    /// アイテムを追加する動作のエラー内容
    /// </summary>
    public enum AddItemErrorCase
    {
        /// <summary>
        /// Mapの幅を超えた場所にアイテムを追加しようとした
        /// </summary>
        IndexOutOfRangeX,

        /// <summary>
        /// Mapの高さを超えた場所にアイテムを追加しようとした
        /// </summary>
        IndexOutOfRangeY,

        /// <summary>
        /// すでにアイテムがある場所にアイテムを追加しようとした
        /// </summary>
        DuplicatePosition
    }
}
