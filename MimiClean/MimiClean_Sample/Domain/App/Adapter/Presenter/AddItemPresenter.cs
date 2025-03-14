﻿using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Presenter
{
    using IAdapter;

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
