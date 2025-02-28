namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway
{
    using Abstract;
    using DomainType;
    using IAdapter;
    using IApp.UseCaseIO;

    /// <summary>
    /// <see cref="ISelectMainAction.IGateway"/> を実装します。コンソール入力を利用します。
    /// </summary>
    public class SelectMainActionGateway(string name = "SelectMainAction") : ConsoleGateway<SelectMainActionInput>(name), ISelectMainAction.IGateway
    {
        protected override SelectMainActionInput MakeInputProtected()
        {
            Console.WriteLine($"\tAddItem(1), MoveItem(2), SearchItems(3), Exit(0)");

            do
            {
                Console.Write("Action Name or Number : ");
                var line = Console.ReadLine() ?? "";
                MainActions act;
                switch (line.Trim())
                {
                    case "1":
                    case "AddItem":
                        act = MainActions.AddItem; break;
                    case "2":
                    case "MoveItem":
                        act = MainActions.MoveItem; break;
                    case "3":
                    case "SearchItems":
                        act = MainActions.SearchItems; break;
                    case "0":
                    case "Exit":
                        act = MainActions.Exit; break;
                    default: continue;
                }

                return new SelectMainActionInput(act);
            } while (true);
        }

        protected override string Print(SelectMainActionInput input)
        {
            return input.mainAction.ToString();
        }
    }
}
