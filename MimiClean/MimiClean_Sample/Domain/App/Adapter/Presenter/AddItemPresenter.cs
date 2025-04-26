namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Presenter
{
    using IAdapter;
    using StudioIdGames.MimiClean.Adapter;
    using StudioIdGames.MimiClean.Railway;

    /// <summary>
    /// <see cref="IAddItem.IPresenter"/> を実装します。
    /// </summary>
    public class AddItemPresenter : PresenterVoid, IAddItem.IPresenter
    {
        public override CleanResult<CleanResult.Void> Present(in CleanResult<CleanResult.Void> usecaseOutput)
        {
            if (usecaseOutput.IsSuccess)
            {
                Console.WriteLine("Item Added.");
            }

            return usecaseOutput;
        }
    }
}
