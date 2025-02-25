using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiClean.Domain.IApp;

namespace StudioIdGames.MimiCleanSample.Domain.Module
{
    using IDomain.IModule;

    public sealed class NameModule(ICurrentEntityService currentEntity, string? moduleName = null) : DomainModule(currentEntity, moduleName), INameModule
    {
        public string ItemName { get; set; } = "";
    }
}
