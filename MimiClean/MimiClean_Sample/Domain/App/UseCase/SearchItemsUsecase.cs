using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using IApp.IRepository;
    using IApp.IUseCase;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="ISearchItemsUseCase"/> の実装
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    /// <param name="serviceProvider"></param>
    public class SearchItemsUsecase<TInt2D>(MimiServiceProvider serviceProvider) : Usecase<SearchItemsInput, SearchItemsOutput>, ISearchItemsUseCase
    {
        public override CleanResult<SearchItemsOutput> Excute(in CleanResult<SearchItemsInput> input)
        {
            if (!input.IsSuccess)
            {
                return input.As<SearchItemsOutput>(default);
            }

            var name = input.Result.name;

            var entities = serviceProvider.GetService<IItemMapRepository<TInt2D>>()
                .Values
                .Where(e => e.ItemName == name)
                .ToArray();

            return CleanResult<SearchItemsOutput>.Success(new SearchItemsOutput(entities));
        }
    }
}
