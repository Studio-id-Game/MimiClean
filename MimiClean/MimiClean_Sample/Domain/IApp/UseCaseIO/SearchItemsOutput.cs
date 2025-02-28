namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    using IDomain.IEntity;

    /// <summary>
    /// アイテム検索の結果出力データ
    /// </summary>
    /// <param name="foundEntities">検索にマッチしたアイテムのリスト</param>
    public readonly struct SearchItemsOutput(IEnumerable<IItemEntity> foundEntities)
    {
        /// <summary>
        /// 検索にマッチしたアイテムのリスト
        /// </summary>
        public readonly IEnumerable<IItemEntity> foundEntities = foundEntities;
    }
}
