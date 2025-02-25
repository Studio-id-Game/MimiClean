
namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Gateway
{
    using Abstract;
    using IAdapter;
    using IApp.UseCaseIO;

    public class MoveItemGateway(string name = "MoveItem") : ConsoleGateway<MoveItemInput>(name), IMoveItem.IGateway
    {
        protected override MoveItemInput MakeInputProtected()
        {
            string name = Utility.ReadName();
            var (dx, dy) = Utility.ReadXY();

            return new MoveItemInput(name, dx, dy);
        }

        protected override string Print(MoveItemInput input)
        {
            return $"name : {input.name}, dx : {input.dx}, dy : {input.dy}";
        }
    }
}
