using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.Entity
{
    using IDomain.IEntity;
    using StudioIdGames.MimiClean_Sample.Domain.EntityConfig;

    public sealed class MapInfoEntity : DomainEntity, IMapInfoEntity
    {
        public int Height { get; }

        public int Width { get; }

        public MapInfoEntity(MimiServiceProvider serviceProvider, MapInfoConfig config) : base(serviceProvider)
        {
            using var _ = new CreateEntityScope(serviceProvider, this);

            Height = config.Height;
            Width = config.Width;
        }
    }
}
