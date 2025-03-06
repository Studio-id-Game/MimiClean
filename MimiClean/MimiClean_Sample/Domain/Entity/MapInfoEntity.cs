namespace StudioIdGames.MimiClean_Sample.Domain.Entity
{
    using StudioIdGames.MimiClean.Domain;

    /// <summary>
    /// <see cref="IMapInfoEntity"/> を実装します。
    /// </summary>
    public sealed class MapInfoEntity(int height, int width) : DomainEntity
    {
        /// <summary>
        /// マップの高さ
        /// </summary>
        public int Height { get; } = height;

        /// <summary>
        /// マップの幅
        /// </summary>
        public int Width { get; } = width;
    }
}
