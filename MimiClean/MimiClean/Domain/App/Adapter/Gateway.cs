namespace StudioIdGames.MimiClean.Domain.App.Adapter
{
    using IAdapter;

    public abstract class Gateway<TInput> : IAdapterGateway<TInput>
    {
        public abstract CleanResult<TInput> MakeInput();

        CleanResult<object> IAdapterGateway.MakeInput() => MakeInput().AsObject();
    }

    public abstract class GatewayVoid : Gateway<CleanResult.Void>, IAdapterGatewayVoid
    {
    }
}
