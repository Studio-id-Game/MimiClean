using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.IDomain.IEntity
{
    /// <summary>
    /// 全てのマップ情報エンティティを抽象化します。
    /// </summary>
    public interface IMapInfoEntity : IDomainEntity
    {
        /// <summary>
        /// マップの高さ
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// マップの幅
        /// </summary>
        public int Width { get; }
    }
}
