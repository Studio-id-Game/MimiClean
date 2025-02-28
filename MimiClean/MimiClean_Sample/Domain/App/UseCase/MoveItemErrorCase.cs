namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using IDomain.IEntity;

    /// <summary>
    /// アイテムを移動する動作のエラー内容
    /// </summary>
    /// <param name="errorType"> エラー種別 </param>
    /// <param name="itemName"> エラー原因のアイテム名 </param>
    public readonly struct MoveItemErrorCase(MoveItemErrorCase.Type errorType, string itemName)
    {
        /// <summary>
        /// アイテムを移動する動作のエラー種別
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// マッチするアイテムが見つからなかった
            /// </summary>
            NotFound,

            /// <summary>
            /// 移動中に他のアイテムに衝突した
            /// </summary>
            DuplicatePosition,
        }

        /// <summary>
        /// マッチするアイテムが見つからなかった場合の内容を返すファクトリー
        /// </summary>
        /// <param name="itemName">エラー原因のアイテム名</param>
        /// <returns></returns>
        public static MoveItemErrorCase NotFound(string itemName) => new(Type.NotFound, itemName);

        /// <summary>
        /// 移動中に他のアイテムに衝突した場合の内容を返すファクトリー
        /// </summary>
        /// <param name="itemName">エラー原因のアイテム名</param>
        /// <returns></returns>
        public static MoveItemErrorCase DuplicatePosition(string itemName) => new(Type.DuplicatePosition, itemName);

        /// <summary>
        /// エラー種別
        /// </summary>
        public Type ErrorType { get; } = errorType;

        /// <summary>
        /// エラー原因のアイテム名
        /// </summary>
        public string ItemName { get; } = itemName;

        public override string ToString()
        {
            return $"{ErrorType} (itemName:{ItemName})";
        }
    }
}
