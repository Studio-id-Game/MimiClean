using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Adapter;
using StudioIdGames.MimiCleanSample.App.UseCase;

namespace StudioIdGames.MimiCleanSample.Adapter.Presenter
{
    internal static class ItemPresenters
    {
        internal class AddItemPresenter : IPresenter
        {
            public CleanResult<CleanResult.Void> Present(in CleanResult<CleanResult.Void> usecaseOutput)
            {
                if (usecaseOutput.IsSuccess)
                {
                    Console.WriteLine("Item Added.");
                }

                return usecaseOutput;
            }
        }

        internal class MoveItemPresenter : IPresenter<MoveItemOutput>
        {
            public CleanResult<CleanResult.Void> Present(in CleanResult<MoveItemOutput> output)
            {
                if (output.IsSuccess)
                {
                    Console.WriteLine($"Item Moved. (movedXY:{output.Result.movedX},{output.Result.movedY})");
                }

                return output.AsVoid();
            }
        }

        internal class SearchItemsPresenter : IPresenter<SearchItemsOutput>
        {
            public CleanResult<CleanResult.Void> Present(in CleanResult<SearchItemsOutput> output)
            {
                if (output.IsSuccess)
                {
                    if (output.Result.find)
                    {
                        Console.WriteLine($"Items Found.");
                        foreach (var (x, y) in output.Result.positions)
                        {
                            Console.WriteLine($"\txy : {x}, \t{y}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Item NotFound.");
                    }
                }

                return output.AsVoid();
            }
        }
    }
}
