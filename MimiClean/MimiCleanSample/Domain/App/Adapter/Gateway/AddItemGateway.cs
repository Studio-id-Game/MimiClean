
namespace StudioIdGames.MimiCleanSample.Domain.App.Adapter.Gateway
{
    using Abstract;
    using IAdapter;
    using IApp.UseCaseIO;

    public class AddItemGateway(string name = "AddItem") : ConsoleGateway<AddItemInput>(name), IAddItem.IGateway
    {
        protected override AddItemInput MakeInputProtected()
        {
            string name = Utility.ReadName();
            var (x, y) = Utility.ReadXY();
            return new AddItemInput(name, x, y);
        }

        protected override string Print(AddItemInput input)
        {
            return $"name : {input.name}, x : {input.x}, y : {input.y}";
        }
    }
}
