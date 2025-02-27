using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean.Domain.App.IAdapter
{
    /// <summary>
    /// 全ての動作に対する、操作の開始と入力の取得を抽象化します。
    /// </summary>
    public interface IAdapterGateway : ITransientService
    {
        /// <summary>
        /// 入力を取得します。
        /// </summary>
        /// <returns>取得した入力オブジェクト</returns>
        CleanResult<object> MakeInput();
    }

    /// <summary>
    /// 入力を持った動作に対する、操作の開始と入力の取得を抽象化します。
    /// </summary>
    /// <typeparam name="TInput">取得する入力オブジェクトの型</typeparam>
    public interface IAdapterGateway<TInput> : IAdapterGateway
    {
        /// <summary>
        /// 入力を取得します。
        /// </summary>
        /// <returns>取得した入力オブジェクト</returns>
        new CleanResult<TInput> MakeInput();
    }

    /// <summary>
    /// 入力を持たない動作に対する、操作の開始を抽象化します。
    /// </summary>
    public interface IAdapterGatewayVoid : IAdapterGateway<CleanResult.Void>
    {
    }
}
