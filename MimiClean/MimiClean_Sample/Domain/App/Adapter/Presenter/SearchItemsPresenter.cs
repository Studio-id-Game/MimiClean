using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Presenter
{
    using IAdapter;
    using IApp.UseCaseIO;

    public class SearchItemsPresenter : Presenter<SearchItemsOutput>, ISearchItems.IPresenter
    {
        public override CleanResult<CleanResult.Void> Present(in CleanResult<SearchItemsOutput> usecaseOutput)
        {
            if (usecaseOutput.IsSuccess)
            {
                if (usecaseOutput.Result.foundEntities.Any())
                {
                    Console.WriteLine($"Items Found.");
                    foreach (var entity in usecaseOutput.Result.foundEntities)
                    {
                        Console.WriteLine($"\t[{entity.ItemName}] ({entity.X}, {entity.Y})");
                    }
                }
                else
                {
                    Console.WriteLine($"Item NotFound.");
                }
            }

            return usecaseOutput.AsVoid();
        }
    }
}
