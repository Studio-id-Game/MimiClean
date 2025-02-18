
using StudioIdGames.MimiClean.Domain;

namespace StudioIdGames.MimiCleanSample.Domain
{
    internal class MapInfoEntity(int height, int width) : DomainEntity
    {
        public int Height { get; } = height;
        public int Width { get; } = width;
    }
}
