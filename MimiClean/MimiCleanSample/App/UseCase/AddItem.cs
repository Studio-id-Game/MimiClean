using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.App.Repository;

namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal class AddItem : Interactor<AddItemInput>
    {
        public enum AddItemErrorCase
        {
            IndexOutOfRangeX,
            IndexOutOfRangeY,
            DuplicatePosition
        }

        public sealed class AddItemError(AddItem interactor, AddItemErrorCase errorCase) : InteractorError(interactor)
        {
            public AddItemErrorCase Case { get; } = errorCase;

            public override string Message => Case switch
            {
                AddItemErrorCase.IndexOutOfRangeX => "Position x is over the size of the map.",
                AddItemErrorCase.IndexOutOfRangeY => "Position y is over the size of the map.",
                AddItemErrorCase.DuplicatePosition => "Already exists an item at the same position on the map.",
                _ => "Unknown error.",
            };
        }

        public override CleanResult<CleanResult.Void> Excute(in CleanResult<AddItemInput> input)
        {
            if (!input.IsSuccess)
            {
                return input.AsVoid();
            }

            var x = input.Result.x;
            var y = input.Result.y;
            var name = input.Result.name;

            var items = Repository<IItemRepository>.I;
            var mapInfo = Repository<IMapInfoRepository>.I.Value;

            if (x < 0 || mapInfo.Width <= x)
            {
                return CleanResult.Failed(new AddItemError(this, AddItemErrorCase.IndexOutOfRangeX));
            }

            if (y < 0 || mapInfo.Height <= y)
            {
                return CleanResult.Failed(new AddItemError(this, AddItemErrorCase.IndexOutOfRangeY));
            }

            if (items.Any(e => e.Int2DPosModule.X == x && e.Int2DPosModule.Y == y))
            {
                return CleanResult.Failed(new AddItemError(this, AddItemErrorCase.DuplicatePosition));
            }

            var item = new Domain.ItemEntity();
            item.Int2DPosModule.X = x;
            item.Int2DPosModule.Y = y;
            item.NameModule.ItemName = name;

            items.Add(item);
            return CleanResult.Success();
        }
    }
}
