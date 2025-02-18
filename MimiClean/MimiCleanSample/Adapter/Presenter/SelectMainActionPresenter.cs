using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Adapter;
using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample.Adapter.Presenter
{
    internal class SelectMainActionPresenter : IPresenter<MainActions, MainActions>
    {
        public CleanResult<MainActions> Present(in CleanResult<MainActions> output)
        {
            if (!output.IsSuccess)
            {
                return output;
            }

            if (output.Result == MainActions.Exit)
            {
                Console.WriteLine("See you again!");
            }
            else
            {
                Console.WriteLine("Action Complete.");
            }

            return output;
        }
    }
}
