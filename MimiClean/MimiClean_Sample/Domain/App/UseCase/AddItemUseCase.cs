namespace StudioIdGames.MimiClean_Sample.Domain.App.UseCase
{
    using Entity;
    using IApp.IRepository;
    using IApp.IService;
    using IApp.IUseCase;
    using IApp.UseCaseIO;
    using MimiClean;
    using MimiClean.Domain.App;
    using MimiCleanContainer;

    /// <summary>
    /// <see cref="IAddItemUseCase"/>を実装します。
    /// </summary>
    /// <typeparam name="TInt2D">利用する座標系</typeparam>
    /// <param name="serviceProvider"></param>
    public class AddItemUseCase<TInt2D>(MimiServiceProvider serviceProvider) : Usecase<AddItemInput>, IAddItemUseCase
    {
        public override CleanResult<CleanResult.Void> Excute(in CleanResult<AddItemInput> input)
        {
            if (!input.IsSuccess)
            {
                return input.AsVoid();
            }

            var x = input.Result.x;
            var y = input.Result.y;
            var name = input.Result.name;

            var items = serviceProvider.GetService<IItemMapRepository<TInt2D>>();
            var mapInfo = serviceProvider.GetService<IMapInfoRepository>().Value;
            var int2d = serviceProvider.GetService<IInt2DService<TInt2D>>();

            if (x < 0 || mapInfo.Width <= x)
            {
                return CleanResult.Failed(new AddItemError(this, AddItemErrorCase.IndexOutOfRangeX));
            }

            if (y < 0 || mapInfo.Height <= y)
            {
                return CleanResult.Failed(new AddItemError(this, AddItemErrorCase.IndexOutOfRangeY));
            }

            if (items.ContainsKey(int2d.New(x, y)))
            {
                return CleanResult.Failed(new AddItemError(this, AddItemErrorCase.DuplicatePosition));
            }

            var item = new ItemEntity<TInt2D>(serviceProvider.GetService<IInt2DService<TInt2D>>)
            {
                X = x,
                Y = y,
                ItemName = name
            };

            return items.TryAdd(item) ? CleanResult.Success() : CleanResult.Failed(new AddItemError(this, AddItemErrorCase.DuplicatePosition));
        }
    }
}
