using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway
{
    using IAdapter;
    using IApp.IRepository;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="AddItemGateway"/> のダミーを実装します。
    /// </summary>
    public class AddItemGatewayDummy(MimiServiceProvider serviceProvider, string name = "AddItem(Dummy)") : AddItemGateway(name), IAddItem.IGateway
    {
        protected override AddItemInput MakeInputProtected()
        {
            var mapinfo = serviceProvider.GetService<IMapInfoRepository>().Value;
            string name = ((char)Random.Shared.Next('A', 'G' + 1)).ToString();
            int x = Random.Shared.Next(0, mapinfo.Width);
            int y = Random.Shared.Next(0, mapinfo.Height);
            return new AddItemInput(name, x, y);
        }
    }
}
