﻿using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway
{
    using IApp.IRepository;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="SearchItemsGateway"/> のダミーを実装します。
    /// </summary>
    public class SearchItemsGatewayDummy(MimiServiceProvider serviceProvider, string name = "SearchItems(Dummy)") : SearchItemsGateway(name)
    {
        protected override SearchItemsInput MakeInputProtected()
        {
            string name;

            if (Random.Shared.NextDouble() < 0.75)
            {
                var items = serviceProvider.GetService<IItemMapRepository>();
                var names = items.ItemNames;
                name = names.ElementAt(Random.Shared.Next(0, names.Count()));
            }
            else
            {
                name = "UNDIFINED_NAME";
            }

            return new SearchItemsInput(name);
        }
    }
}
