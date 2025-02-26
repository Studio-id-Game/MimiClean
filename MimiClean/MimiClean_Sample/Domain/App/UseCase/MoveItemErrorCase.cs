namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using IDomain.IEntity;

    public readonly struct MoveItemErrorCase(MoveItemErrorCase.Type errorType, string itemName)
    {
        public enum Type
        {
            NotFound,
            DuplicatePosition,
        }

        public static MoveItemErrorCase NotFound(string itemName) => new(Type.NotFound, itemName);

        public static MoveItemErrorCase DuplicatePosition(IItemEntity item) => new(Type.DuplicatePosition, item.ItemName);

        public Type ErrorType { get; } = errorType;

        public string ItemName { get; } = itemName;

        public override string ToString()
        {
            return $"{ErrorType} (itemName:{ItemName})";
        }
    }
}
