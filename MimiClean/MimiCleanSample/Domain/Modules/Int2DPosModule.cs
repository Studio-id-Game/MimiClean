using StudioIdGames.MimiClean.Domain;

namespace StudioIdGames.MimiCleanSample.Domain.Modules
{
    internal class Int2DPosModule<TDomainObject>(TDomainObject domain) : DomainModule<TDomainObject>(domain)
        where TDomainObject : IDomainEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
