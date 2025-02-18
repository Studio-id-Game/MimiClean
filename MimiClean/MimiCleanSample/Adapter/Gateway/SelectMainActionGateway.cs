using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Adapter;
using StudioIdGames.MimiCleanSample.App.UseCase;
using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample.Adapter.Gateway
{
    internal class SelectMainActionGateway(bool useDummy) : IGateway<SelectMainActionInput>
    {
        public bool UseDummy { get; } = useDummy;

        public CleanResult<SelectMainActionInput> MakeInput()
        {
            Console.WriteLine($"[Input] SelectAction");

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

                Console.WriteLine($"[EndInput] SelectAction ({act})\n");
                return CleanResult<SelectMainActionInput>.Success(new(act, UseDummy));

            } while (true);
        }
    }
}
