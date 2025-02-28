namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    using IDomain.IEntity;

    /// <summary>
    /// アイテム移動の結果出力データ
    /// </summary>
    /// <param name="movedEntities">移動したアイテムと移動前座標のリスト</param>
    public readonly struct MoveItemOutput(IEnumerable<(IItemEntity entity, int oldX, int oldY)> movedEntities)
    {
        /// <summary>
        /// 移動したアイテムと移動前座標のリスト
        /// </summary>
        public readonly IEnumerable<(IItemEntity entity, int oldX, int oldY)> movedEntities = movedEntities;
    }
}
