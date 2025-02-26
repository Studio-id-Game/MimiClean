using StudioIdGames.MimiClean.Domain.App;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanSample
{
    using Domain.App.Adapter;
    using Domain.App.Adapter.Gateway;
    using Domain.App.IAdapter;
    using Domain.IApp.IRepository;

    public class Program
    {
        public static MimiServiceProvider InitServices()
        {
            var container = new MimiServiceContainer();
            MimiCleanAppSetup.SetDefaultService(container);
            AdapterSetup.SetDefaultService_Tuple(container);

            // 各種リポジトリとサービスをカスタムしてビルドする
            // TODO : AddItem以外、set instance twice の例外が出る。
            return container
                .Add<IAddItem.IGateway, AddItemGatewayDummy>()
                .Add<IMoveItem.IGateway, MoveItemGatewayDummy>()
                .Add<ISearchItems.IGateway, SearchItemsGatewayDummy>()
                .BuildServiceProvider();

            /*
            // 各種リポジトリとサービスをビルドする
            return container.BuildServiceProvider();
            */
        }

        public static void Main(/* string[] args */)
        {
            var serviceProvider = InitServices();

            var mapInfo = serviceProvider.GetService<IMapInfoRepository>().Value;

            Console.WriteLine($"MapInfo : WH = {mapInfo.Width}, {mapInfo.Height}");

            while (true)
            {
                var mainController = serviceProvider.GetService<ISelectMainAction>();
                mainController.Invoke();
                Console.WriteLine();
            }
        }
    }
}
