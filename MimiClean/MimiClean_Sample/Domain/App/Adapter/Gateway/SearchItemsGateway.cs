﻿namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway
{
    using Abstract;
    using IAdapter;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="ISearchItems.IGateway"/> を実装します。コンソール入力を利用します。
    /// </summary>
    public class SearchItemsGateway(string name = "SearchItems") : ConsoleGateway<SearchItemsInput>(name), ISearchItems.IGateway
    {
        protected override SearchItemsInput MakeInputProtected()
        {
            string name = Utility.ReadName();

            return new SearchItemsInput(name);
        }

        protected override string Print(SearchItemsInput input)
        {
            return $"name : {input.name}";
        }
    }
}
