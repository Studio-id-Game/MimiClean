using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanSample.Domain.App.UseCase
{
    using IApp.IRepository;
    using IApp.IService;
    using IApp.IUseCase;
    using IApp.UseCaseIO;
    using IDomain.IEntity;

    public class MoveItemUseCase<TInt2D>(MimiServiceProvider serviceProvider) : Usecase<MoveItemInput, MoveItemOutput>, IMoveItemUseCase
    {
        public override CleanResult<MoveItemOutput> Excute(in CleanResult<MoveItemInput> input)
        {
            if (!input.IsSuccess)
            {
                return input.As<MoveItemOutput>(default);
            }

            var name = input.Result.name;
            var dx = input.Result.dx;
            var dy = input.Result.dy;
            var items = serviceProvider.GetService<IItemMapRepository<TInt2D>>();
            var mapInfo = serviceProvider.GetService<IMapInfoRepository>().Value;
            var int2D = serviceProvider.GetService<IInt2DService<TInt2D>>();
            var mapW = mapInfo.Width;
            var mapH = mapInfo.Height;


            bool found = false;

            List<(IItemEntity entity, int oldX, int oldY)> movedEntities = [];

            foreach (var item in items.Values.ToArray())
            {
                if (item.ItemName != name) continue;

                found = true;
                var xy = item.XY;
                var x = int2D.GetX(xy);
                var y = int2D.GetY(xy);

                var newX = Math.Max(0, Math.Min(mapW - 1, x + dx));
                var newY = Math.Max(0, Math.Min(mapH - 1, y + dy));
                var newXY = int2D.New(newX, newY);

                if (EqualityComparer<TInt2D>.Default.Equals(item.XY, newXY))
                {
                    continue;
                }

                if (items.ContainsKey(newXY))
                {
                    return CleanResult<MoveItemOutput>.Failed(new MoveItemError(this, MoveItemErrorCase.DuplicatePosition(item)));
                }

                items.Remove(item.XY);
                item.XY = newXY;
                items.TryAdd(item);
                movedEntities.Add((item, x, y));
            }

            if (!found)
            {
                return CleanResult<MoveItemOutput>.Failed(new MoveItemError(this, MoveItemErrorCase.NotFound(name)));
            }

            return CleanResult<MoveItemOutput>.Success(new MoveItemOutput([.. movedEntities]));
        }
    }
}
