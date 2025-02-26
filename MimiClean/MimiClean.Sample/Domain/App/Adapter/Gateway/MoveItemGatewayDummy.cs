using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway
{
    using IApp.IRepository;
    using IApp.UseCaseIO;

    public class MoveItemGatewayDummy(MimiServiceProvider serviceProvider, string name = "MoveItem(Dummy)") : MoveItemGateway(name)
    {
        protected override MoveItemInput MakeInputProtected()
        {
            string name;

            var names = serviceProvider.GetService<IItemMapRepository>().ItemNames;

            if (names.Any() && Random.Shared.NextDouble() < 0.75)
            {
                name = names.ElementAt(Random.Shared.Next(0, names.Count()));
            }
            else
            {
                name = "UNDIFINED_NAME";
            }

            int dx = Random.Shared.Next(-5, 5);
            int dy = Random.Shared.Next(-5, 5);

            return new MoveItemInput(name, dx, dy);
        }
    }
}
