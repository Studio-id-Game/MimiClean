using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain.App.Adapter;

namespace StudioIdGames.MimiClean_Sample.Domain.App.Adapter.Gateway.Abstract
{
    /// <summary>
    /// コンソールユーティリティーを提供するGatewayの抽象クラスです。
    /// </summary>
    /// <typeparam name="TInput">入力オブジェクトの型</typeparam>
    /// <param name="name">コンソールに表示する操作名</param>
    public abstract class ConsoleGateway<TInput>(string name) : Gateway<TInput>
    {
        /// <summary>
        /// コンソールユーティリティー
        /// </summary>
        protected static class Utility
        {
            /// <summary>
            /// 名前の入力を待機します。
            /// </summary>
            /// <param name="nameText">nameとして表示するラベル</param>
            /// <returns></returns>
            public static string ReadName(string? nameText = null)
            {
                nameText ??= "name";

                string name;

                do
                {
                    Console.Write($"{nameText} : ");
                } while (string.IsNullOrWhiteSpace(name = Console.ReadLine() ?? ""));

                return name;
            }

            /// <summary>
            /// XY座標の入力を待機します。
            /// </summary>
            /// <param name="xText">xとして表示するラベル</param>
            /// <param name="yText">yとして表示するラベル</param>
            /// <returns></returns>
            public static (int x, int y) ReadXY(string? xText = null, string? yText = null)
            {
                xText ??= "x";
                yText ??= "y";

                int x, y;

                do
                {
                    Console.Write($"{xText} : ");
                } while (!int.TryParse(Console.ReadLine(), out x));

                do
                {
                    Console.Write($"{yText} : ");
                } while (!int.TryParse(Console.ReadLine(), out y));

                return (x, y);
            }
        }

        /// <summary>
        /// コンソールに表示する操作名
        /// </summary>
        public string Name => name;

        /// <summary>
        /// コンソールから入力オブジェクトを構成します。
        /// </summary>
        /// <returns></returns>
        protected abstract TInput MakeInputProtected();

        /// <summary>
        /// 入力オブジェクトを可視化します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected abstract string Print(TInput input);

        public override CleanResult<TInput> MakeInput()
        {
            Console.WriteLine($"[Input] {Name}");

            var input = MakeInputProtected();
            var print = Print(input);

            Console.WriteLine($"[EndInput] {Name} ({print})\n");

            return CleanResult<TInput>.Success(input);
        }
    }
}
