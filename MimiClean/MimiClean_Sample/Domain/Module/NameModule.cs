using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiClean.Domain.IApp;

namespace StudioIdGames.MimiClean_Sample.Domain.Module
{
    using IDomain.IModule;

    /// <summary>
    /// <see cref="INameModule"/>を実装します。
    /// </summary>
    /// <param name="currentEntity"></param>
    /// <param name="moduleName"></param>
    public sealed class NameModule(ICurrentEntityService currentEntity, string? moduleName = null) : DomainModule(currentEntity, moduleName), INameModule
    {
        public string ItemName { get; set; } = "";
    }
}
