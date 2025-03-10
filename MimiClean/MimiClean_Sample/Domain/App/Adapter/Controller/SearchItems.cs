﻿using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Controller
{
    using IAdapter;
    using IApp.IUseCase;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="IMoveItem"/>を実装します。
    /// </summary>
    public class SearchItems(ISearchItems.IGateway gateway, ISearchItemsUseCase usecase, ISearchItems.IPresenter presenter) :
        Controller<SearchItemsInput, SearchItemsOutput>(gateway, usecase, presenter), ISearchItems
    {
    }
}
