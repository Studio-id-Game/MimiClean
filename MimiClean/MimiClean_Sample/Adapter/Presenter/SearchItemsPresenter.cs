namespace StudioIdGames.MimiClean_Sample.Adapter.Presenter
{
    using IAdapter;
    using IApp.UseCaseIO;
    using StudioIdGames.MimiClean.Adapter;
    using StudioIdGames.MimiClean.Railway;

    /// <summary>
    /// <see cref="ISearchItems.IPresenter"/> を実装します。
    /// </summary>
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
