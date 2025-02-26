namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    using IDomain.IEntity;

    public readonly struct SearchItemsOutput(IEnumerable<IItemEntity> foundEntities)
    {
        public readonly IEnumerable<IItemEntity> foundEntities = foundEntities;
    }
}
