using StudioIdGames.MimiCleanContainer;
using StudioIdGames.MimiClean;

namespace StudioIdGames.MimiClean_Sample
{
    using Domain.App.Adapter;
    using Domain.App.Adapter.Gateway;
    using Domain.App.IAdapter;
    using Domain.IApp.IRepository;
    using StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Repository;

    public class Program
    {
        public static MimiServiceProvider InitServices()
        {
            var container = new MimiServiceContainer();
            MimiCleanSetup.SetDefaultService(container);
            AdapterSetup.SetDefaultService_Tuple(container);

            Console.Write("Please select mode (d:Dummy, other:default) : ");

            if (Console.ReadKey().Key == ConsoleKey.D)
            {
                // 各種リポジトリとサービスをカスタムする
                container.Add<IAddItem.IGateway, AddItemGatewayDummy>()
                         .Add<IMoveItem.IGateway, MoveItemGatewayDummy>()
                         .Add<ISearchItems.IGateway, SearchItemsGatewayDummy>();
            }

            Console.WriteLine();

            Console.Write("Please select mapSize(a:10x10, other:20x20) : ");

            if (Console.ReadKey().Key == ConsoleKey.A)
            {
                container.Add<IMapInfoRepository, MapInfoRepository10x10>();
            }
            else
            {
                container.Add<IMapInfoRepository, MapInfoRepository20x20>();
            }

            Console.WriteLine();

            // 各種リポジトリとサービスをビルドする
            return container.BuildServiceProvider();
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
