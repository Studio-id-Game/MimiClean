using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.Adapter.Controller;
using StudioIdGames.MimiCleanSample.Adapter.Repository;
using StudioIdGames.MimiCleanSample.Adapter.Service;
using StudioIdGames.MimiCleanSample.App.Repository;
using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample
{
    internal class Program
    {
        static Program()
        {
            //各種リポジトリとサービスを有効にする
            ItemRepository01.Use();
            //ItemRepository02.Use();
            MapInfoRepository20x20.Use();
            //MapInfoRepository20x20.Use();
            Int2DPosService01.Use();
            //Int2DPosService02.Use();
            MainActionService.Use();
        }

        private static void Main(/* string[] args */)
        {
            var mapInfo = Repository<IMapInfoRepository>.I.Value;

            Console.WriteLine($"MapInfo : WH = {mapInfo.Width}, {mapInfo.Height}");

            while (true)
            {
                var mainController = SelectMainActionController.Default;
                var result = mainController.Invoke();

                if (result.State == CleanResultState.Success)
                {
                    if (result.Result == MainActions.Exit)
                    {
                        break;
                    }
                }
                else if (result.State == CleanResultState.Canceled)
                {
                    Console.WriteLine("Action Canceled");
                }
                else if (result.State == CleanResultState.Failed)
                {
                    Console.WriteLine("Action Failed : " + result.Error);
                }
                Console.WriteLine();
            }
        }
    }
}
