using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Presenter
{
    using IAdapter;
    using IApp.UseCaseIO;

    public class MoveItemPresenter : Presenter<MoveItemOutput>, IMoveItem.IPresenter
    {
        public override CleanResult<CleanResult.Void> Present(in CleanResult<MoveItemOutput> usecaseOutput)
        {
            if (usecaseOutput.IsSuccess)
            {
                if (usecaseOutput.Result.movedEntities.Any())
                {
                    Console.WriteLine($"Items Moved.");
                    foreach (var (entity, oldX, oldY) in usecaseOutput.Result.movedEntities)
                    {
                        Console.WriteLine($"\t[{entity.ItemName}] ({oldX}, {oldY}) => ({entity.X}, {entity.Y})");
                    }
                }
                else
                {
                    Console.WriteLine($"Items found but can not Move.");
                }
            }

            return usecaseOutput.AsVoid();
        }
    }
}
