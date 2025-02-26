using StudioIdGames.MimiClean;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway
{
    using Abstract;
    using IAdapter;

    public class ExitGateway(string name = "Exit") : ConsoleGateway<CleanResult.Void>(name), IExit.IGateway
    {
        protected override CleanResult.Void MakeInputProtected() => new();

        protected override string Print(CleanResult.Void input) => "";
    }
}
