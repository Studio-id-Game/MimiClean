namespace StudioIdGames.MimiClean.Domain.App.Adapter
{
    using IAdapter;

    /// <summary>
    /// 入力を持った動作に対する、操作の開始と入力の取得を実装します。
    /// </summary>
    /// <typeparam name="TInput">取得する入力オブジェクトの型</typeparam>
    public abstract class Gateway<TInput> : IAdapterGateway<TInput>
    {
        public abstract CleanResult<TInput> MakeInput();

        CleanResult<object> IAdapterGateway.MakeInput() => MakeInput().AsObject();
    }

    /// <summary>
    /// 入力を持ない動作に対する、操作の開始を実装します。
    /// </summary>
    public abstract class GatewayVoid : Gateway<CleanResult.Void>, IAdapterGatewayVoid
    {
    }
}
