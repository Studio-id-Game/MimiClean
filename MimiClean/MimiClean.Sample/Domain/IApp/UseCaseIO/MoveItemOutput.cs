namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    using IDomain.IEntity;

    public readonly struct MoveItemOutput(IEnumerable<(IItemEntity entity, int oldX, int oldY)> movedEntities)
    {
        public readonly IEnumerable<(IItemEntity entity, int oldX, int oldY)> movedEntities = movedEntities;
    }
}
