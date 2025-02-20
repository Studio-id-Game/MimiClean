using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.Adapter.Controller;
using StudioIdGames.MimiCleanSample.App.Service;
using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample.Adapter.Service
{
    internal class MainActionService : Service<IMainActionService, MainActionService>, IMainActionService
    {
        public CleanResult<CleanResult.Void> Invoke(MainActions mainActions, bool dummyMode)
        {
            if (dummyMode)
            {
                switch (mainActions)
                {
                    case MainActions.AddItem:
                        return ItemController.AddItemController.Dummy.Invoke();
                    case MainActions.MoveItem:
                        return ItemController.MoveItemController.Dummy.Invoke();
                    case MainActions.SearchItems:
                        return ItemController.SearchItemsController.Dummy.Invoke();
                }
            }
            else
            {
                switch (mainActions)
                {
                    case MainActions.AddItem:
                        return ItemController.AddItemController.Default.Invoke();
                    case MainActions.MoveItem:
                        return ItemController.MoveItemController.Default.Invoke();
                    case MainActions.SearchItems:
                        return ItemController.SearchItemsController.Default.Invoke();
                }
            }

            return CleanResult.Success();
        }
    }
}
