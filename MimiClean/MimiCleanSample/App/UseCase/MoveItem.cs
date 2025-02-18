using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiCleanSample.App.Repository;
using StudioIdGames.MimiCleanSample.Domain.Service;

namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal class MoveItem : Interactor<MoveItemInput, MoveItemOutput>
    {
        public sealed class MoveItemNotFoundError(string itemName, Interactor<MoveItemInput, MoveItemOutput> interactor) : InteractorError(interactor)
        {
            public string ItemName { get; } = itemName;
            public override string Message => $"An item named \"{ItemName}\" is not found in the map.";
        }


        public override CleanResult<MoveItemOutput> Excute(in CleanResult<MoveItemInput> input)
        {
            if (!input.IsSuccess)
            {
                return input.As<MoveItemOutput>(default);
            }

            var name = input.Result.name;
            var dx = input.Result.dx;
            var dy = input.Result.dy;
            var items = Repository<IItemRepository>.I;
            var mapInfo = Repository<IMapInfoRepository>.I.Value;

            var item = items.FirstOrDefault(e => e.NameModule.ItemName == name);

            if (item == null)
            {
                return CleanResult<MoveItemOutput>.Failed(new MoveItemNotFoundError(name, this));
            }

            var mapW = mapInfo.Width;
            var mapH = mapInfo.Height;
            var (itemX, itemY) = Service<IInt2DPosService>.I.Add((item.Int2DPosModule.X, item.Int2DPosModule.Y), (dx, dy));

            if (itemX < 0) { itemX = 0; }
            else if (itemX >= mapW) { itemX = mapW - 1; }

            if (itemY < 0) { itemY = 0; }
            else if (itemY >= mapH) { itemY = mapH - 1; }

            item.Int2DPosModule.X = itemX;
            item.Int2DPosModule.Y = itemY;

            return CleanResult<MoveItemOutput>.Success(new MoveItemOutput(itemX, itemY));
        }
    }
}
