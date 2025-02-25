using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.IAdapter
{
    public interface IAdapterGateway : ITransientService
    {
        /// <summary>
        /// 環境層からの入力を取得します。
        /// </summary>
        /// <returns>取得した入力オブジェクト</returns>
        CleanResult<object> MakeInput();
    }

    /// <summary>
    /// 環境層からの入力を表現するインターフェースです。
    /// </summary>
    /// <typeparam name="TInput">環境層から得る入力オブジェクトの型</typeparam>
    public interface IAdapterGateway<TInput> : IAdapterGateway
    {
        /// <summary>
        /// 環境層からの入力を取得します。
        /// </summary>
        /// <returns>取得した入力オブジェクト</returns>
        new CleanResult<TInput> MakeInput();
    }

    /// <summary>
    /// 環境層からの入力を表現するインターフェースです。
    /// </summary>
    public interface IAdapterGatewayVoid : IAdapterGateway<CleanResult.Void>
    {
    }
}
