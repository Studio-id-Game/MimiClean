namespace StudioIdGames.MimiClean_Sample.Domain.Module
{
    using StudioIdGames.MimiClean.Domain;
    using IDomain;

    /// <summary>
    /// <see cref="IItemNameProperty"/>を実装するモジュールです。
    /// </summary>
    /// <param name="currentEntity"></param>
    /// <param name="moduleName"></param>
    public sealed class ItemNameModule(DomainEntity entity, string? moduleName = null) : DomainModule(entity, moduleName), IItemNameProperty
    {
        /// <inheritdoc/>
        public string ItemName { get; set; } = "";
    }
}
