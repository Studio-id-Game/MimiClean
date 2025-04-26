namespace StudioIdGames.MimiClean_Sample.Adapter.Gateway
{
    using Abstract;
    using IAdapter;
    using StudioIdGames.MimiClean.Railway;

    /// <summary>
    /// <see cref="IExit.IGateway"/> を実装します。コンソール入力を利用します。
    /// </summary>
    public class ExitGateway(string name = "Exit") : ConsoleGateway<CleanResult.Void>(name), IExit.IGateway
    {
        protected override CleanResult.Void MakeInputProtected() => new();

        protected override string Print(CleanResult.Void input) => "";
    }
}
