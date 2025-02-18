using StudioIdGames.MimiClean.Domain;

namespace StudioIdGames.MimiCleanSample.Domain.Modules
{
    internal class NameModule<TDomainObject>(TDomainObject domain) : DomainModule<TDomainObject>(domain)
        where TDomainObject : IDomainEntity
    {
        public string ItemName { get; set; } = "";
    }
}
