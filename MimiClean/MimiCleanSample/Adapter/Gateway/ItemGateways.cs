using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Adapter;
using StudioIdGames.MimiClean.App;
using StudioIdGames.MimiCleanSample.App.Repository;
using StudioIdGames.MimiCleanSample.App.UseCase;

namespace StudioIdGames.MimiCleanSample.Adapter.Gateway
{

    internal static class ItemGateways
    {
        private static string ReadName()
        {
            string name;

            do
            {
                Console.Write("name : ");
            } while (string.IsNullOrWhiteSpace(name = Console.ReadLine() ?? ""));

            return name;
        }

        private static (int x, int y) ReadXY()
        {
            int x, y;

            do
            {
                Console.Write("x : ");
            } while (!int.TryParse(Console.ReadLine(), out x));

            do
            {
                Console.Write("y : ");
            } while (!int.TryParse(Console.ReadLine(), out y));

            return (x, y);
        }

        public abstract class GatewayBase<T> : IGateway<T>
        {
            protected abstract string Name { get; }

            protected abstract T MakeInputProtected();

            protected abstract string Print(T input);

            public CleanResult<T> MakeInput()
            {
                Console.WriteLine($"[Input] {Name}");

                var input = MakeInputProtected();

                Console.WriteLine($"[EndInput] {Name} ({Print(input)})\n");

                return CleanResult<T>.Success(input);
            }
        }

        public class AddItemGateway : GatewayBase<AddItemInput>
        {
            protected override string Name => "AddItem";

            protected override AddItemInput MakeInputProtected()
            {
                string name = ReadName();
                var (x, y) = ReadXY();
                return new AddItemInput(name, x, y);
            }

            protected override string Print(AddItemInput input)
            {
                return $"name : {input.name}, x : {input.x}, y : {input.y}";
            }
        }

        public class AddItemGatewayDummy : AddItemGateway
        {
            protected override string Name => base.Name + "(Dummy)";

            protected override AddItemInput MakeInputProtected()
            {
                var mapinfo = Repository<IMapInfoRepository>.I.Value;
                string name = Random.Shared.Next(100, 999).ToString("D3");
                int x = Random.Shared.Next(0, mapinfo.Width);
                int y = Random.Shared.Next(0, mapinfo.Height);
                return new AddItemInput(name, x, y);
            }
        }

        public class MoveItemGateway : GatewayBase<MoveItemInput>
        {
            protected override string Name => "MoveItem";

            protected override MoveItemInput MakeInputProtected()
            {
                string name = ReadName();
                var (dx, dy) = ReadXY();

                return new MoveItemInput(name, dx, dy);
            }

            protected override string Print(MoveItemInput input)
            {
                return $"name : {input.name}, dx : {input.dx}, dy : {input.dy}";
            }
        }

        public class MoveItemGatewayDummy : MoveItemGateway
        {
            protected override string Name => base.Name + "(Dummy)";

            protected override MoveItemInput MakeInputProtected()
            {
                var items = Repository<IItemRepository>.I;
                var item = items.ElementAt(Random.Shared.Next(0, items.Count));
                string name = item.NameModule.ItemName;
                int dx = Random.Shared.Next(-5, 5);
                int dy = Random.Shared.Next(-5, 5);

                return new MoveItemInput(name, dx, dy);
            }
        }

        public class SearchItemsGateway : GatewayBase<SearchItemsInput>
        {
            protected override string Name => "SearchItems";

            protected override SearchItemsInput MakeInputProtected()
            {
                string name = ReadName();

                return new SearchItemsInput(name);
            }

            protected override string Print(SearchItemsInput input)
            {
                return $"name : {input.name}";
            }
        }

        public class SearchItemsGatewayDummy : SearchItemsGateway
        {
            protected override string Name => base.Name + "(Dummy)";

            protected override SearchItemsInput MakeInputProtected()
            {
                if (Random.Shared.NextDouble() < 0.5)
                {
                    var items = Repository<IItemRepository>.I;
                    var item = items.ElementAt(Random.Shared.Next(0, items.Count));
                    string name = item.NameModule.ItemName;

                    return new SearchItemsInput(name);
                }
                else
                {
                    return new SearchItemsInput("UNDIFINED_NAME");
                }
            }
        }
    }
}
