using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.App.Repository;

namespace StudioIdGames.MimiCleanSample.App.UseCase
{
    internal class SearchItems : Interactor<SearchItemsInput, SearchItemsOutput>
    {
        public override CleanResult<SearchItemsOutput> Excute(in CleanResult<SearchItemsInput> input)
        {
            if (!input.IsSuccess)
            {
                return input.As<SearchItemsOutput>(default);
            }

            var name = input.Result.name;

            var positions = Repository<IItemRepository>.I
                .Where(e => e.NameModule.ItemName == name)
                .Select(e => (e.Int2DPosModule.X, e.Int2DPosModule.Y))
                .ToArray();

            return CleanResult<SearchItemsOutput>.Success(new SearchItemsOutput(positions));
        }
    }
}
